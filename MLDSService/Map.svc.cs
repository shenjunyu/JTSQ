using System;
using System.Linq;
using MLDSData;
using MLDSService.DataContracts;
using System.Web;
using MLDSService.Methods;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Dynamic”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Dynamic.svc 或 Dynamic.svc.cs，然后开始调试。
    public class Map : IMap
    {
        private static MLDSDataContext ds = new MLDSDataContext();
        #region 通用方法
        /*-----------------获取区域中心----------------*/
        public CommonMapPoint getDistrictCenter(string districtID)
        {
            CommonMapPoint returnData = new CommonMapPoint();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var x = ds.SYS_District.SingleOrDefault(d => d.id == districtID);
                    if (x != null)
                    {
                        returnData.x = x.x;
                        returnData.y = x.y;
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:区域信息不存在,无法定位！";
                        return returnData;
                    }
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:区域选择错误！";
                return returnData;
            }
        }

        /*-----------------获取区域范围-----------------*/
        public CommonOutputT<Map_District[]> getDistrict(string districtID, int zoom)
        {
            CommonOutputT<Map_District[]> returnData = new CommonOutputT<Map_District[]>();
            if (!string.IsNullOrEmpty(districtID))
            {
                if (!string.IsNullOrEmpty(zoom.ToString()))
                {
                    try
                    {
                        var districts = CommonMethod.getSubDistrict(districtID);
                        var x = (from a in ds.SYS_District
                                 where districts.Contains(a.id) && a.districtLevel == zoom
                                 select new Map_District
                                 {
                                     districtID = a.id,
                                     attachTo = a.attachTo,
                                     districtLevel = (int)a.districtLevel,
                                     districtName = a.districtName,
                                     x = Convert.ToDouble(a.x),
                                     y = Convert.ToDouble(a.y),
                                     description = a.description
                                 }).ToList();
                        foreach (var i in x)
                        {
                            var area = ds.SYS_District.SingleOrDefault(d => d.id == i.districtID).area;
                            if (!string.IsNullOrEmpty(area))
                            {
                                area = area.Replace("\n", "");
                                area = area.Substring(6);
                                area = area.Remove(area.Length - 2, 2);
                                area = area.Replace("),(", "P");
                                string[] areaPoints = area.Split('P');
                                Map_District_Area[] Points = new Map_District_Area[areaPoints.Length];
                                for (int j = 0; j < areaPoints.Length; j++)
                                {
                                    double Pointx, Pointy;
                                    Map_District_Area point = new Map_District_Area();
                                    string[] areaPointsCoordinate = areaPoints[j].Split(',');
                                    Pointx = Convert.ToDouble(areaPointsCoordinate[0]);
                                    Pointy = Convert.ToDouble(areaPointsCoordinate[1]);
                                    point.x = Pointx;
                                    point.y = Pointy;
                                    Points[j] = point;
                                }
                                i.Area = Points.ToArray();
                            }
                        }
                        returnData.data = x.ToArray();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = false;
                        returnData.message = "Error123:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.success = false;
                    returnData.message = "Error:地图加载失败！";
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:登陆信息已过期，请重新登陆！";
                return returnData;
            }
        }

        /*-----------------获取特殊标注-----------------*/
        public CommonOutputT<Map_Marker[]> getplane(string type)
        {
            CommonOutputT<Map_Marker[]> returnData = new CommonOutputT<Map_Marker[]>();
            try
            {
                var x = (from a in ds.Map_Marker
                         where a.type == type
                         orderby a.x descending
                         select a).ToList();
                returnData.success = true;
                returnData.message = "Success";
                returnData.data = x.ToArray();
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.success = false;
                returnData.message = "Error:" + ex.Message;
                return returnData;
            }
        }
        #endregion

        #region 人口地图
        /*-----------------根据缩放获取人口数据（大）-----------------*/
        public CommonOutputT<Map_ZoomNum[]> getMapPopulationBlock(string districtID, double centerX, double centerY, int zoomLevel, int explorX, int explorY)
        {
            CommonOutputT<Map_ZoomNum[]> returnData = new CommonOutputT<Map_ZoomNum[]>();
            var radius = CommonMethod.calculateRadius(explorX, explorY, zoomLevel);
            var radiusPow2 = Math.Pow(radius, 2);
            if (!string.IsNullOrEmpty(districtID) || centerX.ToString() != null || centerY.ToString() != null || zoomLevel.ToString() != null)
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID); ;
                    List<Map_ZoomNum> x = null;
                    if (zoomLevel < 7)
                    {
                        x = (from a in ds.SYS_District
                             where a.districtLevel == 6 && districts.Contains(a.id)
                             //&& 300000 * (Math.Acos(Math.Cos(Convert.ToDouble(a.y)) * Math.Cos(centerY) * Math.Cos(Convert.ToDouble(a.x) - centerX) + Math.Sin(Convert.ToDouble(a.y)) * Math.Sin(centerY))) < radius
                             select new Map_ZoomNum
                             {
                                 districtID = a.id,
                                 districtName = a.districtName,
                                 attachTo = a.attachTo,
                                 districtLevel = (int)a.districtLevel,
                                 x = Convert.ToDouble(a.x),
                                 y = Convert.ToDouble(a.y)
                             }).ToList();
                    }
                    else
                    {
                        x = (from a in ds.SYS_District
                             where a.districtLevel == zoomLevel && districts.Contains(a.id)
                             //&& 300000 * (Math.Acos(Math.Cos(Convert.ToDouble(a.y)) * Math.Cos(centerY) * Math.Cos(Convert.ToDouble(a.x) - centerX) + Math.Sin(Convert.ToDouble(a.y)) * Math.Sin(centerY))) < radius
                             select new Map_ZoomNum
                             {
                                 districtID = a.id,
                                 districtName = a.districtName,
                                 attachTo = a.attachTo,
                                 districtLevel = (int)a.districtLevel,
                                 x = Convert.ToDouble(a.x),
                                 y = Convert.ToDouble(a.y)
                             }).ToList();
                    }
                    returnData.data = x.ToArray();
                    foreach (var i in returnData.data)
                    {
                        districts = CommonMethod.getSubDistrict(i.districtID);
                        i.number = ds.POP_Basic.Where(d => districts.Contains(d.districtID) && d.status != 0).Count();
                    }
                    returnData.success = true;
                    returnData.message = "success";
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error456:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "登陆信息有误，请重新登陆！";
                return returnData;
            }
        }

        /*-----------------根据缩放获取人口数据（小）-----------------*/
        public CommonOutputT<Map_Family[]> getMapFamily(string districtID, double centerX, double centerY, int zoomLevel, int explorX, int explorY)
        {
            CommonOutputT<Map_Family[]> returnData = new CommonOutputT<Map_Family[]>();
            var radius = CommonMethod.calculateRadius(explorX, explorY, zoomLevel);
            var radiusPow2 = Math.Pow(radius, 2);
            if (!string.IsNullOrEmpty(districtID) || centerX.ToString() != null || centerY.ToString() != null || zoomLevel.ToString() != null)
            {
                try
                {
                    List<string> districts = CommonMethod.getSubDistrict(districtID);
                    var x = (from a in ds.POP_Building
                             join c in ds.SYS_District on a.districtID equals c.id into c1
                             from c2 in c1.DefaultIfEmpty()
                             where districts.Contains(a.districtID)
                             select new Map_Family
                             {
                                 address = a.plot + a.houseNum,
                                 district = c2.districtName,
                                 structure = a.structure,
                                 houseNum = a.houseNum,
                                 //peopleNum = ds.POP_Basic.Where(d => d.addressID == a.id).Count(),
                                 houseMembers = (from p in ds.POP_Family
                                                 where p.addressID == a.id
                                                 select new Map_HouseMember
                                                 {
                                                     bookletNum = p.bookletNum,
                                                     floor = a.floor,
                                                     peopleNum = ds.POP_Basic.Where(d => d.addressID == a.id).Count(),
                                                     structure = a.structure,
                                                     roomNum = a.roomNum == null ? "无" : a.roomNum,
                                                     familyMembers = (from m in ds.POP_Basic
                                                                      where p.bookletNum == m.bookletNum
                                                                      select new List_FamilyMember
                                                                      {
                                                                          id = m.id,
                                                                          IDCard = m.IDCard,
                                                                          name = m.name,
                                                                          sex = m.sex,
                                                                          relationship = m.relationship,
                                                                          age = CommonMethod.IDCard2Age(m.IDCard)
                                                                      }).ToArray(),
                                                     farmLand = (from h in ds.AGR_FarmLand
                                                                 where h.familyID == p.id
                                                                 select new Map_HouseMember_FarmLand
                                                                 {
                                                                     id = h.id,
                                                                     address = h.address
                                                                 }).ToArray()
                                                 }).ToArray(),
                                 x = Convert.ToDouble(a.x),
                                 y = Convert.ToDouble(a.y)
                             }).ToList();

                    returnData.data = x.ToArray();
                    returnData.success = true;
                    returnData.message = "success";
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error321:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "登陆信息有误，请重新登陆！";
                return returnData;
            }
        }

        /*-----------------党员分布查看---------*/
        public CommonOutputT<Map_PopulationSearchByParty[]> getPartyMember(int type, string districtID)
        {
            CommonOutputT<Map_PopulationSearchByParty[]> returnData = new CommonOutputT<Map_PopulationSearchByParty[]>();
            if (type.ToString() != null)
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = (from a in ds.POP_Party
                             join b in ds.POP_Basic on a.populationID equals b.id into b1
                             from b2 in b1.DefaultIfEmpty()
                             join c in ds.POP_Building on b2.addressID equals c.id into c1
                             from c2 in c1.DefaultIfEmpty()
                             where a.status != 0 && districts.Contains(a.districtID) && c2.x != null && c2.y != null
                             select new Map_PopulationSearchByParty
                             {
                                 id = b2.id,
                                 department = a.department,
                                 IDCard = b2.IDCard,
                                 joinTime = a.joinTime,
                                 name = b2.name,
                                 portrait = a.portrait,
                                 partyAge = CommonMethod.joinTime2partyAge(a.joinTime).ToString(),
                                 x = (c2.x == null) ? 0 : Convert.ToDouble(c2.x),
                                 y = (c2.y == null) ? 0 : Convert.ToDouble(c2.y),
                             }).ToList();
                    foreach (var i in x)
                    {
                        if (type == 1)
                        {
                            returnData.data = x.ToArray();
                        }
                        else if (type == 2)
                        {
                            returnData.data = x.Where(d => Convert.ToInt32(d.partyAge) >= 50).ToArray();
                        }
                        else if (type == 3)
                        {
                            returnData.data = x.Where(d => (Convert.ToInt32(d.partyAge) >= 40) && (Convert.ToInt32(d.partyAge)) < 50).ToArray();
                        }
                        else if (type == 4)
                        {
                            returnData.data = x.Where(d => (Convert.ToInt32(d.partyAge) >= 30) && (Convert.ToInt32(d.partyAge)) < 40).ToArray();
                        }
                        else if (type == 5)
                        {
                            returnData.data = x.Where(d => (Convert.ToInt32(d.partyAge) >= 20) && (Convert.ToInt32(d.partyAge)) < 30).ToArray();
                        }
                        else if (type == 6)
                        {
                            returnData.data = x.Where(d => (Convert.ToInt32(d.partyAge) >= 10) && (Convert.ToInt32(d.partyAge)) < 20).ToArray();
                        }
                        else if (type == 7)
                        {
                            returnData.data = x.Where(d => (Convert.ToInt32(d.partyAge) >= 0) && (Convert.ToInt32(d.partyAge)) < 10).ToArray();
                        }
                        else
                        {
                            returnData.success = false;
                            returnData.message = "请选择正确的党龄类型";
                        }

                    }
                    returnData.success = true;
                    returnData.message = "success";
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:至少选择一个党龄！";
                return returnData;
            }
        }
        /*-----------------老年人分布查看---------*/
        public CommonOutputT<Map_PopulationSearchBygetElderly[]> getElderly(int type, string districtID)
        {
            CommonOutputT<Map_PopulationSearchBygetElderly[]> returnData = new CommonOutputT<Map_PopulationSearchBygetElderly[]>();
            if (type.ToString() != null)
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = (from a in ds.POP_Basic
                             join b in ds.POP_Building on a.addressID equals b.id into b1
                             from b2 in b1.DefaultIfEmpty()
                             join c in ds.SYS_District on a.districtID equals c.id into c1
                             from c2 in c1.DefaultIfEmpty()
                             where a.status != 0 && districts.Contains(a.districtID) && b2.x != null && b2.y != null
                             select new Map_PopulationSearchBygetElderly
                             {
                                 id = a.id,
                                 name = a.name,
                                 IDCard = a.IDCard,
                                 district = c2.districtName,
                                 age = CommonMethod.IDCard2Age(a.IDCard).ToString(),
                                 x = (b2.x == null) ? 0 : Convert.ToDouble(b2.x),
                                 y = (b2.y == null) ? 0 : Convert.ToDouble(b2.y),
                             }).ToList();
                    foreach (var i in x)
                    {
                        if (type == 1)
                        {
                            returnData.data = x.Where(d => Convert.ToInt32(d.age) >= 60).ToArray();
                        }
                        else if (type == 2)
                        {
                            returnData.data = x.Where(d => Convert.ToInt32(d.age) >= 80).ToArray();
                        }
                        else if (type == 3)
                        {
                            returnData.data = x.Where(d => (Convert.ToInt32(d.age) >= 70) && (Convert.ToInt32(d.age)) < 80).ToArray();
                        }
                        else if (type == 4)
                        {
                            returnData.data = x.Where(d => (Convert.ToInt32(d.age) >= 60) && (Convert.ToInt32(d.age)) < 70).ToArray();
                        }
                        else
                        {
                            returnData.success = false;
                            returnData.message = "请选择正确的年龄类型";
                        }
                    }
                    returnData.success = true;
                    returnData.message = "success";
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:至少选择一个党龄！";
                return returnData;
            }
        }

        /*-----------------按党员类型搜索人口-------------------*/
        public CommonOutputT<Map_PopulationSearchByParty[]> mapSearchPartyPopulation(string districtID)
        {
            CommonOutputT<Map_PopulationSearchByParty[]> returnData = new CommonOutputT<Map_PopulationSearchByParty[]>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = (from a in ds.POP_Party
                             join b in ds.POP_Basic on a.populationID equals b.id into b1
                             from b2 in b1.DefaultIfEmpty()
                             join c in ds.POP_Building on b2.addressID equals c.id into c1
                             from c2 in c1.DefaultIfEmpty()
                             where a.status != 0 && districts.Contains(a.districtID) && c2.x != null && c2.y != null
                             select new Map_PopulationSearchByParty
                             {
                                 id = b2.id,
                                 department = a.department,
                                 IDCard = b2.IDCard,
                                 joinTime = a.joinTime,
                                 name = b2.name,
                                 portrait = a.portrait,
                                 partyAge = CommonMethod.joinTime2partyAge(a.joinTime).ToString(),
                                 x = (c2.x == null) ? 0 : Convert.ToDouble(c2.x),
                                 y = (c2.y == null) ? 0 : Convert.ToDouble(c2.y)
                             }).ToList();
                    returnData.data = x.ToArray();
                    returnData.success = true;
                    returnData.message = "success";
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:至少选择一种类型！";
                return returnData;
            }
        }

        /*-----------------按工作人员类型搜索人口-------------------*/
        public CommonOutputT<Map_PopulationSearchByLeader[]> mapSearchLeaderPopulation(string districtID)
        {
            CommonOutputT<Map_PopulationSearchByLeader[]> returnData = new CommonOutputT<Map_PopulationSearchByLeader[]>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = (from a in ds.POP_Leader
                             join b in ds.POP_Basic on a.populationID equals b.id into b1
                             from b2 in b1.DefaultIfEmpty()
                             join c in ds.POP_Building on b2.addressID equals c.id into c1
                             from c2 in c1.DefaultIfEmpty()
                             join d in ds.SYS_District on a.districtID equals d.id into d1
                             from d2 in d1.DefaultIfEmpty()
                             where a.status != 0 && districts.Contains(a.districtID) && c2.x != null && c2.y != null
                             select new Map_PopulationSearchByLeader
                             {
                                 id = b2.id,
                                 IDCard = b2.IDCard,
                                 district = d2.districtName,
                                 duty = a.duty,
                                 name = b2.name,
                                 portrait = a.portrait,
                                 x = (c2.x == null) ? 0 : Convert.ToDouble(c2.x),
                                 y = (c2.y == null) ? 0 : Convert.ToDouble(c2.y)
                             }).ToList();
                    returnData.data = x.ToArray();
                    returnData.success = true;
                    returnData.message = "success";
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:至少选择一种类型！";
                return returnData;
            }
        }

        /*-----------------残疾人分布查看---------*/
        public CommonOutputT<Map_PopulationSearchBygetDisabled[]> getMapDisabled(string districtID)
        {
            CommonOutputT<Map_PopulationSearchBygetDisabled[]> returnData = new CommonOutputT<Map_PopulationSearchBygetDisabled[]>();
            if (districtID.ToString() != null)
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = (from a in ds.POP_Disabled
                             join b in ds.POP_Basic on a.populationID equals b.id into b1
                             from b2 in b1.DefaultIfEmpty()
                             join c in ds.POP_Building on b2.addressID equals c.id into c1
                             from c2 in c1.DefaultIfEmpty()
                             where districts.Contains(a.districtID) && c2.x != null && c2.y != null
                             select new Map_PopulationSearchBygetDisabled
                             {
                                 id = b2.id,
                                 name = b2.name,
                                 sex = b2.sex,
                                 IDCard = b2.IDCard,
                                 disableNum = a.disableNum,
                                 disablelevel = a.disablelevel,
                                 relieffunds = a.relieffunds,
                                 guardian = a.guardian,
                                 x = (c2.x == null) ? 0 : Convert.ToDouble(c2.x),
                                 y = (c2.y == null) ? 0 : Convert.ToDouble(c2.y),
                             }).ToList();
                    returnData.data = x.ToArray();
                    returnData.success = true;
                    returnData.message = "success";
                    return returnData;
                }

                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:至少选择一个区域！";
                return returnData;
            }
        }

        /*-----------------和谐家庭分布查看---------*/
        public CommonOutputT<Map_Family[]> getMapHarmoniousFamily(string districtID)
        {
            CommonOutputT<Map_Family[]> returnData = new CommonOutputT<Map_Family[]>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    List<string> districts = CommonMethod.getSubDistrict(districtID);
                    var x = (from a in ds.POP_Building
                             join c in ds.SYS_District on a.districtID equals c.id into c1
                             from c2 in c1.DefaultIfEmpty()
                                 //       from a1 in ds.POP_Family
                             where districts.Contains(a.districtID)
                             select new Map_Family
                             {
                                 address = a.plot + a.houseNum,
                                 district = c2.districtName,
                                 structure = a.structure,
                                 houseNum = a.houseNum,
                                 houseMembers = (from p in ds.POP_Family
                                                 where p.addressID == a.id && p.isHarmoniousFamily == "1"
                                                 select new Map_HouseMember
                                                 {
                                                     bookletNum = p.bookletNum,
                                                     floor = a.floor,
                                                     peopleNum = ds.POP_Basic.Where(d => d.addressID == a.id).Count(),
                                                     structure = a.structure,
                                                     roomNum = a.roomNum == null ? "无" : a.roomNum,
                                                     familyMembers = (from m in ds.POP_Basic
                                                                      where p.bookletNum == m.bookletNum
                                                                      select new List_FamilyMember
                                                                      {
                                                                          id = m.id,
                                                                          IDCard = m.IDCard,
                                                                          name = m.name,
                                                                          sex = m.sex,
                                                                          relationship = m.relationship,
                                                                          age = CommonMethod.IDCard2Age(m.IDCard)
                                                                      }).ToArray()
                                                 }).ToArray(),
                                 x = Convert.ToDouble(a.x),
                                 y = Convert.ToDouble(a.y)
                             }).ToList();
                    List<Map_Family> list = new List<Map_Family>();   ///
                    foreach (var i in x)
                    {
                        if (i.houseMembers.Length > 0)
                        {
                            list.Add(i);
                        }
                    }
                    returnData.data = list.ToArray();
                    returnData.success = true;
                    returnData.message = "success";
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error321:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "登陆信息有误，请重新登陆！";
                return returnData;
            }

        }

        #endregion

        #region 农业地图
        /*-----------作物分布查看---------*/
        public CommonOutputT<Map_Product_Area[]> getProductArea(int type)
        {
            CommonOutputT<Map_Product_Area[]> returnData = new CommonOutputT<Map_Product_Area[]>();
            if (!string.IsNullOrEmpty(type.ToString()))
            {
                try
                {
                    IQueryable<Map_Product_Area> x = null;
                    switch (type)
                    {
                        case 1:
                            x = from a in ds.AGR_Product_Area
                                join b in ds.AGR_Product on a.productID equals b.id into b1
                                from b2 in b1.DefaultIfEmpty()
                                where b2.name == "大闸蟹"
                                select new Map_Product_Area
                                {
                                    description = b2.description,
                                    imageURL = b2.imageURL,
                                    name = b2.name,
                                    type = b2.type,
                                    area = CommonMethod.areaStr2areaAssembly(a.area)
                                };
                            returnData.data = x.ToArray();
                            returnData.success = true;
                            returnData.message = "success";
                            break;
                        case 2:
                            x = from a in ds.AGR_Product_Area
                                join b in ds.AGR_Product on a.productID equals b.id into b1
                                from b2 in b1.DefaultIfEmpty()
                                where b2.name == "茶叶"
                                select new Map_Product_Area
                                {
                                    description = b2.description,
                                    imageURL = b2.imageURL,
                                    name = b2.name,
                                    type = b2.type,
                                    area = CommonMethod.areaStr2areaAssembly(a.area)
                                };
                            returnData.data = x.ToArray();
                            returnData.success = true;
                            returnData.message = "success";
                            break;
                        case 3:
                            x = from a in ds.AGR_Product_Area
                                join b in ds.AGR_Product on a.productID equals b.id into b1
                                from b2 in b1.DefaultIfEmpty()
                                where b2.name == "杨梅"
                                select new Map_Product_Area
                                {
                                    description = b2.description,
                                    imageURL = b2.imageURL,
                                    name = b2.name,
                                    type = b2.type,
                                    area = CommonMethod.areaStr2areaAssembly(a.area)
                                };
                            returnData.data = x.ToArray();
                            returnData.success = true;
                            returnData.message = "success";
                            break;
                        case 4:
                            x = from a in ds.AGR_Product_Area
                                join b in ds.AGR_Product on a.productID equals b.id into b1
                                from b2 in b1.DefaultIfEmpty()
                                where b2.name == "枇杷"
                                select new Map_Product_Area
                                {
                                    description = b2.description,
                                    imageURL = b2.imageURL,
                                    name = b2.name,
                                    type = b2.type,
                                    area = CommonMethod.areaStr2areaAssembly(a.area)
                                };
                            returnData.data = x.ToArray();
                            returnData.success = true;
                            returnData.message = "success";
                            break;
                        default:
                            returnData.success = false;
                            returnData.message = "Error:选择了无效的类型!";
                            break;
                    }
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:选择了无效的类型!";
                return returnData;
            }


        }

        /*------------农场分布查看---------*/
        public CommonOutputT<Map_Farm[]> mapGetFarm(string districtID, string type)
        {
            CommonOutputT<Map_Farm[]> returnData = new CommonOutputT<Map_Farm[]>();
            if (!string.IsNullOrEmpty(districtID))
            {
                var districts = CommonMethod.getSubDistrict(districtID);
                try
                {
                    if (!string.IsNullOrEmpty(type))
                    {
                        IQueryable<Map_Farm> x = null;
                        switch (type)
                        {
                            case "1":
                                x = from a in ds.AGR_Farm
                                    join b in ds.AGR_Farm_Contractor on a.contractorID equals b.id into b1
                                    from b2 in b1.DefaultIfEmpty()
                                    where districts.Contains(a.districtID)
                                    select new Map_Farm
                                    {
                                        name = a.name,
                                        description = a.description,
                                        contractorName = b2.name,
                                        contractorIDCard = b2.IDCard,
                                        contractorInform = b2.inform,
                                        contractorPhone = b2.phone,
                                        contractorPortrait = b2.portrait,
                                        images = (from c in ds.AGR_Farm_Image
                                                  where c.farmID == a.id
                                                  select new Map_Farm_Image
                                                  {
                                                      id = c.id,
                                                      imageURL = c.imageURL
                                                  }).ToArray(),
                                        products = (from d in ds.AGR_Farm_Product
                                                    join e in ds.AGR_Product on d.productID equals e.id into e1
                                                    from e2 in e1.DefaultIfEmpty()
                                                    join f in ds.AGR_Expert on d.expertID equals f.id into f1
                                                    from f2 in f1.DefaultIfEmpty()
                                                    where d.farmID == a.id
                                                    select new Map_Farm_Product
                                                    {
                                                        id = d.id,
                                                        area = Convert.ToInt32(d.area).ToString(),
                                                        location = d.location,
                                                        productName = e2.name,
                                                        expertName = f2.name,
                                                        expertPortrait = f2.portrait,
                                                        values = (from g in ds.AGR_Farm_Product_Value
                                                                  where g.farmProductID == d.id
                                                                  select new Map_Farm_Product_Year_Value
                                                                  {
                                                                      year = g.year,
                                                                      id = g.id,
                                                                      production = g.production,
                                                                      value = g.value
                                                                  }).ToArray()
                                                    }).ToArray(),
                                        area = CommonMethod.areaStr2areaAssembly(a.area)
                                    };
                                break;
                            case "2":
                                x = from a in ds.AGR_Farm
                                    join b in ds.AGR_Farm_Contractor on a.contractorID equals b.id into b1
                                    from b2 in b1.DefaultIfEmpty()
                                    where districts.Contains(a.districtID) && a.id == "F001"
                                    select new Map_Farm
                                    {
                                        name = a.name,
                                        description = a.description,
                                        contractorName = b2.name,
                                        contractorIDCard = b2.IDCard,
                                        contractorInform = b2.inform,
                                        contractorPhone = b2.phone,
                                        contractorPortrait = b2.portrait,
                                        images = (from c in ds.AGR_Farm_Image
                                                  where c.farmID == a.id
                                                  select new Map_Farm_Image
                                                  {
                                                      id = c.id,
                                                      imageURL = c.imageURL
                                                  }).ToArray(),
                                        products = (from d in ds.AGR_Farm_Product
                                                    join e in ds.AGR_Product on d.productID equals e.id into e1
                                                    from e2 in e1.DefaultIfEmpty()
                                                    join f in ds.AGR_Expert on d.expertID equals f.id into f1
                                                    from f2 in f1.DefaultIfEmpty()
                                                    where d.farmID == a.id
                                                    select new Map_Farm_Product
                                                    {
                                                        id = d.id,
                                                        area = Convert.ToInt32(d.area).ToString(),
                                                        location = d.location,
                                                        productName = e2.name,
                                                        expertName = f2.name,
                                                        expertPortrait = f2.portrait,
                                                        values = (from g in ds.AGR_Farm_Product_Value
                                                                  where g.farmProductID == d.id
                                                                  select new Map_Farm_Product_Year_Value
                                                                  {
                                                                      year = g.year,
                                                                      id = g.id,
                                                                      production = g.production,
                                                                      value = g.value
                                                                  }).ToArray()
                                                    }).ToArray(),
                                        area = CommonMethod.areaStr2areaAssembly(a.area)
                                    };
                                break;
                            case "3":
                                x = from a in ds.AGR_Farm
                                    join b in ds.AGR_Farm_Contractor on a.contractorID equals b.id into b1
                                    from b2 in b1.DefaultIfEmpty()
                                    where districts.Contains(a.districtID) && a.id == "F002"
                                    select new Map_Farm
                                    {
                                        name = a.name,
                                        description = a.description,
                                        contractorName = b2.name,
                                        contractorIDCard = b2.IDCard,
                                        contractorInform = b2.inform,
                                        contractorPhone = b2.phone,
                                        contractorPortrait = b2.portrait,
                                        images = (from c in ds.AGR_Farm_Image
                                                  where c.farmID == a.id
                                                  select new Map_Farm_Image
                                                  {
                                                      id = c.id,
                                                      imageURL = c.imageURL
                                                  }).ToArray(),
                                        products = (from d in ds.AGR_Farm_Product
                                                    join e in ds.AGR_Product on d.productID equals e.id into e1
                                                    from e2 in e1.DefaultIfEmpty()
                                                    join f in ds.AGR_Expert on d.expertID equals f.id into f1
                                                    from f2 in f1.DefaultIfEmpty()
                                                    where d.farmID == a.id
                                                    select new Map_Farm_Product
                                                    {
                                                        id = d.id,
                                                        area = Convert.ToInt32(d.area).ToString(),
                                                        location = d.location,
                                                        productName = e2.name,
                                                        expertName = f2.name,
                                                        expertPortrait = f2.portrait,
                                                        values = (from g in ds.AGR_Farm_Product_Value
                                                                  where g.farmProductID == d.id
                                                                  select new Map_Farm_Product_Year_Value
                                                                  {
                                                                      year = g.year,
                                                                      id = g.id,
                                                                      production = g.production,
                                                                      value = g.value
                                                                  }).ToArray()
                                                    }).ToArray(),
                                        area = CommonMethod.areaStr2areaAssembly(a.area)
                                    };
                                break;
                            case "4":
                                x = from a in ds.AGR_Farm
                                    join b in ds.AGR_Farm_Contractor on a.contractorID equals b.id into b1
                                    from b2 in b1.DefaultIfEmpty()
                                    where districts.Contains(a.districtID) && a.id == "F003"
                                    select new Map_Farm
                                    {
                                        name = a.name,
                                        description = a.description,
                                        contractorName = b2.name,
                                        contractorIDCard = b2.IDCard,
                                        contractorInform = b2.inform,
                                        contractorPhone = b2.phone,
                                        contractorPortrait = b2.portrait,
                                        images = (from c in ds.AGR_Farm_Image
                                                  where c.farmID == a.id
                                                  select new Map_Farm_Image
                                                  {
                                                      id = c.id,
                                                      imageURL = c.imageURL
                                                  }).ToArray(),
                                        products = (from d in ds.AGR_Farm_Product
                                                    join e in ds.AGR_Product on d.productID equals e.id into e1
                                                    from e2 in e1.DefaultIfEmpty()
                                                    join f in ds.AGR_Expert on d.expertID equals f.id into f1
                                                    from f2 in f1.DefaultIfEmpty()
                                                    where d.farmID == a.id
                                                    select new Map_Farm_Product
                                                    {
                                                        id = d.id,
                                                        area = Convert.ToInt32(d.area).ToString(),
                                                        location = d.location,
                                                        productName = e2.name,
                                                        expertName = f2.name,
                                                        expertPortrait = f2.portrait,
                                                        values = (from g in ds.AGR_Farm_Product_Value
                                                                  where g.farmProductID == d.id
                                                                  select new Map_Farm_Product_Year_Value
                                                                  {
                                                                      year = g.year,
                                                                      id = g.id,
                                                                      production = g.production,
                                                                      value = g.value
                                                                  }).ToArray()
                                                    }).ToArray(),
                                        area = CommonMethod.areaStr2areaAssembly(a.area)
                                    };
                                break;
                            case "5":
                                x = from a in ds.AGR_Farm
                                    join b in ds.AGR_Farm_Contractor on a.contractorID equals b.id into b1
                                    from b2 in b1.DefaultIfEmpty()
                                    where districts.Contains(a.districtID) && a.id == "F004"
                                    select new Map_Farm
                                    {
                                        name = a.name,
                                        description = a.description,
                                        contractorName = b2.name,
                                        contractorIDCard = b2.IDCard,
                                        contractorInform = b2.inform,
                                        contractorPhone = b2.phone,
                                        contractorPortrait = b2.portrait,
                                        images = (from c in ds.AGR_Farm_Image
                                                  where c.farmID == a.id
                                                  select new Map_Farm_Image
                                                  {
                                                      id = c.id,
                                                      imageURL = c.imageURL
                                                  }).ToArray(),
                                        products = (from d in ds.AGR_Farm_Product
                                                    join e in ds.AGR_Product on d.productID equals e.id into e1
                                                    from e2 in e1.DefaultIfEmpty()
                                                    join f in ds.AGR_Expert on d.expertID equals f.id into f1
                                                    from f2 in f1.DefaultIfEmpty()
                                                    where d.farmID == a.id
                                                    select new Map_Farm_Product
                                                    {
                                                        id = d.id,
                                                        area = Convert.ToInt32(d.area).ToString(),
                                                        location = d.location,
                                                        productName = e2.name,
                                                        expertName = f2.name,
                                                        expertPortrait = f2.portrait,
                                                        values = (from g in ds.AGR_Farm_Product_Value
                                                                  where g.farmProductID == d.id
                                                                  select new Map_Farm_Product_Year_Value
                                                                  {
                                                                      year = g.year,
                                                                      id = g.id,
                                                                      production = g.production,
                                                                      value = g.value
                                                                  }).ToArray()
                                                    }).ToArray(),
                                        area = CommonMethod.areaStr2areaAssembly(a.area)
                                    };
                                break;
                            case "6":
                                x = from a in ds.AGR_Farm
                                    join b in ds.AGR_Farm_Contractor on a.contractorID equals b.id into b1
                                    from b2 in b1.DefaultIfEmpty()
                                    where districts.Contains(a.districtID) && a.id == "F005"
                                    select new Map_Farm
                                    {
                                        name = a.name,
                                        description = a.description,
                                        contractorName = b2.name,
                                        contractorIDCard = b2.IDCard,
                                        contractorInform = b2.inform,
                                        contractorPhone = b2.phone,
                                        contractorPortrait = b2.portrait,
                                        images = (from c in ds.AGR_Farm_Image
                                                  where c.farmID == a.id
                                                  select new Map_Farm_Image
                                                  {
                                                      id = c.id,
                                                      imageURL = c.imageURL
                                                  }).ToArray(),
                                        products = (from d in ds.AGR_Farm_Product
                                                    join e in ds.AGR_Product on d.productID equals e.id into e1
                                                    from e2 in e1.DefaultIfEmpty()
                                                    join f in ds.AGR_Expert on d.expertID equals f.id into f1
                                                    from f2 in f1.DefaultIfEmpty()
                                                    where d.farmID == a.id
                                                    select new Map_Farm_Product
                                                    {
                                                        id = d.id,
                                                        area = Convert.ToInt32(d.area).ToString(),
                                                        location = d.location,
                                                        productName = e2.name,
                                                        expertName = f2.name,
                                                        expertPortrait = f2.portrait,
                                                        values = (from g in ds.AGR_Farm_Product_Value
                                                                  where g.farmProductID == d.id
                                                                  select new Map_Farm_Product_Year_Value
                                                                  {
                                                                      year = g.year,
                                                                      id = g.id,
                                                                      production = g.production,
                                                                      value = g.value
                                                                  }).ToArray()
                                                    }).ToArray(),
                                        area = CommonMethod.areaStr2areaAssembly(a.area)
                                    };
                                break;
                            case "7":
                                x = from a in ds.AGR_Farm
                                    join b in ds.AGR_Farm_Contractor on a.contractorID equals b.id into b1
                                    from b2 in b1.DefaultIfEmpty()
                                    where districts.Contains(a.districtID) && a.id == "F006"
                                    select new Map_Farm
                                    {
                                        name = a.name,
                                        description = a.description,
                                        contractorName = b2.name,
                                        contractorIDCard = b2.IDCard,
                                        contractorInform = b2.inform,
                                        contractorPhone = b2.phone,
                                        contractorPortrait = b2.portrait,
                                        images = (from c in ds.AGR_Farm_Image
                                                  where c.farmID == a.id
                                                  select new Map_Farm_Image
                                                  {
                                                      id = c.id,
                                                      imageURL = c.imageURL
                                                  }).ToArray(),
                                        products = (from d in ds.AGR_Farm_Product
                                                    join e in ds.AGR_Product on d.productID equals e.id into e1
                                                    from e2 in e1.DefaultIfEmpty()
                                                    join f in ds.AGR_Expert on d.expertID equals f.id into f1
                                                    from f2 in f1.DefaultIfEmpty()
                                                    where d.farmID == a.id
                                                    select new Map_Farm_Product
                                                    {
                                                        id = d.id,
                                                        area = Convert.ToInt32(d.area).ToString(),
                                                        location = d.location,
                                                        productName = e2.name,
                                                        expertName = f2.name,
                                                        expertPortrait = f2.portrait,
                                                        values = (from g in ds.AGR_Farm_Product_Value
                                                                  where g.farmProductID == d.id
                                                                  select new Map_Farm_Product_Year_Value
                                                                  {
                                                                      year = g.year,
                                                                      id = g.id,
                                                                      production = g.production,
                                                                      value = g.value
                                                                  }).ToArray()
                                                    }).ToArray(),
                                        area = CommonMethod.areaStr2areaAssembly(a.area)
                                    };
                                break;
                            case "8":
                                x = from a in ds.AGR_Farm
                                    join b in ds.AGR_Farm_Contractor on a.contractorID equals b.id into b1
                                    from b2 in b1.DefaultIfEmpty()
                                    where districts.Contains(a.districtID) && a.id == "F007"
                                    select new Map_Farm
                                    {
                                        name = a.name,
                                        description = a.description,
                                        contractorName = b2.name,
                                        contractorIDCard = b2.IDCard,
                                        contractorInform = b2.inform,
                                        contractorPhone = b2.phone,
                                        contractorPortrait = b2.portrait,
                                        images = (from c in ds.AGR_Farm_Image
                                                  where c.farmID == a.id
                                                  select new Map_Farm_Image
                                                  {
                                                      id = c.id,
                                                      imageURL = c.imageURL
                                                  }).ToArray(),
                                        products = (from d in ds.AGR_Farm_Product
                                                    join e in ds.AGR_Product on d.productID equals e.id into e1
                                                    from e2 in e1.DefaultIfEmpty()
                                                    join f in ds.AGR_Expert on d.expertID equals f.id into f1
                                                    from f2 in f1.DefaultIfEmpty()
                                                    where d.farmID == a.id
                                                    select new Map_Farm_Product
                                                    {
                                                        id = d.id,
                                                        area = Convert.ToInt32(d.area).ToString(),
                                                        location = d.location,
                                                        productName = e2.name,
                                                        expertName = f2.name,
                                                        expertPortrait = f2.portrait,
                                                        values = (from g in ds.AGR_Farm_Product_Value
                                                                  where g.farmProductID == d.id
                                                                  select new Map_Farm_Product_Year_Value
                                                                  {
                                                                      year = g.year,
                                                                      id = g.id,
                                                                      production = g.production,
                                                                      value = g.value
                                                                  }).ToArray()
                                                    }).ToArray(),
                                        area = CommonMethod.areaStr2areaAssembly(a.area)
                                    };
                                break;
                            default:
                                x = from a in ds.AGR_Farm
                                    join b in ds.AGR_Farm_Contractor on a.contractorID equals b.id into b1
                                    from b2 in b1.DefaultIfEmpty()
                                    where districts.Contains(a.districtID)
                                    select new Map_Farm
                                    {
                                        name = a.name,
                                        description = a.description,
                                        contractorName = b2.name,
                                        contractorIDCard = b2.IDCard,
                                        contractorInform = b2.inform,
                                        contractorPhone = b2.phone,
                                        contractorPortrait = b2.portrait,
                                        images = (from c in ds.AGR_Farm_Image
                                                  where c.farmID == a.id
                                                  select new Map_Farm_Image
                                                  {
                                                      id = c.id,
                                                      imageURL = c.imageURL
                                                  }).ToArray(),
                                        products = (from d in ds.AGR_Farm_Product
                                                    join e in ds.AGR_Product on d.productID equals e.id into e1
                                                    from e2 in e1.DefaultIfEmpty()
                                                    join f in ds.AGR_Expert on d.expertID equals f.id into f1
                                                    from f2 in f1.DefaultIfEmpty()
                                                    where d.farmID == a.id
                                                    select new Map_Farm_Product
                                                    {
                                                        id = d.id,
                                                        area = Convert.ToInt32(d.area).ToString(),
                                                        location = d.location,
                                                        productName = e2.name,
                                                        expertName = f2.name,
                                                        expertPortrait = f2.portrait,
                                                        values = (from g in ds.AGR_Farm_Product_Value
                                                                  where g.farmProductID == d.id
                                                                  select new Map_Farm_Product_Year_Value
                                                                  {
                                                                      year = g.year,
                                                                      id = g.id,
                                                                      production = g.production,
                                                                      value = g.value
                                                                  }).ToArray()
                                                    }).ToArray(),
                                        area = CommonMethod.areaStr2areaAssembly(a.area)
                                    };
                                break;
                        }
                        returnData.data = x.ToArray();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {

                        var x = from a in ds.AGR_Farm
                                join b in ds.AGR_Farm_Contractor on a.contractorID equals b.id into b1
                                from b2 in b1.DefaultIfEmpty()
                                where districts.Contains(a.districtID)
                                select new Map_Farm
                                {
                                    name = a.name,
                                    description = a.description,
                                    contractorName = b2.name,
                                    contractorIDCard = b2.IDCard,
                                    contractorInform = b2.inform,
                                    contractorPhone = b2.phone,
                                    contractorPortrait = b2.portrait,
                                    images = (from c in ds.AGR_Farm_Image
                                              where c.farmID == a.id
                                              select new Map_Farm_Image
                                              {
                                                  id = c.id,
                                                  imageURL = c.imageURL
                                              }).ToArray(),
                                    products = (from d in ds.AGR_Farm_Product
                                                join e in ds.AGR_Product on d.productID equals e.id into e1
                                                from e2 in e1.DefaultIfEmpty()
                                                join f in ds.AGR_Expert on d.expertID equals f.id into f1
                                                from f2 in f1.DefaultIfEmpty()
                                                where d.farmID == a.id
                                                select new Map_Farm_Product
                                                {
                                                    id = d.id,
                                                    area = Convert.ToInt32(d.area).ToString(),
                                                    location = d.location,
                                                    productName = e2.name,
                                                    expertName = f2.name,
                                                    expertPortrait = f2.portrait,
                                                    values = (from g in ds.AGR_Farm_Product_Value
                                                              where g.farmProductID == d.id
                                                              select new Map_Farm_Product_Year_Value
                                                              {
                                                                  year = g.year,
                                                                  id = g.id,
                                                                  production = g.production,
                                                                  value = g.value
                                                              }).ToArray()
                                                }).ToArray(),
                                    area = CommonMethod.areaStr2areaAssembly(a.area)
                                };
                        returnData.data = x.ToArray();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;

                    }
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:没有区域信息，请重新登陆！";
                return returnData;
            }
        }

        /*------------农技人员-------------*/
        public CommonOutputT<Map_Expert[]> mapGetExpert(string districtID, string type)
        {
            CommonOutputT<Map_Expert[]> returnData = new CommonOutputT<Map_Expert[]>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    if (!string.IsNullOrEmpty(type))
                    {
                        IQueryable<Map_Expert> x = null;
                        switch (type)
                        {
                            case "1":
                                x = from a in ds.AGR_Expert
                                    select new Map_Expert
                                    {
                                        name = a.name,
                                        description = a.inform,
                                        IDCard = a.IDCard,
                                        phone = a.phone,
                                        portrait = a.portrait,
                                        farms = (from b in ds.AGR_Farm
                                                 join c in ds.AGR_Farm_Product on b.id equals c.farmID into c1
                                                 from c2 in c1.DefaultIfEmpty()
                                                 where c2.expertID == a.id && districts.Contains(b.districtID)
                                                 select new Map_Farm
                                                 {
                                                     name = b.name,
                                                     description = b.description,
                                                     area = CommonMethod.areaStr2areaAssembly(b.area)
                                                 }).ToArray()
                                    };
                                break;
                            case "2":
                                x = from a in ds.AGR_Expert
                                    where a.id == "E001"
                                    select new Map_Expert
                                    {
                                        name = a.name,
                                        description = a.inform,
                                        IDCard = a.IDCard,
                                        phone = a.phone,
                                        portrait = a.portrait,
                                        farms = (from b in ds.AGR_Farm
                                                 join c in ds.AGR_Farm_Product on b.id equals c.farmID into c1
                                                 from c2 in c1.DefaultIfEmpty()
                                                 where c2.expertID == a.id && districts.Contains(b.districtID)
                                                 select new Map_Farm
                                                 {
                                                     name = b.name,
                                                     description = b.description,
                                                     area = CommonMethod.areaStr2areaAssembly(b.area)
                                                 }).ToArray()
                                    };
                                break;
                            case "3":
                                x = from a in ds.AGR_Expert
                                    where a.id == "E002"
                                    select new Map_Expert
                                    {
                                        name = a.name,
                                        description = a.inform,
                                        IDCard = a.IDCard,
                                        phone = a.phone,
                                        portrait = a.portrait,
                                        farms = (from b in ds.AGR_Farm
                                                 join c in ds.AGR_Farm_Product on b.id equals c.farmID into c1
                                                 from c2 in c1.DefaultIfEmpty()
                                                 where c2.expertID == a.id && districts.Contains(b.districtID)
                                                 select new Map_Farm
                                                 {
                                                     name = b.name,
                                                     description = b.description,
                                                     area = CommonMethod.areaStr2areaAssembly(b.area)
                                                 }).ToArray()
                                    }; break;
                            case "4":
                                x = from a in ds.AGR_Expert
                                    where a.id == "E003"
                                    select new Map_Expert
                                    {
                                        name = a.name,
                                        description = a.inform,
                                        IDCard = a.IDCard,
                                        phone = a.phone,
                                        portrait = a.portrait,
                                        farms = (from b in ds.AGR_Farm
                                                 join c in ds.AGR_Farm_Product on b.id equals c.farmID into c1
                                                 from c2 in c1.DefaultIfEmpty()
                                                 where c2.expertID == a.id && districts.Contains(b.districtID)
                                                 select new Map_Farm
                                                 {
                                                     name = b.name,
                                                     description = b.description,
                                                     area = CommonMethod.areaStr2areaAssembly(b.area)
                                                 }).ToArray()
                                    }; break;
                            case "5":
                                x = from a in ds.AGR_Expert
                                    where a.id == "E004"
                                    select new Map_Expert
                                    {
                                        name = a.name,
                                        description = a.inform,
                                        IDCard = a.IDCard,
                                        phone = a.phone,
                                        portrait = a.portrait,
                                        farms = (from b in ds.AGR_Farm
                                                 join c in ds.AGR_Farm_Product on b.id equals c.farmID into c1
                                                 from c2 in c1.DefaultIfEmpty()
                                                 where c2.expertID == a.id && districts.Contains(b.districtID)
                                                 select new Map_Farm
                                                 {
                                                     name = b.name,
                                                     description = b.description,
                                                     area = CommonMethod.areaStr2areaAssembly(b.area)
                                                 }).ToArray()
                                    }; break;
                        }

                        returnData.data = x.ToArray();
                        foreach (var i in returnData.data)
                        {
                            List<string> list = new List<string>();
                            var farms = i.farms.ToList();
                            foreach (var j in i.farms)
                            {
                                if (!list.Contains(j.name))
                                {
                                    list.Add(j.name);
                                }
                                else
                                {
                                    farms.Remove(j);
                                }
                            }
                            i.farms = farms.ToArray();
                        }
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        var x = from a in ds.AGR_Expert
                                select new Map_Expert
                                {
                                    name = a.name,
                                    description = a.inform,
                                    IDCard = a.IDCard,
                                    phone = a.phone,
                                    portrait = a.portrait,
                                    farms = (from b in ds.AGR_Farm
                                             join c in ds.AGR_Farm_Product on b.id equals c.farmID into c1
                                             from c2 in c1.DefaultIfEmpty()
                                             where c2.expertID == a.id && districts.Contains(b.districtID)
                                             select new Map_Farm
                                             {
                                                 name = b.name,
                                                 description = b.description,
                                                 area = CommonMethod.areaStr2areaAssembly(b.area)
                                             }).ToArray()
                                };

                        returnData.data = x.ToArray();
                        foreach (var i in returnData.data)
                        {
                            List<string> list = new List<string>();
                            var farms = i.farms.ToList();
                            foreach (var j in i.farms)
                            {
                                if (!list.Contains(j.name))
                                {
                                    list.Add(j.name);
                                }
                                else
                                {
                                    farms.Remove(j);
                                }
                            }
                            i.farms = farms.ToArray();
                        }
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }

                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:获取区域信息失败！";
                return returnData;
            }
        }

        /*------------农田------------*/
        public CommonOutputT<Map_FarmLand[]> mapGetFarmLand(string districtID)
        {
            CommonOutputT<Map_FarmLand[]> returnData = new CommonOutputT<Map_FarmLand[]>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = from a in ds.AGR_FarmLand
                            join b in ds.POP_Basic on a.populationID equals b.id into b1
                            from b2 in b1.DefaultIfEmpty()
                            where districts.Contains(a.districtID)
                            select new Map_FarmLand
                            {
                                name = b2.name,
                                IDCard = b2.IDCard,
                                phone = b2.phone,
                                address = a.address,
                                farmLandID = a.farmLandID,
                                farmArea = a.farmArea,
                                product = a.product,
                                area = CommonMethod.areaStr2areaAssembly(a.area)
                            };
                    returnData.data = x.ToArray();
                    returnData.success = true;
                    returnData.message = "success";
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:没有区域信息，请重新登陆！";
                return returnData;
            }
        }

        /*------------地图上查找农田----*/
        public CommonOutputT<Map_FarmLand> mapFindFarmLand(string farmLandID)
        {
            CommonOutputT<Map_FarmLand> returnData = new CommonOutputT<Map_FarmLand>();
            if (!string.IsNullOrEmpty(farmLandID))
            {
                try
                {
                    var thisFarmLand = ds.AGR_FarmLand.SingleOrDefault(d => d.id == farmLandID);
                    var x = new Map_FarmLand();
                    if (thisFarmLand != null)
                    {
                        x.address = thisFarmLand.address;
                        x.area = CommonMethod.areaStr2areaAssembly(thisFarmLand.area);
                        x.farmLandID = thisFarmLand.farmLandID;
                        x.farmArea = thisFarmLand.farmArea;
                        x.name = ds.POP_Basic.SingleOrDefault(d => d.id == thisFarmLand.populationID).name;
                        x.IDCard = ds.POP_Basic.SingleOrDefault(d => d.id == thisFarmLand.populationID).IDCard;
                        x.phone = ds.POP_Basic.SingleOrDefault(d => d.id == thisFarmLand.populationID).phone;
                        x.product = thisFarmLand.product;
                        returnData.data = x;
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:无效农田信息！";
                        return returnData;
                    }
                }
                catch (Exception ex)
                {
                    returnData.success = false;
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:无效农田信息！";
                return returnData;
            }
        }
        #endregion

        #region 搜索
        /*-----------------搜索人口--------------------------*/
        public CommonOutputT<Map_PopulationSearch[]> mapSearchPopulation(string districtID, int offset, string search)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            CommonOutputT<Map_PopulationSearch[]> returnData = new CommonOutputT<Map_PopulationSearch[]>();
            if (!string.IsNullOrEmpty(districtID))
            {
                if (!string.IsNullOrEmpty(search))
                {
                    try
                    {
                        var x = from a in ds.POP_Basic
                                join b in ds.POP_Building on a.addressID equals b.id into b1
                                from b2 in b1.DefaultIfEmpty()
                                where a.status != 0 && districts.Contains(a.districtID) &&
                                (a.name.Contains(search) || a.IDCard.Contains(search))
                                select new Map_PopulationSearch
                                {
                                    id = a.id,
                                    IDCard = a.IDCard,
                                    name = a.name,
                                    x = (b2.x == null) ? 0 : Convert.ToDouble(b2.x),
                                    y = (b2.y == null) ? 0 : Convert.ToDouble(b2.y)
                                };
                        x = x.Skip(offset);
                        x = x.Take(10);
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.data = x.ToArray();
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = false;
                        returnData.message = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.success = true;
                    returnData.message = "未输入任何搜索信息！";
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "登陆信息已过期！请重新登陆！";
                return returnData;
            }
        }

        #endregion

        public CommonOutput fitBuilding()
        {
            CommonOutput returnData = new CommonOutput();
            try
            {
                var x = from a in ds.POP_Family
                        select a;
                foreach(var i in x)
                {
                    var building = (from a in ds.POP_Building
                                   where a.houseNum == i.bookletNum
                                   select a).ToArray();
                    if (building.Count() > 0)
                    {
                        i.addressID = building[0].id;
                    }
                }
                ds.SubmitChanges();
                returnData.success = true;
                returnData.message = "success";
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.success = false;
                returnData.message = ex.Message;
                return returnData;
            }
        }

        public CommonOutput fitAddress()
        {
            CommonOutput returnData = new CommonOutput();
            try
            {
                var x = from a in ds.POP_Basic
                        select a;
                foreach (var i in x)
                {
                    var family = (from a in ds.POP_Family
                                    where a.bookletNum == i.bookletNum
                                    select a).ToArray();
                    if (family.Count() > 0)
                    {
                        i.addressID = family[0].addressID;
                    }
                }
                ds.SubmitChanges();
                returnData.success = true;
                returnData.message = "success";
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.success = false;
                returnData.message = ex.Message;
                return returnData;
            }
        }

    }
}
