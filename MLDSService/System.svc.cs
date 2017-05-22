using System;
using System.Linq;
using MLDSData;
using System.Collections.Generic;
using MLDSService.Methods;
using MLDSService.DataContracts;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“System”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 System.svc 或 System.svc.cs，然后开始调试。
    public class System : ISystem
    {
        private static MLDSDataContext ds = new MLDSDataContext();

        #region 系统模块
        /*-------------登录------------*/
        public LoginAccess accountLogin(string userName, string password, string district)
        {
            LoginAccess returnData = new LoginAccess();
            SYS_LoginNote x = new SYS_LoginNote();
            x.id = Guid.NewGuid().ToString();
            x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (!String.IsNullOrEmpty(userName) || !String.IsNullOrEmpty(password) || !String.IsNullOrEmpty(district))
            {
                try
                {
                    var thisGuy = ds.SYS_User.SingleOrDefault(d => d.userName == userName && d.district == district);
                    if (thisGuy != null)
                    {
                        if (thisGuy.password == password)
                        {
                            if (thisGuy.enable == "1" || thisGuy.enable == "true")
                            {
                                x.userName = userName;
                                x.name = thisGuy.name;
                                x.action = "登录成功";
                                x.districtID = district;
                                thisGuy.lastTime = x.createTime;
                                ds.SYS_LoginNote.InsertOnSubmit(x);
                                ds.SubmitChanges();
                                returnData.success = true;
                                returnData.message = "success";
                                returnData.userID = thisGuy.id;
                                returnData.districtID = district;
                                returnData.districtLevel = (int)ds.SYS_District.SingleOrDefault(d => d.id == district).districtLevel;
                                return returnData;
                            }
                            else
                            {
                                x.userName = userName;
                                x.action = "账号被禁用，请联系管理员";
                                x.districtID = district;
                                ds.SYS_LoginNote.InsertOnSubmit(x);
                                ds.SubmitChanges();
                                returnData.success = false;
                                returnData.message = "登录失败：账号被禁用，请联系管理员！";
                                return returnData;
                            }
                        }
                        else
                        {
                            x.userName = userName;
                            x.action = "密码错误";
                            x.districtID = district;
                            ds.SYS_LoginNote.InsertOnSubmit(x);
                            ds.SubmitChanges();
                            returnData.success = false;
                            returnData.message = "登录失败：密码错误！";
                            return returnData;
                        }

                    }
                    else
                    {
                        x.userName = userName;
                        x.action = "查无此人";
                        x.districtID = district;
                        ds.SYS_LoginNote.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = false;
                        returnData.message = "登录失败：查无此人！";
                        return returnData;
                    }
                }
                catch (Exception ex)
                {
                    x.userName = userName;
                    x.action = ex.ToString();
                    x.districtID = district;
                    ds.SYS_LoginNote.InsertOnSubmit(x);
                    ds.SubmitChanges();
                    returnData.success = false;
                    returnData.message = "登录失败：" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                x.userName = userName;
                x.action = "信息不完整！";
                x.districtID = district;
                ds.SYS_LoginNote.InsertOnSubmit(x);
                ds.SubmitChanges();
                returnData.success = false;
                returnData.message = "登录失败：请输入完整的信息！";
                return returnData;
            }
        }

        /*-------------验证登录信息------------*/
        public CommonOutputT<System_UserInformation> accountCheck(string userID, string authorityID, string districtID)
        {
            CommonOutputT<System_UserInformation> returnData = new CommonOutputT<System_UserInformation>();
            if (!string.IsNullOrEmpty(userID) || !string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var thisUser = ds.SYS_User.SingleOrDefault(d => d.id == userID && (d.enable == "1" || d.enable == "true"));
                    if (thisUser != null)
                    {
                        var x = new System_UserInformation();
                        x.name = thisUser.name;
                        x.lastTime = thisUser.lastTime;
                        x.portrait = thisUser.portrait;
                        x.role = (ds.SYS_Role.SingleOrDefault(d => d.id == thisUser.roleID) != null) ? ds.SYS_Role.SingleOrDefault(d => d.id == thisUser.roleID).roleName : "无效角色";
                        x.status = thisUser.enable == "true" ? "正常" : "禁用";
                        x.userName = thisUser.userName;
                        x.district = ds.SYS_District.SingleOrDefault(d => d.id == districtID).districtName;
                        returnData.data = x;
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error用户信息无效，请尝试重新登陆！";
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
                returnData.message = "Error:无登录信息，请登录后重试！";
                return returnData;
            }
        }
        #endregion
        #region 用户管理
        /*-------------获取列表------------*/
        public PageRows<List_User[]> getUser(string districtID, int offset, int limit, string order, string search, string sort)
        {
            PageRows<List_User[]> returnData = new PageRows<List_User[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {

                        IQueryable<List_User> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby a.name ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "userName":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby a.userName ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "lastTime":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby a.lastTime ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;

                                case "status":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby a.enable ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "role":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby c2.roleName ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;

                                default:
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby a.userName ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby a.name descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "userName":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby a.userName descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "lastTime":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby a.lastTime descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;

                                case "status":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby a.enable descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "role":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby c2.roleName descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;

                                default:
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                        orderby a.userName descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
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
                        returnData.success = false;
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
                else
                {
                    try
                    {
                        IQueryable<List_User> x = from a in ds.SYS_User
                                                  join b in ds.SYS_District on a.district equals b.id into b1
                                                  from b2 in b1.DefaultIfEmpty()
                                                  join c in ds.SYS_Role on a.roleID equals c.id into c1
                                                  from c2 in c1.DefaultIfEmpty()
                                                  where a.district == districtID && (a.name.Contains(search) || a.userName.Contains(search))
                                                  orderby a.userName descending
                                                  select new List_User
                                                  {
                                                      id = a.id,
                                                      district = b2.districtName,
                                                      lastTime = a.lastTime,
                                                      name = a.name,
                                                      portrait = a.portrait,
                                                      role = c2.roleName,
                                                      status = a.enable == "true" ? "正常" : "禁用",
                                                      userName = a.userName
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
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_User> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby a.name ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "userName":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby a.userName ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "lastTime":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby a.lastTime ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;

                                case "status":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby a.enable ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "role":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby c2.roleName ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;

                                default:
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby a.userName ascending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby a.name descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "userName":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby a.userName descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "lastTime":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby a.lastTime descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;

                                case "status":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby a.enable descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;
                                case "role":
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby c2.roleName descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
                                        };
                                    break;

                                default:
                                    x = from a in ds.SYS_User
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from b2 in b1.DefaultIfEmpty()
                                        join c in ds.SYS_Role on a.roleID equals c.id into c1
                                        from c2 in c1.DefaultIfEmpty()
                                        where a.district == districtID
                                        orderby a.userName descending
                                        select new List_User
                                        {
                                            id = a.id,
                                            district = b2.districtName,
                                            lastTime = a.lastTime,
                                            name = a.name,
                                            portrait = a.portrait,
                                            role = c2.roleName,
                                            status = a.enable == "true" ? "正常" : "禁用",
                                            userName = a.userName
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
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
                else//二者都为空，即启动状态
                {
                    try
                    {
                        IQueryable<List_User> x = from a in ds.SYS_User
                                                  join b in ds.SYS_District on a.district equals b.id into b1
                                                  from b2 in b1.DefaultIfEmpty()
                                                  join c in ds.SYS_Role on a.roleID equals c.id into c1
                                                  from c2 in c1.DefaultIfEmpty()
                                                  where a.district == districtID
                                                  orderby a.userName descending
                                                  select new List_User
                                                  {
                                                      id = a.id,
                                                      district = b2.districtName,
                                                      lastTime = a.lastTime,
                                                      name = a.name,
                                                      portrait = a.portrait,
                                                      role = c2.roleName,
                                                      status = a.enable == "true" ? "正常" : "禁用",
                                                      userName = a.userName
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
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
            }

        }

        #endregion

        #region 角色管理
        /*-------------列表查看------------*/
        public PageRows<List_Role[]> queryRole(string districtID, int offset, int limit, string order, string search, string sort)
        {
            PageRows<List_Role[]> returnData = new PageRows<List_Role[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {

                        IQueryable<List_Role> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "roleName":
                                    x = from a in ds.SYS_Role
                                        where a.district == districtID && a.roleName.Contains(search)
                                        orderby a.roleName ascending
                                        select new List_Role
                                        {
                                            id = a.id,
                                            roleName = a.roleName
                                        };
                                    break;
                                default:
                                    x = from a in ds.SYS_Role
                                        where a.district == districtID && a.roleName.Contains(search)
                                        orderby a.roleName ascending
                                        select new List_Role
                                        {
                                            id = a.id,
                                            roleName = a.roleName
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "roleName":
                                    x = from a in ds.SYS_Role
                                        where a.district == districtID && a.roleName.Contains(search)
                                        orderby a.roleName descending
                                        select new List_Role
                                        {
                                            id = a.id,
                                            roleName = a.roleName
                                        };
                                    break;
                                default:
                                    x = from a in ds.SYS_Role
                                        where a.district == districtID && a.roleName.Contains(search)
                                        orderby a.roleName descending
                                        select new List_Role
                                        {
                                            id = a.id,
                                            roleName = a.roleName
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
                        foreach (var i in returnData.rows)
                        {
                            var users = from a in ds.SYS_User
                                        where a.district == districtID && a.roleID == i.id
                                        select a;
                            var usersStr = string.Empty;
                            foreach (var j in users.ToArray())
                            {
                                usersStr = usersStr + ',' + j.name.ToString();
                            }
                            i.users = usersStr.Substring(1, usersStr.Length);
                        }
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = true;
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
                else
                {
                    try
                    {
                        IQueryable<List_Role> x = from a in ds.SYS_Role
                                                  where a.district == districtID && a.roleName.Contains(search)
                                                  orderby a.roleName descending
                                                  select new List_Role
                                                  {
                                                      id = a.id,
                                                      roleName = a.roleName
                                                  };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            var users = from a in ds.SYS_User
                                        where a.district == districtID && a.roleID == i.id
                                        select a;
                            var usersStr = string.Empty;
                            foreach (var j in users.ToArray())
                            {
                                usersStr = usersStr + ',' + j.name.ToString();
                            }
                            i.users = usersStr.Substring(1, usersStr.Length);
                        }
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = true;
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Role> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "roleName":
                                    x = from a in ds.SYS_Role
                                        where a.district == districtID
                                        orderby a.roleName ascending
                                        select new List_Role
                                        {
                                            id = a.id,
                                            roleName = a.roleName
                                        };
                                    break;
                                default:
                                    x = from a in ds.SYS_Role
                                        where a.district == districtID
                                        orderby a.roleName ascending
                                        select new List_Role
                                        {
                                            id = a.id,
                                            roleName = a.roleName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "roleName":
                                    x = from a in ds.SYS_Role
                                        where a.district == districtID
                                        orderby a.roleName descending
                                        select new List_Role
                                        {
                                            id = a.id,
                                            roleName = a.roleName
                                        };
                                    break;
                                default:
                                    x = from a in ds.SYS_Role
                                        where a.district == districtID
                                        orderby a.roleName descending
                                        select new List_Role
                                        {
                                            id = a.id,
                                            roleName = a.roleName
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
                        foreach (var i in returnData.rows)
                        {
                            var users = from a in ds.SYS_User
                                        where a.district == districtID && a.roleID == i.id
                                        select a;
                            var usersStr = string.Empty;
                            foreach (var j in users.ToArray())
                            {
                                usersStr = usersStr + ',' + j.name.ToString();
                            }
                            i.users = usersStr.Substring(1, usersStr.Length);
                        }
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = true;
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
                else//二者都为空，即启动状态
                {
                    try
                    {
                        IQueryable<List_Role> x = from a in ds.SYS_Role
                                                  where a.district == districtID
                                                  orderby a.roleName descending
                                                  select new List_Role
                                                  {
                                                      id = a.id,
                                                      roleName = a.roleName
                                                  };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            var users = from a in ds.SYS_User
                                        where a.district == districtID && a.roleID == i.id
                                        select a;
                            var usersStr = string.Empty;
                            foreach (var j in users.ToArray())
                            {
                                usersStr = j.name.ToString() + ',' + usersStr;
                            }
                            if (usersStr.Length <= 0)
                            {
                                i.users = null;
                            }
                            else
                            {
                                i.users = usersStr.Substring(0, usersStr.Length - 1);
                            }
                        }
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.success = true;
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
            }
        }
        #endregion

        #region 登陆日志
        /*-------------获取列表------------*/
        public PageRows<SYS_LoginNote[]> getLoginNote(string districtID, int offset, int limit, string order, string search, string sort)
        {
            PageRows<SYS_LoginNote[]> returnData = new PageRows<SYS_LoginNote[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {

                        IQueryable<SYS_LoginNote> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID && (a.name.Contains(search) || a.userName.Contains(search) || a.createTime.Contains(search))
                                        orderby a.name ascending
                                        select a;
                                    break;
                                case "userName":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID && (a.name.Contains(search) || a.userName.Contains(search) || a.createTime.Contains(search))
                                        orderby a.userName ascending
                                        select a;
                                    break;
                                case "createTime":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID && (a.name.Contains(search) || a.userName.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime ascending
                                        select a;
                                    break;

                                default:
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID && (a.name.Contains(search) || a.userName.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime ascending
                                        select a;
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID && (a.name.Contains(search) || a.userName.Contains(search) || a.createTime.Contains(search))
                                        orderby a.name descending
                                        select a;
                                    break;
                                case "userName":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID && (a.name.Contains(search) || a.userName.Contains(search) || a.createTime.Contains(search))
                                        orderby a.userName descending
                                        select a;
                                    break;
                                case "createTime":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID && (a.name.Contains(search) || a.userName.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime descending
                                        select a;
                                    break;

                                default:
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID && (a.name.Contains(search) || a.userName.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime descending
                                        select a;
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
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
                else
                {
                    try
                    {
                        IQueryable<SYS_LoginNote> x = from a in ds.SYS_LoginNote
                                                      where a.districtID == districtID && (a.name.Contains(search) || a.userName.Contains(search) || a.createTime.Contains(search))
                                                      orderby a.createTime descending
                                                      select a;

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
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<SYS_LoginNote> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID
                                        orderby a.name ascending
                                        select a;
                                    break;
                                case "userName":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID
                                        orderby a.userName ascending
                                        select a;
                                    break;
                                case "createTime":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID
                                        orderby a.createTime ascending
                                        select a;
                                    break;

                                default:
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID
                                        orderby a.createTime ascending
                                        select a;
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID
                                        orderby a.name descending
                                        select a;
                                    break;
                                case "userName":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID
                                        orderby a.userName descending
                                        select a;
                                    break;
                                case "createTime":
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID
                                        orderby a.createTime descending
                                        select a;
                                    break;

                                default:
                                    x = from a in ds.SYS_LoginNote
                                        where a.districtID == districtID
                                        orderby a.createTime descending
                                        select a;
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
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
                else//二者都为空，即启动状态
                {
                    try
                    {
                        IQueryable<SYS_LoginNote> x = from a in ds.SYS_LoginNote
                                                      where a.districtID == districtID
                                                      orderby a.createTime descending
                                                      select a;

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
                        returnData.message = "Error:" + ex;
                        return returnData;
                    }
                }
            }

        }

        #endregion


        #region 首页功能
        /*---------------镇级首页通知-----------*/
        public CommonOutputT_M<List_Index_InternalInformation[], List_Index_Meeting[]> getIndex_Z(string districtID)
        {
            CommonOutputT_M<List_Index_InternalInformation[], List_Index_Meeting[]> returnData = new CommonOutputT_M<List_Index_InternalInformation[], List_Index_Meeting[]>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = from a in ds.BUS_InternalInformation
                            where a.districtID == districtID
                            orderby a.createTime descending
                            select new List_Index_InternalInformation
                            {
                                id = a.id,
                                author = a.author,
                                cover = a.cover,
                                createTime = a.createTime,
                                peek = a.peek,
                                title = a.title,
                                type = a.type,
                                mainText = a.mainText
                            };
                    var y = from a in ds.BUS_Meeting
                            where a.districtID == districtID
                            orderby a.createTime descending
                            select new List_Index_Meeting
                            {
                                id = a.id,
                                author = a.author,
                                cover = a.cover,
                                createTime = a.createTime,
                                peek = a.peek,
                                title = a.title,
                                type = a.type,
                                mainText = a.mainText
                            };
                    x = x.Take(10);
                    y = y.Take(10);
                    returnData.data1 = x.ToArray();
                    returnData.data2 = y.ToArray();
                    foreach (var i in returnData.data1)
                    {
                        if (i.type == "1")
                        {
                            i.type = "镇内通知";
                        }
                        else if (i.type == "2")
                        {
                            i.type = "下发通知";
                        }
                    }
                    foreach (var i in returnData.data2)
                    {
                        if (i.type == "1")
                        {
                            i.type = "普通会议";
                        }
                        else if (i.type == "2")
                        {
                            i.type = "紧急会议";
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
                returnData.message = "Error:登陆信息失效，请重新登陆！";
                return returnData;
            }
        }

        /*---------------镇级首页通知-----------*/
        public CommonOutputT_M<List_Index_InternalInformation[], List_Index_Meeting[]> getIndex(string districtID)
        {
            CommonOutputT_M<List_Index_InternalInformation[], List_Index_Meeting[]> returnData = new CommonOutputT_M<List_Index_InternalInformation[], List_Index_Meeting[]>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = from a in ds.BUS_InternalInformation
                            where a.type == "2"
                            orderby a.createTime descending
                            select new List_Index_InternalInformation
                            {
                                id = a.id,
                                author = a.author,
                                cover = a.cover,
                                createTime = a.createTime,
                                peek = a.peek,
                                title = a.title,
                                type = a.type,
                                mainText = a.mainText
                            };
                    var y = from a in ds.BUS_Meeting
                            orderby a.createTime descending
                            select new List_Index_Meeting
                            {
                                id = a.id,
                                author = a.author,
                                cover = a.cover,
                                createTime = a.createTime,
                                peek = a.peek,
                                title = a.title,
                                type = a.type,
                                mainText = a.mainText
                            };
                    x = x.Take(10);
                    y = y.Take(10);
                    returnData.data1 = x.ToArray();
                    returnData.data2 = y.ToArray();
                    foreach (var i in returnData.data1)
                    {
                        if (i.type == "1")
                        {
                            i.type = "镇内通知";
                        }
                        else if (i.type == "2")
                        {
                            i.type = "下发通知";
                        }
                    }
                    foreach (var i in returnData.data2)
                    {
                        if (i.type == "1")
                        {
                            i.type = "普通会议";
                        }
                        else if (i.type == "2")
                        {
                            i.type = "紧急会议";
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
                returnData.message = "Error:登陆信息失效，请重新登陆！";
                return returnData;
            }
        }

        /*---------------首页公告详情-----------*/
        public CommonOutputT<string> getInternalInformationDetail(string id)
        {
            CommonOutputT<string> returnData = new CommonOutputT<string>();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.BUS_InternalInformation.SingleOrDefault(D => D.id == id);
                    if (x != null)
                    {
                        returnData.data = x.mainText;
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error：目标不存在！";
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
                returnData.message = "Error:请至少选择一个目标！";
                return returnData;
            }
        }


        /*---------------首页会议-----------*/
        public CommonOutputT<string> getMeetingDetail(string id)
        {
            CommonOutputT<string> returnData = new CommonOutputT<string>();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.BUS_Meeting.SingleOrDefault(D => D.id == id);
                    if (x != null)
                    {
                        returnData.data = x.mainText;
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error：目标不存在！";
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
                returnData.message = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        #endregion



        /*--------------一键匹配人口楼栋-----------*/
        //public CommonOutput matchPopulationBuilding()
        //{
        //    CommonOutput returndata = new CommonOutput();
        //    try
        //    {
        //        var x = from a in ds.POP_Basic
        //                select a;
        //        foreach(var i in x)
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returndata.success = false;
        //        returndata.message = "Error:" + ex.Message;
        //        return returndata;
        //    }
        //}
    }
}
