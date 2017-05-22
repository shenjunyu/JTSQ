using System;
using System.Linq;
using MLDSData;
using MLDSService.DataContracts;
using System.Web;
using MLDSService.Methods;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Dynamic”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Dynamic.svc 或 Dynamic.svc.cs，然后开始调试。
    public class Assistant : IAssistant
    {
        private static MLDSDataContext ds = new MLDSDataContext();

        #region 通讯录
        /*------------列表查看------------*/
        public PageRows<List_AddressList[]> getAddressList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_AddressList[]> returnData = new PageRows<List_AddressList[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_AddressList> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search) || a.phone.Contains(search) || a.department.Contains(search))
                                        orderby a.name ascending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department=a.department
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search) || a.phone.Contains(search) || a.department.Contains(search))
                                        orderby a.phone ascending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                case "department":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search) || a.phone.Contains(search) || a.department.Contains(search))
                                        orderby a.department ascending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                default:
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search) || a.phone.Contains(search) || a.department.Contains(search))
                                        orderby a.department ascending,a.name ascending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search) || a.phone.Contains(search) || a.department.Contains(search))
                                        orderby a.name descending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search) || a.phone.Contains(search) || a.department.Contains(search))
                                        orderby a.phone descending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                case "department":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search) || a.phone.Contains(search) || a.department.Contains(search))
                                        orderby a.department descending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                default:
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search) || a.phone.Contains(search) || a.department.Contains(search))
                                        orderby a.department descending, a.name descending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                            }
                        }
                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = true;
                        returnData.message = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    try
                    {
                        IQueryable<List_AddressList> x = from a in ds.ASS_AddressList
                                                      join b in ds.SYS_District on a.districtID equals b.id into b1
                                                      from c in b1.DefaultIfEmpty()
                                                      where districts.Contains(a.districtID) && (a.name.Contains(search) || a.phone.Contains(search) || a.department.Contains(search))
                                                      orderby a.department descending, a.name descending
                                                      select new List_AddressList
                                                      {
                                                          id = a.id,
                                                          name = a.name,
                                                          phone = a.phone,
                                                          department = a.department
                                                      };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = true;
                        returnData.message = "Error:" + ex.Message;
                        return returnData;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_AddressList> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.name ascending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.phone ascending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                case "department":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.department ascending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                default:
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) 
                                        orderby a.department ascending, a.name ascending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.name descending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.phone descending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                case "department":
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.department descending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                                default:
                                    x = from a in ds.ASS_AddressList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.department descending, a.name descending
                                        select new List_AddressList
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            department = a.department
                                        };
                                    break;
                            }
                        }

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = true;
                        returnData.message = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else//二者都为空，即启动状态
                {
                    try
                    {
                        IQueryable<List_AddressList> x = from a in ds.ASS_AddressList
                                                         join b in ds.SYS_District on a.districtID equals b.id into b1
                                                         from c in b1.DefaultIfEmpty()
                                                         where districts.Contains(a.districtID)
                                                         orderby a.department descending, a.name descending
                                                         select new List_AddressList
                                                         {
                                                             id = a.id,
                                                             name = a.name,
                                                             phone = a.phone,
                                                             department = a.department
                                                         };
                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = true;
                        returnData.message = "Error:" + ex.Message;
                        return returnData;
                    }
                }
            }
        }
        #endregion

        #region 日程管理
        /*------------查看日程------------*/
        public PageRows<ASS_Calendar[]> getCalendar(string districtID, string userID, string time)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<ASS_Calendar[]> returnData = new PageRows<ASS_Calendar[]>();
                    try
                    {
                    IQueryable<ASS_Calendar> x = from a in ds.ASS_Calendar
                                                 join b in ds.SYS_District on a.districtID equals b.id into b1
                                                 from c in b1.DefaultIfEmpty()
                                                 where districts.Contains(a.districtID)
                                                 select a;
                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.rows = x.ToArray();
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = true;
                        returnData.message = "Error:" + ex.Message;
                        return returnData;
                    }
                
            }
        /*------------新增日程------------*/
        public CommonOutput addCalendar(string districtID, string newEvent, string userID, string time)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(newEvent) || !string.IsNullOrEmpty(time))
            {
                try
                {
                    var thisGuy = ds.ASS_Calendar.SingleOrDefault(d=>d.newEvent==newEvent&&d.time==time);
                    if (thisGuy == null)
                    {
                        var x = new ASS_Calendar();
                        x.id = Guid.NewGuid().ToString();
                        x.districtID = districtID;
                        x.newEvent = newEvent;
                        x.userID = userID;
                        x.time = time;
                        x.status = 1;
                        ds.ASS_Calendar.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                    }
                    else
                    {
                        if (thisGuy.status == 0)
                        {
                            var x = new ASS_Calendar();
                            x.id = Guid.NewGuid().ToString();
                            x.districtID = districtID;
                            x.newEvent = newEvent;
                            x.userID = userID;
                            x.time = time;
                            x.status = 1;
                            ds.ASS_Calendar.InsertOnSubmit(x);
                            ds.SubmitChanges();
                            returnData.success = true;
                            returnData.message = "success";
                        }
                        else
                        {
                            returnData.success = false;
                            returnData.message = "Error:已存在此信息，请勿重复添加！";
                        }
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
                returnData.message = "Error:请填写正确信息！";
                return returnData;
            }
        }
        #endregion
    }
}
