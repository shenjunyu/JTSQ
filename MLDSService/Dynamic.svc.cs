using System;
using System.Linq;
using MLDSData;
using MLDSService.DataContracts;
using MLDSService.DataContracts.Analysis;
using System.Web;
using MLDSService.Methods;
using cn.jpush.api;
using cn.jpush.api.push.mode;
using System.IO;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Dynamic”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Dynamic.svc 或 Dynamic.svc.cs，然后开始调试。
    public class Dynamic : IDynamic
    {
        private static MLDSDataContext ds = new MLDSDataContext();
        private static string APP_KEY = "93db9f6ee400523f66863bba";
        private static string MASTER_SECRET = "a3da2bd91ffc1516746ebb06";
        private static PushPayload p = new PushPayload();
        private static Options op = new Options();
        private static JPushClient JP = new JPushClient(APP_KEY, MASTER_SECRET);

        #region WEB
        #region 信息公告
        /*--------------列表查看-----------*/
        public PageRows<CommonInformation[]> getInformation(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<CommonInformation[]> returnData = new PageRows<CommonInformation[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {

                        IQueryable<CommonInformation> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "title":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
                                        orderby a.title ascending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                                case "author":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
                                        orderby e.name ascending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime ascending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;

                                default:
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime ascending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "title":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
                                        orderby a.title descending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                                case "author":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
                                        orderby e.name descending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime descending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;

                                default:
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime descending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                            }
                        }



                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<CommonInformation>().Length;
                        x = x.Skip<CommonInformation>(offset);
                        x = x.Take<CommonInformation>(limit);
                        returnData.rows = x.ToArray<CommonInformation>();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "通知公告";
                                    break;
                                case "2":
                                    i.type = "便民服务";
                                    break;
                                case "3":
                                    i.type = "社区特色";
                                    break;
                                case "4":
                                    i.type = "党建要闻";
                                    break;
                                default:
                                    i.type = "其他";
                                    break;
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
                else
                {
                    try
                    {
                        IQueryable<CommonInformation> x = from a in ds.DYNC_Information
                                                          join b in ds.SYS_District on a.district equals b.id into b1
                                                          from c in b1.DefaultIfEmpty()
                                                          join d in ds.SYS_User on a.author equals d.id into d1
                                                          from e in d1.DefaultIfEmpty()
                                                          where districts.Contains(a.district) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
                                                          orderby a.createTime descending
                                                          select new CommonInformation
                                                          {
                                                              id = a.id,
                                                              title = a.title,
                                                              peek = a.peek,
                                                              mainText = a.mainText,
                                                              cover = a.cover,
                                                              author = e.name,
                                                              district = c.districtName,
                                                              createTime = a.createTime,
                                                              type = a.type
                                                          };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<CommonInformation>().Length;
                        x = x.Skip<CommonInformation>(offset);
                        x = x.Take<CommonInformation>(limit);
                        returnData.rows = x.ToArray<CommonInformation>();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "通知公告";
                                    break;
                                case "2":
                                    i.type = "便民服务";
                                    break;
                                case "3":
                                    i.type = "社区特色";
                                    break;
                                case "4":
                                    i.type = "党建要闻";
                                    break;
                                default:
                                    i.type = "其他";
                                    break;
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
            else
            {
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<CommonInformation> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "title":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0"
                                        orderby a.title ascending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                                case "author":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0"
                                        orderby e.name ascending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;

                                default:
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "title":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0"
                                        orderby a.title descending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                                case "author":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0"
                                        orderby e.name descending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0"
                                        orderby a.createTime descending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;

                                default:
                                    x = from a in ds.DYNC_Information
                                        join b in ds.SYS_District on a.district equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.district) && a.status != "0"
                                        orderby a.createTime descending
                                        select new CommonInformation
                                        {
                                            id = a.id,
                                            title = a.title,
                                            peek = a.peek,
                                            mainText = a.mainText,
                                            cover = a.cover,
                                            author = e.name,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            type = a.type
                                        };
                                    break;
                            }
                        }

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<CommonInformation>().Length;
                        x = x.Skip<CommonInformation>(offset);
                        x = x.Take<CommonInformation>(limit);
                        returnData.rows = x.ToArray<CommonInformation>();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "通知公告";
                                    break;
                                case "2":
                                    i.type = "便民服务";
                                    break;
                                case "3":
                                    i.type = "社区特色";
                                    break;
                                case "4":
                                    i.type = "党建要闻";
                                    break;
                                default:
                                    i.type = "其他";
                                    break;
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
                else//二者都为空，即启动状态
                {
                    try
                    {
                        IQueryable<CommonInformation> x = from a in ds.DYNC_Information
                                                          join b in ds.SYS_District on a.district equals b.id into b1
                                                          from c in b1.DefaultIfEmpty()
                                                          join d in ds.SYS_User on a.author equals d.id into d1
                                                          from e in d1.DefaultIfEmpty()
                                                          where districts.Contains(a.district) && a.status != "0"
                                                          orderby a.createTime descending
                                                          select new CommonInformation
                                                          {
                                                              id = a.id,
                                                              title = a.title,
                                                              peek = a.peek,
                                                              mainText = a.mainText,
                                                              cover = a.cover,
                                                              author = e.name,
                                                              district = c.districtName,
                                                              createTime = a.createTime,
                                                              type = a.type
                                                          };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "通知公告";
                                    break;
                                case "2":
                                    i.type = "便民服务";
                                    break;
                                case "3":
                                    i.type = "社区特色";
                                    break;
                                case "4":
                                    i.type = "党建要闻";
                                    break;
                                default:
                                    i.type = "其他";
                                    break;
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
        /*--------------新增信息-----------*/
        public CommonOutput addInformation(string title, string type, string peek, string imageURL, string htmlContent, string userID, string districtID)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(title) || !String.IsNullOrEmpty(type) ||
                !String.IsNullOrEmpty(peek) || !String.IsNullOrEmpty(imageURL) ||
                !String.IsNullOrEmpty(htmlContent) || !String.IsNullOrEmpty(userID) ||
                !String.IsNullOrEmpty(districtID))
            {
                try
                {
                    var thisGuy = ds.SYS_User.SingleOrDefault(d => d.id == userID && d.district == districtID);
                    if (thisGuy != null)
                    {
                        var x = new DYNC_Information();
                        x.id = Guid.NewGuid().ToString();
                        x.title = title;
                        x.type = type;
                        x.peek = peek;
                        x.cover = imageURL;
                        x.createTime = DateTime.Now.ToString("yyyy/MM/dd");
                        x.status = "1";
                        x.author = userID;
                        x.district = districtID;
                        x.mainText = HttpUtility.UrlDecode(htmlContent);
                        x.mainText = x.mainText.Replace("MLDS/MLDS../../../..", "http://122.193.9.83:8079/MLDS");
                        StreamWriter SW = File.CreateText("E:\\DongShan\\MLDS\\MLDS\\Upload\\publish\\" + x.id + ".html");
                        SW.WriteLine("<!doctype html>");
                        SW.WriteLine("<html>");
                        SW.WriteLine("<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes\"  />");
                        SW.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                        SW.WriteLine("<style type=\"text/css\">");
                        SW.WriteLine("body {width: 95%;height: auto;}");
                        SW.WriteLine("img {width: 100%; position:relative;}");
                        SW.WriteLine("h2 {text-align:center}");
                        SW.WriteLine(".author {text-align:center}");
                        SW.WriteLine("</style>");
                        SW.WriteLine("</head>");
                        SW.WriteLine("<body><div style=\"margin:5px;\">");
                        SW.WriteLine("<h2>" + x.title + "</h2>");
                        SW.WriteLine("<p class=\"author\">" + ds.SYS_User.SingleOrDefault(d => d.id == x.author).name + "</p>");
                        SW.WriteLine("<HR style=\"border: 3 double\" width=\"80 % \" SIZE=3>");
                        SW.WriteLine(x.mainText);
                        SW.WriteLine("</div></body></html>");
                        SW.Close();

                        ds.DYNC_Information.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:用户信息错误，请重试！";
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
                returnData.message = "Error:输入信息不全，请重试！";
                return returnData;
            }
        }
        /*--------------编辑信息-----------*/
        public CommonOutput editInformation(string id, string title, string type, string peek, string imageURL, string htmlContent, string userID, string districtID)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(id))
            {
                if (!String.IsNullOrEmpty(title) || !String.IsNullOrEmpty(type) ||
              !String.IsNullOrEmpty(peek) || !String.IsNullOrEmpty(imageURL) ||
              !String.IsNullOrEmpty(htmlContent) || !String.IsNullOrEmpty(userID) ||
              !String.IsNullOrEmpty(districtID))
                {
                    try
                    {
                        var thisGuy = ds.SYS_User.SingleOrDefault(d => d.id == userID && d.district == districtID);
                        if (thisGuy != null)
                        {
                            var x = ds.DYNC_Information.SingleOrDefault(d => d.id == id);
                            x.title = title;
                            x.type = type;
                            x.peek = peek;
                            x.cover = imageURL;
                            x.mainText = HttpUtility.UrlDecode(htmlContent);
                            x.createTime = DateTime.Now.ToString("yyyy/MM/dd");
                            x.author = userID;
                            x.district = districtID;
                            x.mainText = x.mainText.Replace("MLDS/MLDS../../../..", "http://122.193.9.83:8079/MLDS");
                            StreamWriter SW = File.CreateText("E:\\DongShan\\MLDS\\MLDS\\upload\\publish\\" + x.id + ".html");
                            SW.WriteLine("<!doctype html>");
                            SW.WriteLine("<html>");
                            SW.WriteLine("<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes\"  />");
                            SW.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                            SW.WriteLine("<style type=\"text/css\">");
                            SW.WriteLine("body {width: 95%;height: auto;}");
                            SW.WriteLine("img {width: 100%; position:relative;}");
                            SW.WriteLine("h2 {text-align:center}");
                            SW.WriteLine(".author {text-align:center}");
                            SW.WriteLine("</style>");
                            SW.WriteLine("</head>");
                            SW.WriteLine("<body><div style=\"margin:5px;\">");
                            SW.WriteLine("<h2>" + x.title + "</h2>");
                            SW.WriteLine("<p class=\"author\">" + ds.SYS_User.SingleOrDefault(d => d.id == x.author).name + "</p>");
                            SW.WriteLine("<HR style=\"border: 3 double\" width=\"80 % \" SIZE=3>");
                            SW.WriteLine(x.mainText);
                            SW.WriteLine("</div></body></html>");
                            SW.Close();

                            ds.SubmitChanges();
                            returnData.success = true;
                            returnData.message = "success";
                            return returnData;
                        }
                        else
                        {
                            returnData.success = false;
                            returnData.message = "Error:用户信息错误，请重试！";
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
                    returnData.message = "Error:输入信息不全，请重试！";
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:未选中目标，请重试！";
                return returnData;
            }
        }
        /*--------------获取单条信息-----------*/
        public CommonOutputT<DYNC_Information> getSingleInformation(string id)
        {
            CommonOutputT<DYNC_Information> returnData = new CommonOutputT<DYNC_Information>();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.DYNC_Information.SingleOrDefault(d => d.id == id);
                    if (x != null)
                    {
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.data = x;
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:目标不存在，请重试！";
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
                returnData.message = "Error:目标选择错误，请重试！";
                return returnData;
            }
        }
        /*--------------删除信息-----------*/
        public CommonOutput deleteInformation(string id)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.DYNC_Information.SingleOrDefault(d => d.id == id);
                    if (x != null)
                    {
                        x.status = "0";
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:目标不存在，请重试！";
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
                returnData.message = "Error:目标选择错误，请重试！";
                return returnData;
            }
        }
        /*--------------批量删除信息-----------*/
        public CommonOutput deleteMultiInformation(string idStr)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(idStr))
            {
                try
                {
                    string[] ids = idStr.Split(',');
                    foreach (var id in ids)
                    {
                        var x = ds.DYNC_Information.SingleOrDefault(d => d.id == id);
                        if (x != null)
                        {
                            x.status = "0";
                        }
                        else
                        {
                            continue;
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
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:目标选择错误，请重试！";
                return returnData;
            }
        }
        /*--------------推送信息---------------*/

        #endregion

        #region 业务预约
        /*--------------列表查看-----------*/
        public PageRows<List_Appointment[]> getAppointmentList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Appointment[]> returnData = new PageRows<List_Appointment[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Appointment> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.phone ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "business":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby i.businessName ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "service":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby g.serviceName ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.processTime ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime ascending, a.processTime ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.phone descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "business":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby i.businessName descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "service":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby g.serviceName descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.processTime descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime descending, a.processTime descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
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
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "已拒绝";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_Appointment> x = from a in ds.DYNC_Appointment
                                                         join b in ds.SYS_District on a.districtID equals b.id into b1
                                                         from c in b1.DefaultIfEmpty()
                                                         join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                                         from n in m1.DefaultIfEmpty()
                                                         join d in ds.POP_Basic on n.populationID equals d.id into d1
                                                         from e in d1.DefaultIfEmpty()
                                                         join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                                         from g in f1.DefaultIfEmpty()
                                                         join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                                         from i in h1.DefaultIfEmpty()
                                                         where districts.Contains(a.districtID) && a.status != "0" && (
                                                         e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                                         a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                                         orderby a.createTime descending, a.processTime descending
                                                         select new List_Appointment
                                                         {
                                                             id = a.id,
                                                             name = e.name,
                                                             phone = e.phone,
                                                             IDCard = e.IDCard,
                                                             processTime = a.processTime,
                                                             district = c.districtName,
                                                             createTime = a.createTime,
                                                             status = a.status,
                                                             business = i.businessName,
                                                             service = g.serviceName,
                                                             remark = a.remark
                                                         };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "已拒绝";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_Appointment> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.name ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.phone ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.IDCard ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "business":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby i.businessName ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "service":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby g.serviceName ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.processTime ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby c.districtName ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending, a.processTime ascending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.name descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.phone descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.IDCard descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "business":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby i.businessName descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "service":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby g.serviceName descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.processTime descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby c.districtName descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Appointment
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from n in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on n.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending, a.processTime descending
                                        select new List_Appointment
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            business = i.businessName,
                                            service = g.serviceName,
                                            remark = a.remark
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
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "已拒绝";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_Appointment> x = from a in ds.DYNC_Appointment
                                                         join b in ds.SYS_District on a.districtID equals b.id into b1
                                                         from c in b1.DefaultIfEmpty()
                                                         join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                                         from e in d1.DefaultIfEmpty()
                                                         join f in ds.POP_Basic on e.populationID equals f.id into f1
                                                         from g in f1.DefaultIfEmpty()
                                                         join h in ds.BUS_ServiceType on a.serviceType equals h.id into h1
                                                         from i in h1.DefaultIfEmpty()
                                                         join j in ds.BUS_BusinessType on i.businessID equals j.id into j1
                                                         from k in j1.DefaultIfEmpty()
                                                         where districts.Contains(a.districtID) && a.status != "0"
                                                         orderby a.createTime descending, a.processTime descending
                                                         select new List_Appointment
                                                         {
                                                             id = a.id,
                                                             name = g.name,
                                                             phone = g.phone,
                                                             IDCard = g.IDCard,
                                                             processTime = a.processTime,
                                                             district = c.districtName,
                                                             createTime = a.createTime,
                                                             status = a.status,
                                                             business = k.businessName,
                                                             service = i.serviceName,
                                                             remark = a.remark
                                                         };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "已拒绝";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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

        /*--------------获取预约详情----------*/
        public CommonOutputT<Appointment_Detail_Answer[]> getAppointmentDetail(string id)
        {
            CommonOutputT<Appointment_Detail_Answer[]> returnData = new CommonOutputT<Appointment_Detail_Answer[]>();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.DYNC_Appointment.SingleOrDefault(d => d.id == id);
                    if (x != null)
                    {
                        returnData.data = (from a in ds.DYNC_Appointment_Answer
                                           join b in ds.SYS_User on a.userID equals b.id into b1
                                           from b2 in b1.DefaultIfEmpty()
                                           where a.appointmentID == id
                                           select new Appointment_Detail_Answer
                                           {
                                               name = b2.name,
                                               answerContent = a.answerContent,
                                               answerTime = a.answerTime
                                           }).ToArray();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:所选预约不存在！";
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

        /*--------------处理预约----------*/
        public CommonOutput processAppointment(string id, string userID, string answerContent, int type)
        {
            CommonOutput returnData = new CommonOutput();
            op.apns_production = false;
            p.platform = Platform.all();
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(userID))
            {
                try
                {
                    if (!string.IsNullOrEmpty(answerContent))
                    {
                        var y = ds.DYNC_Appointment.SingleOrDefault(d => d.id == id);
                        switch (type)
                        {
                            case 1:
                                y.status = "2";
                                break;
                            case 2:
                                y.status = "3";
                                break;
                            default: break;
                        }
                        var x = new DYNC_Appointment_Answer();
                        x.id = Guid.NewGuid().ToString();
                        x.userID = userID;
                        x.appointmentID = id;
                        x.answerContent = answerContent;
                        x.answerTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        ds.DYNC_Appointment_Answer.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        p.audience = Audience.s_alias(y.clientID);
                        p.notification = new Notification().setAlert(answerContent);
                        p.message = Message.content(answerContent);
                        JP.SendPush(p);
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:无回复信息！";
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
                returnData.message = "Error:传入数据不全！";
                return returnData;
            }
        }
        #endregion

        #region 随手拍
        /*--------------列表查看-----------*/
        public PageRows<List_PhotoTake[]> getPhotoTakeList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_PhotoTake[]> returnData = new PageRows<List_PhotoTake[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_PhotoTake> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby g.name ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby g.phone ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby a.processTime ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "supportNum":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id) ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby g.name ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby g.name descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby g.phone descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby a.createTime descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby a.processTime descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby c.districtName descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "supportNum":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id) descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                        orderby g.name descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                            }
                        }



                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_PhotoTake>().Length;
                        x = x.Skip<List_PhotoTake>(offset);
                        x = x.Take<List_PhotoTake>(limit);
                        returnData.rows = x.ToArray<List_PhotoTake>();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未处理";
                                    break;
                                case "2":
                                    i.status = "已处理";
                                    break;
                                case "3":
                                    i.status = "已退回";
                                    break;
                                case "4":
                                    i.status = "被举报";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_PhotoTake> x = from a in ds.DYNC_PhotoTake
                                                       join b in ds.SYS_District on a.districtID equals b.id into b1
                                                       from c in b1.DefaultIfEmpty()
                                                       join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                                       from e in d1.DefaultIfEmpty()
                                                       join f in ds.POP_Basic on e.populationID equals f.id into f1
                                                       from g in f1.DefaultIfEmpty()
                                                       where districts.Contains(a.districtID) && a.status != "0" && (a.photoContent.Contains(search) || g.name.Contains(search) || g.phone.Contains(search))
                                                       orderby g.name descending
                                                       select new List_PhotoTake
                                                       {
                                                           id = a.id,
                                                           name = g.name,
                                                           phone = g.phone,
                                                           processTime = a.processTime,
                                                           district = c.districtName,
                                                           createTime = a.createTime,
                                                           status = a.status,
                                                           supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                                       };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_PhotoTake>().Length;
                        x = x.Skip<List_PhotoTake>(offset);
                        x = x.Take<List_PhotoTake>(limit);
                        returnData.rows = x.ToArray<List_PhotoTake>();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未处理";
                                    break;
                                case "2":
                                    i.status = "已处理";
                                    break;
                                case "3":
                                    i.status = "已退回";
                                    break;
                                case "4":
                                    i.status = "被举报";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_PhotoTake> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby g.name ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby g.phone ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.processTime ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby c.districtName ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "supportNum":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id) ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby g.name ascending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby g.name descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby g.phone descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.processTime descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby c.districtName descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                case "supportNum":
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id) descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_PhotoTake
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby g.name descending
                                        select new List_PhotoTake
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                        };
                                    break;
                            }
                        }

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_PhotoTake>().Length;
                        x = x.Skip<List_PhotoTake>(offset);
                        x = x.Take<List_PhotoTake>(limit);
                        returnData.rows = x.ToArray<List_PhotoTake>();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未处理";
                                    break;
                                case "2":
                                    i.status = "已处理";
                                    break;
                                case "3":
                                    i.status = "已退回";
                                    break;
                                case "4":
                                    i.status = "被举报";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_PhotoTake> x = from a in ds.DYNC_PhotoTake
                                                       join b in ds.SYS_District on a.districtID equals b.id into b1
                                                       from c in b1.DefaultIfEmpty()
                                                       join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                                       from e in d1.DefaultIfEmpty()
                                                       join f in ds.POP_Basic on e.populationID equals f.id into f1
                                                       from g in f1.DefaultIfEmpty()
                                                       where districts.Contains(a.districtID) == true && a.status != "0"
                                                       orderby g.name descending
                                                       select new List_PhotoTake
                                                       {
                                                           id = a.id,
                                                           name = g.name,
                                                           phone = g.phone,
                                                           processTime = a.processTime,
                                                           district = c.districtName,
                                                           createTime = a.createTime,
                                                           status = a.status,
                                                           supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id)
                                                       };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_PhotoTake>().Length;
                        x = x.Skip<List_PhotoTake>(offset);
                        x = x.Take<List_PhotoTake>(limit);
                        returnData.rows = x.ToArray<List_PhotoTake>();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未处理";
                                    break;
                                case "2":
                                    i.status = "已处理";
                                    break;
                                case "3":
                                    i.status = "已退回";
                                    break;
                                case "4":
                                    i.status = "被举报";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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

        /*--------------获取随手拍详情-----------*/
        public PhotoTake_Detail getPhotoTakeDetail(string id)
        {
            PhotoTake_Detail returnData = new PhotoTake_Detail();
            PhotoTake_Detail_Image Data = new PhotoTake_Detail_Image();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.DYNC_PhotoTake.SingleOrDefault(d => d.id == id);
                    if (x != null)
                    {
                        Data.createTime = x.createTime;
                        var y = ds.DYNC_Client.SingleOrDefault(e => e.id == x.clientID);
                        if (y != null)
                        {
                            Data.nickName = y.nickName;

                            var z = ds.POP_Basic.SingleOrDefault(d => d.id == y.populationID);
                            if (z != null)
                            {
                                Data.name = z.name;
                                Data.phone = z.phone;
                            }
                        }
                        Data.photoTakeContent = x.photoContent;
                        Data.supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == id);
                        Data.image = (from a in ds.DYNC_PhotoTake_Image
                                      where a.phototakeID == id
                                      select a).ToArray();
                        returnData.Data = Data;
                        returnData.Answer = (from a in ds.DYNC_PhotoTake_Answer
                                             join b in ds.SYS_User on a.userID equals b.id into b1
                                             from c in b1.DefaultIfEmpty()
                                             where a.phototakeID == id
                                             select new PhotoTake_Detail_Answer
                                             {
                                                 name = c.name,
                                                 answerContent = a.answerContent,
                                                 answerTime = a.answerTime
                                             }).ToArray();
                        returnData.Comment = (from f in ds.DYNC_PhotoTake_Comment
                                              join g in ds.DYNC_Client on f.clientID equals g.id into g1
                                              from g2 in g1.DefaultIfEmpty()
                                              where f.photoTakeID == id
                                              orderby f.commentTime descending
                                              select new PhotoTake_Detail_Comment
                                              {
                                                  id = f.id,
                                                  clientID = f.clientID,
                                                  commentContent = f.commentContent,
                                                  commentTime = f.commentTime,
                                                  nickName = g2.nickName,
                                                  portrait = g2.portrait,
                                                  signature = g2.signature
                                              }).ToArray();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:随手拍信息已经失效！";
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

        /*--------------处理随手拍----------------*/
        public CommonOutput processPhotoTake(string photoTakeID, string type, string answerContent, string userID)
        {
            CommonOutput returnData = new CommonOutput();
            op.apns_production = false;
            p.platform = Platform.all();
            if (!string.IsNullOrEmpty(photoTakeID))
            {
                try
                {
                    var x = ds.DYNC_PhotoTake.SingleOrDefault(d => d.id == photoTakeID);
                    if (x != null)
                    {
                        var y = new DYNC_PhotoTake_Answer();
                        y.id = Guid.NewGuid().ToString();
                        switch (type)
                        {
                            case "1":
                                x.status = "2";//通过
                                break;
                            case "2":
                                x.status = "3";//退回
                                break;
                            case "3":
                                x.status = "2";//解除举报
                                break;
                            case "4":
                                x.status = "0";//删除
                                break;
                            default:
                                break;
                        }
                        y.phototakeID = photoTakeID;
                        y.answerContent = answerContent;
                        y.userID = userID;
                        y.answerTime = DateTime.Now.ToString();
                        ds.DYNC_PhotoTake_Answer.InsertOnSubmit(y);
                        ds.SubmitChanges();
                        p.audience = Audience.s_alias(x.clientID);
                        p.notification = new Notification().setAlert(answerContent);
                        p.message = Message.content(answerContent);
                        JP.SendPush(p);
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:随手拍不存在或已删除！";
                        return returnData;
                    }
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
                returnData.success = false;
                returnData.message = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        /*--------------删除随手拍----------------*/

        /*--------------批量删除随手拍----------------*/

        /*--------------删除随手拍评论----------------*/
        public CommonOutput deletePhotoTakeComment(string commentID)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(commentID))
            {
                try
                {
                    var x = ds.DYNC_PhotoTake_Comment.SingleOrDefault(d => d.id == commentID);
                    if (x != null)
                    {
                        ds.DYNC_PhotoTake_Comment.DeleteOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:评论不存在或已删除！";
                        return returnData;
                    }
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
                returnData.success = false;
                returnData.message = "Error:请至少选择一个目标！";
                return returnData;
            }
        }
        #endregion

        #region 建议处理
        /*----------------列表显示---------------*/
        public PageRows<List_Suggestion[]> getSuggestionList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Suggestion[]> returnData = new PageRows<List_Suggestion[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Suggestion> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.phone ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.processTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "status":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.status ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime ascending, a.processTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.phone descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.processTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "status":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.status descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime descending, a.processTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
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
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "已拒绝";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_Suggestion> x = from a in ds.DYNC_Suggestion
                                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                                        from c in b1.DefaultIfEmpty()
                                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                                        from m2 in m1.DefaultIfEmpty()
                                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                                        from e in d1.DefaultIfEmpty()
                                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2") && (
                                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                                        orderby a.createTime descending, a.processTime descending
                                                        select new List_Suggestion
                                                        {
                                                            id = a.id,
                                                            name = e.name,
                                                            phone = e.phone,
                                                            IDCard = e.IDCard,
                                                            processTime = a.processTime,
                                                            district = c.districtName,
                                                            createTime = a.createTime,
                                                            status = a.status,
                                                            suggestContent = a.suggestContent
                                                        };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "已拒绝";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_Suggestion> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby e.name ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby e.phone ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby e.IDCard ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby a.createTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby a.processTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby c.districtName ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "status":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby a.status ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby a.createTime ascending, a.processTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby e.name descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby e.phone descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby e.IDCard descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby a.createTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby a.processTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby c.districtName descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "status":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby a.status descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                        orderby a.createTime descending, a.processTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
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
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "已拒绝";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_Suggestion> x = from a in ds.DYNC_Suggestion
                                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                                        from c in b1.DefaultIfEmpty()
                                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                                        from m2 in m1.DefaultIfEmpty()
                                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                                        from e in d1.DefaultIfEmpty()
                                                        where districts.Contains(a.districtID) && (a.status == "1" || a.status == "2")
                                                        orderby a.createTime descending, a.processTime descending
                                                        select new List_Suggestion
                                                        {
                                                            id = a.id,
                                                            name = e.name,
                                                            phone = e.phone,
                                                            IDCard = e.IDCard,
                                                            processTime = a.processTime,
                                                            district = c.districtName,
                                                            createTime = a.createTime,
                                                            status = a.status,
                                                            suggestContent = a.suggestContent
                                                        };
                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "已拒绝";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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

        /*----------------查看建议详情-------------*/
        public CommonOutputT<Suggestion_Detail> getSuggestionDetail(string id)
        {
            CommonOutputT<Suggestion_Detail> returnData = new CommonOutputT<Suggestion_Detail>();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.DYNC_Suggestion.SingleOrDefault(d => d.id == id);
                    if (x != null)
                    {
                        var thisClient = ds.DYNC_Client.SingleOrDefault(d => d.id == x.clientID);
                        var thisGuy = ds.POP_Basic.SingleOrDefault(d => d.id == thisClient.populationID);
                        var suggestion = new Suggestion_Detail();
                        suggestion.id = x.id;
                        suggestion.name = thisGuy.name;
                        suggestion.IDCard = thisGuy.IDCard;
                        suggestion.nickName = thisClient.nickName;
                        suggestion.phone = thisGuy.phone;
                        suggestion.suggestContent = x.suggestContent;
                        suggestion.answers = (from a in ds.DYNC_Suggestion_Answer
                                              join b in ds.SYS_User on a.userID equals b.id into b1
                                              from b2 in b1.DefaultIfEmpty()
                                              where a.suggestionID == x.id
                                              orderby a.processTime descending
                                              select new Suggestion_Detail_Answer
                                              {
                                                  name = b2.name,
                                                  answerContent = a.answerContent,
                                                  answerTime = a.processTime
                                              }).ToArray();
                        returnData.data = suggestion;
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:选择的建议不存在或已删除！";
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

        /*----------------建议处理-------------*/
        public CommonOutput processSuggestion(string id, string userID, int type, string answerContent)
        {
            op.apns_production = false;
            p.platform = Platform.all();
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(id))
            {
                if (!string.IsNullOrEmpty(userID))
                {
                    try
                    {
                        var x = ds.DYNC_Suggestion.SingleOrDefault(d => d.id == id);
                        switch (type)
                        {
                            case 1:
                                x.status = "2";
                                break;
                            case 2:
                                x.status = "3";
                                break;
                            case 3:
                                x.status = "0";
                                break;
                            case 4:
                                x.status = "4";
                                break;
                            default: break;
                        }
                        var y = new DYNC_Suggestion_Answer();
                        y.id = Guid.NewGuid().ToString();
                        y.userID = userID;
                        y.suggestionID = id;
                        y.processTime = DateTime.Now.ToString();
                        y.answerContent = answerContent;
                        ds.DYNC_Suggestion_Answer.InsertOnSubmit(y);
                        ds.SubmitChanges();
                        p.audience = Audience.s_alias(x.clientID);
                        p.notification = new Notification().setAlert(answerContent);
                        p.message = Message.content(answerContent);
                        JP.SendPush(p);
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
                    returnData.message = "Error:您的登陆信息已过期或者没有权限这么做！";
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

        /*----------------镇级列表显示---------------*/
        public PageRows<List_Suggestion[]> getSuggestionList_Z(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Suggestion[]> returnData = new PageRows<List_Suggestion[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Suggestion> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.phone ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.processTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "status":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.status ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime ascending, a.processTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.phone descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.processTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "status":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.status descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime descending, a.processTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
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
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "镇级未受理";
                                    break;
                                case "4":
                                    i.status = "镇级已受理";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_Suggestion> x = from a in ds.DYNC_Suggestion
                                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                                        from c in b1.DefaultIfEmpty()
                                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                                        from m2 in m1.DefaultIfEmpty()
                                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                                        from e in d1.DefaultIfEmpty()
                                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4") && (
                                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                                        orderby a.createTime descending, a.processTime descending
                                                        select new List_Suggestion
                                                        {
                                                            id = a.id,
                                                            name = e.name,
                                                            phone = e.phone,
                                                            IDCard = e.IDCard,
                                                            processTime = a.processTime,
                                                            district = c.districtName,
                                                            createTime = a.createTime,
                                                            status = a.status,
                                                            suggestContent = a.suggestContent
                                                        };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "镇级未受理";
                                    break;
                                case "4":
                                    i.status = "镇级已受理";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_Suggestion> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby e.name ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby e.phone ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby e.IDCard ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby a.createTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby a.processTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby c.districtName ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "status":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby a.status ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby a.createTime ascending, a.processTime ascending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby e.name descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby e.phone descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby e.IDCard descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby a.createTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby a.processTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby c.districtName descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                case "status":
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby a.status descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Suggestion
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                        from m2 in m1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                        orderby a.createTime descending, a.processTime descending
                                        select new List_Suggestion
                                        {
                                            id = a.id,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            suggestContent = a.suggestContent
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
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "镇级未受理";
                                    break;
                                case "4":
                                    i.status = "镇级已受理";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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
                        IQueryable<List_Suggestion> x = from a in ds.DYNC_Suggestion
                                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                                        from c in b1.DefaultIfEmpty()
                                                        join m in ds.DYNC_Client on a.clientID equals m.id into m1
                                                        from m2 in m1.DefaultIfEmpty()
                                                        join d in ds.POP_Basic on m2.populationID equals d.id into d1
                                                        from e in d1.DefaultIfEmpty()
                                                        where districts.Contains(a.districtID) && (a.status == "3" || a.status == "4")
                                                        orderby a.createTime descending, a.processTime descending
                                                        select new List_Suggestion
                                                        {
                                                            id = a.id,
                                                            name = e.name,
                                                            phone = e.phone,
                                                            IDCard = e.IDCard,
                                                            processTime = a.processTime,
                                                            district = c.districtName,
                                                            createTime = a.createTime,
                                                            status = a.status,
                                                            suggestContent = a.suggestContent
                                                        };
                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.status)
                            {
                                case "1":
                                    i.status = "未受理";
                                    break;
                                case "2":
                                    i.status = "已受理";
                                    break;
                                case "3":
                                    i.status = "镇级未受理";
                                    break;
                                case "4":
                                    i.status = "镇级已受理";
                                    break;
                                default:
                                    i.status = "失效";
                                    break;
                            }
                        }
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

        #region 软件反馈
        public PageRows<List_Feedback[]> getFeedbackList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Feedback[]> returnData = new PageRows<List_Feedback[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Feedback> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby g.name ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby g.phone ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby g.IDCard ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby e.districtName ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby g.name descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby g.phone descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby a.createTime descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby g.IDCard descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby e.districtName descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                        orderby a.createTime descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
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
                        IQueryable<List_Feedback> x = from a in ds.DYNC_Feedback
                                                      join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                                      from c in b1.DefaultIfEmpty()
                                                      join d in ds.SYS_District on a.districtID equals d.id into d1
                                                      from e in d1.DefaultIfEmpty()
                                                      join f in ds.POP_Basic on c.populationID equals f.id into f1
                                                      from g in f1.DefaultIfEmpty()
                                                      where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                                      && (g.name.Contains(search) || g.phone.Contains(search) || g.IDCard.Contains(search))
                                                      orderby a.createTime descending
                                                      select new List_Feedback
                                                      {
                                                          id = a.id,
                                                          name = g.name,
                                                          phone = g.phone,
                                                          district = e.districtName,
                                                          createTime = a.createTime,
                                                          feedbackContent = a.feedbackContent,
                                                          IDCard = g.IDCard
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
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Feedback> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby g.name ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby g.phone ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby a.createTime ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby g.IDCard ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby e.districtName ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby a.createTime ascending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby g.name descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby g.phone descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby a.createTime descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby g.IDCard descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby e.districtName descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Feedback
                                        join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_District on a.districtID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on c.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                        orderby a.createTime descending
                                        select new List_Feedback
                                        {
                                            id = a.id,
                                            name = g.name,
                                            phone = g.phone,
                                            district = e.districtName,
                                            createTime = a.createTime,
                                            feedbackContent = a.feedbackContent,
                                            IDCard = g.IDCard
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
                        IQueryable<List_Feedback> x = from a in ds.DYNC_Feedback
                                                      join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                                      from c in b1.DefaultIfEmpty()
                                                      join d in ds.SYS_District on a.districtID equals d.id into d1
                                                      from e in d1.DefaultIfEmpty()
                                                      join f in ds.POP_Basic on c.populationID equals f.id into f1
                                                      from g in f1.DefaultIfEmpty()
                                                      where (districts.Contains(a.districtID) || a.districtID == e.attachTo) && a.status != 0
                                                      orderby a.createTime descending
                                                      select new List_Feedback
                                                      {
                                                          id = a.id,
                                                          name = g.name,
                                                          phone = g.phone,
                                                          district = e.districtName,
                                                          createTime = a.createTime,
                                                          feedbackContent = a.feedbackContent,
                                                          IDCard = g.IDCard
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

        #region 活动管理
        /*--------------列表查看-----------*/
        public PageRows<List_Activity[]> getActivityList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Activity[]> returnData = new PageRows<List_Activity[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Activity> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "theme":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby a.theme ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "activityTime":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby a.activityTime ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby a.address ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "participateNum":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id) ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id)
                                        };
                                    break;
                                case "supportNum":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby ds.DYNC_Activity_Support.Count(d => d.activityID == a.id) ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id)
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "theme":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby a.theme descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "activityTime":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby a.activityTime descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby a.address descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "participateNum":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id) descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id)
                                        };
                                    break;
                                case "supportNum":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby ds.DYNC_Activity_Support.Count(d => d.activityID == a.id) descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id)
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0" && (a.theme.Contains(search) ||
                                        a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                        a.address.Contains(search) || a.createTime.Contains(search))
                                        orderby a.createTime descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
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
                        IQueryable<List_Activity> x = from a in ds.DYNC_Activity
                                                      join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                                      from e in d1.DefaultIfEmpty()
                                                      join f in ds.POP_Basic on e.populationID equals f.id into f1
                                                      from g in f1.DefaultIfEmpty()
                                                      where a.status != "0" && (a.theme.Contains(search) ||
                                                      a.activityContent.Contains(search) || a.activityTime.Contains(search) ||
                                                      a.address.Contains(search) || a.createTime.Contains(search))
                                                      orderby a.createTime descending
                                                      select new List_Activity
                                                      {
                                                          id = a.id,
                                                          name = g.name,
                                                          activityContent = a.activityContent,
                                                          address = a.address,
                                                          nickName = e.nickName,
                                                          phone = g.phone,
                                                          activityTime = a.activityTime,
                                                          createTime = a.createTime,
                                                          status = a.status,
                                                          supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                                          theme = a.theme,
                                                          participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
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
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Activity> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "theme":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby a.theme ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "activityTime":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby a.activityTime ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            status = a.status,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby a.address ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "participateNum":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id) ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id)
                                        };
                                    break;
                                case "supportNum":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby ds.DYNC_Activity_Support.Count(d => d.activityID == a.id) ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id)
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "theme":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby a.theme descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "activityTime":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby a.activityTime descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby a.createTime descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby a.address descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                        };
                                    break;
                                case "participateNum":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id) descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id)
                                        };
                                    break;
                                case "supportNum":
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby ds.DYNC_Activity_Support.Count(d => d.activityID == a.id) descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            phone = g.phone,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id)
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_Activity
                                        join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on e.populationID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != "0"
                                        orderby a.createTime descending
                                        select new List_Activity
                                        {
                                            id = a.id,
                                            name = g.name,
                                            activityContent = a.activityContent,
                                            address = a.address,
                                            nickName = e.nickName,
                                            phone = g.phone,
                                            activityTime = a.activityTime,
                                            createTime = a.createTime,
                                            status = a.status,
                                            supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                            theme = a.theme,
                                            participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
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
                        IQueryable<List_Activity> x = from a in ds.DYNC_Activity
                                                      join d in ds.DYNC_Client on a.clientID equals d.id into d1
                                                      from e in d1.DefaultIfEmpty()
                                                      join f in ds.POP_Basic on e.populationID equals f.id into f1
                                                      from g in f1.DefaultIfEmpty()
                                                      where a.status != "0"
                                                      orderby a.createTime descending
                                                      select new List_Activity
                                                      {
                                                          id = a.id,
                                                          name = g.name,
                                                          activityContent = a.activityContent,
                                                          address = a.address,
                                                          activityTime = a.activityTime,
                                                          createTime = a.createTime,
                                                          nickName = e.nickName,
                                                          phone = g.phone,
                                                          status = a.status,
                                                          supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                                          theme = a.theme,
                                                          participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
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

        /*--------------获取活动详情-----------*/
        public CommonOutputT<Activity_Detail> getActivityDetail(string id)
        {
            CommonOutputT<Activity_Detail> returnData = new CommonOutputT<Activity_Detail>();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    var thisActivity = ds.DYNC_Activity.SingleOrDefault(d => d.id == id);
                    if (thisActivity != null)
                    {
                        var x = new Activity_Detail();
                        x.theme = thisActivity.theme;
                        x.activityContent = thisActivity.theme;
                        x.activityTime = thisActivity.activityTime;
                        x.address = thisActivity.address;
                        x.createTIme = thisActivity.createTime;
                        var thisClient = ds.DYNC_Client.SingleOrDefault(d => d.id == thisActivity.clientID);
                        if (thisClient != null)
                        {
                            x.nickName = thisClient.nickName;
                            x.portrait = thisClient.nickName;
                            x.signature = thisClient.signature;
                            var thisGuy = ds.POP_Basic.SingleOrDefault(d => d.id == thisClient.populationID);
                            if (thisGuy != null)
                            {
                                x.name = thisGuy.name;
                                x.phone = thisGuy.phone;
                            }
                            else
                            {
                                x.name = "未找到此人数据";
                            }
                        }
                        else
                        {
                            x.nickName = "已注销";
                        }
                        x.images = (from a in ds.DYNC_Activity_Image
                                    where a.activityID == id
                                    select new App_Activity_Image
                                    {
                                        id = a.id,
                                        imageURL = a.imageUrl
                                    }).ToArray();
                        returnData.data = x;
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:活动信息已经失效！";
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

        #region 社情民意

        /*-------------列表查看------------*/
        public PageRows<List_PeopleCaring[]> getPeopleCaring(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_PeopleCaring[]> returnData = new PageRows<List_PeopleCaring[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_PeopleCaring> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "type":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.type ascending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "details":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.details ascending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "name":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.name ascending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "type":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.type descending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "details":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.details descending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "name":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.name descending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
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
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "咨询";
                                    break;
                                case "2":
                                    i.type = "求助";
                                    break;
                                case "3":
                                    i.type = "走访";
                                    break;
                                case "4":
                                    i.type = "调解";
                                    break;
                                case "5":
                                    i.type = "投诉";
                                    break;
                                case "6":
                                    i.type = "纠纷";
                                    break;
                                case "7":
                                    i.type = "矛盾";
                                    break;
                                default:
                                    i.type = "其它";
                                    break;
                            }
                        }
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
                        IQueryable<List_PeopleCaring> x = from a in ds.DYNC_PeopleCaring
                                                          join b in ds.SYS_District on a.districtID equals b.id into b1
                                                          from c in b1.DefaultIfEmpty()
                                                          join d in ds.SYS_User on a.userID equals d.id into d1
                                                          from e in d1.DefaultIfEmpty()
                                                          where districts.Contains(a.districtID) && a.status != "0"
                                                          orderby a.createTime descending
                                                          select new List_PeopleCaring
                                                          {
                                                              id = a.id,
                                                              type = a.type,
                                                              details = a.details,
                                                              name = e.name,
                                                              createTime = a.createTime,
                                                              districtID = c.districtName
                                                          };
                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "咨询";
                                    break;
                                case "2":
                                    i.type = "求助";
                                    break;
                                case "3":
                                    i.type = "走访";
                                    break;
                                case "4":
                                    i.type = "调解";
                                    break;
                                case "5":
                                    i.type = "投诉";
                                    break;
                                case "6":
                                    i.type = "纠纷";
                                    break;
                                case "7":
                                    i.type = "矛盾";
                                    break;
                                default:
                                    i.type = "其它";
                                    break;
                            }
                        }
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
                        IQueryable<List_PeopleCaring> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "type":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "details":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "userID":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "type":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        }; ;
                                    break;
                                case "details":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "userID":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_PeopleCaring
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_PeopleCaring
                                        {
                                            id = a.id,
                                            type = a.type,
                                            details = a.details,
                                            name = e.name,
                                            createTime = a.createTime,
                                            districtID = c.districtName
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
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "咨询";
                                    break;
                                case "2":
                                    i.type = "求助";
                                    break;
                                case "3":
                                    i.type = "走访";
                                    break;
                                case "4":
                                    i.type = "调解";
                                    break;
                                case "5":
                                    i.type = "投诉";
                                    break;
                                case "6":
                                    i.type = "纠纷";
                                    break;
                                case "7":
                                    i.type = "矛盾";
                                    break;
                                default:
                                    i.type = "其它";
                                    break;
                            }
                        }
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
                        IQueryable<List_PeopleCaring> x = x = from a in ds.DYNC_PeopleCaring
                                                              join b in ds.SYS_District on a.districtID equals b.id into b1
                                                              from c in b1.DefaultIfEmpty()
                                                              join d in ds.SYS_User on a.userID equals d.id into d1
                                                              from e in d1.DefaultIfEmpty()
                                                              where districts.Contains(a.districtID) && a.status != "0"
                                                              orderby a.createTime descending
                                                              select new List_PeopleCaring
                                                              {
                                                                  id = a.id,
                                                                  type = a.type,
                                                                  details = a.details,
                                                                  name = e.name,
                                                                  createTime = a.createTime,
                                                                  districtID = c.districtName
                                                              };
                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "咨询";
                                    break;
                                case "2":
                                    i.type = "求助";
                                    break;
                                case "3":
                                    i.type = "走访";
                                    break;
                                case "4":
                                    i.type = "调解";
                                    break;
                                case "5":
                                    i.type = "投诉";
                                    break;
                                case "6":
                                    i.type = "纠纷";
                                    break;
                                case "7":
                                    i.type = "矛盾";
                                    break;
                                default:
                                    i.type = "其它";
                                    break;
                            }
                        }
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
        /*--------------新增信息-----------------*/
        public CommonOutput addPeopleCaring(string type, string details, string userID, string districtID)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(userID) || !string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var x = new DYNC_PeopleCaring();
                    var thisGuy = ds.SYS_User.SingleOrDefault(d => d.id == userID);
                    if (thisGuy != null)
                    {
                        x.id = Guid.NewGuid().ToString();
                        x.type = type;
                        x.districtID = districtID;
                        x.details = details;
                        x.userID = userID;
                        x.status = "1";
                        x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        ds.DYNC_PeopleCaring.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:用户信息错误，请重试！";
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
                returnData.message = "Error:请填写发布人信息！";
                return returnData;
            }
        }

        /*--------------编辑信息-----------*/
        public CommonOutput editPeopleCaring(string id, string type, string details, string userID, string districtID)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(id) || !string.IsNullOrEmpty(userID))
            {
                try
                {
                    DYNC_PeopleCaring x = ds.DYNC_PeopleCaring.SingleOrDefault(d => d.id == id);
                    if (x == null)
                    {
                        returnData.success = false;
                        returnData.message = "不存在该条信息";
                    }
                    x.type = type;
                    x.districtID = districtID;
                    x.details = details;
                    x.userID = userID;
                    ds.SubmitChanges();
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
                returnData.message = "Error:请填写发布人！";
                return returnData;
            }
        }

        /*-------------删除社情民意信息---------*/
        public CommonOutput deletePeopleCaring(string id)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.DYNC_PeopleCaring.SingleOrDefault(d => d.id == id);
                    if (x != null)
                    {
                        x.status = "0";
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:目标不存在，请重试！";
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
                returnData.message = "Error:目标选择错误，请重试！";
                return returnData;
            }
        }

        /*-------------批量删除社情民意信息-----*/
        public CommonOutput deleteMultiPeopleCaring(string idStr)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(idStr))
            {
                try
                {
                    string[] ids = idStr.Split(',');
                    foreach (var id in ids)
                    {
                        var x = ds.DYNC_PeopleCaring.SingleOrDefault(d => d.id == id);
                        if (x != null)
                        {
                            x.status = "0";
                        }
                        else
                        {
                            continue;
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
                    returnData.message = "Error:" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:目标选择错误，请重试！";
                return returnData;
            }
        }

        #endregion

        #region 主动巡检
        /*--------------列表查看-----------*/
        public PageRows<List_InitiativeCheck[]> getInitiativeCheckList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_InitiativeCheck[]> returnData = new PageRows<List_InitiativeCheck[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_InitiativeCheck> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "userName":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name ascending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search) || a.remark.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search) || a.remark.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "remark":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search) || a.remark.Contains(search))
                                        orderby a.remark ascending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search) || a.remark.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "userName":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name descending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search) || a.remark.Contains(search))
                                        orderby c.districtName descending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search) || a.remark.Contains(search))
                                        orderby a.createTime descending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "remark":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search) || a.remark.Contains(search))
                                        orderby a.remark descending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search) || a.remark.Contains(search))
                                        orderby a.createTime descending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
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
                        IQueryable<List_InitiativeCheck> x = from a in ds.DYNC_InitiativeCheck
                                                             join b in ds.SYS_District on a.districtID equals b.id into b1
                                                             from c in b1.DefaultIfEmpty()
                                                             join d in ds.SYS_User on a.userID equals d.id into d1
                                                             from e in d1.DefaultIfEmpty()
                                                             where districts.Contains(a.districtID) && (
                                                             e.name.Contains(search) || a.createTime.Contains(search) || c.districtName.Contains(search) || a.remark.Contains(search))
                                                             orderby a.createTime descending
                                                             select new List_InitiativeCheck
                                                             {
                                                                 id = a.id,
                                                                 district = c.districtName,
                                                                 createTime = a.createTime,
                                                                 remark = a.remark,
                                                                 userName = e.name,
                                                                 images = (from f in ds.DYNC_InitiativeCheck_Image
                                                                           where f.initiativeCheckID == a.id
                                                                           select new List_InitiativeCheck_Image
                                                                           {
                                                                               id = f.id,
                                                                               imageURL = f.imageURL
                                                                           }).ToArray()
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
                        IQueryable<List_InitiativeCheck> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "userName":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby e.name ascending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby c.districtName ascending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.createTime ascending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "remark":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.remark ascending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.createTime ascending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "userName":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby e.name descending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby c.districtName descending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.createTime descending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                case "remark":
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.remark descending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
                                        };
                                    break;
                                default:
                                    x = from a in ds.DYNC_InitiativeCheck
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.userID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.createTime descending
                                        select new List_InitiativeCheck
                                        {
                                            id = a.id,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            remark = a.remark,
                                            userName = e.name,
                                            images = (from f in ds.DYNC_InitiativeCheck_Image
                                                      where f.initiativeCheckID == a.id
                                                      select new List_InitiativeCheck_Image
                                                      {
                                                          id = f.id,
                                                          imageURL = f.imageURL
                                                      }).ToArray()
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
                        IQueryable<List_InitiativeCheck> x = from a in ds.DYNC_InitiativeCheck
                                                             join b in ds.SYS_District on a.districtID equals b.id into b1
                                                             from c in b1.DefaultIfEmpty()
                                                             join d in ds.SYS_User on a.userID equals d.id into d1
                                                             from e in d1.DefaultIfEmpty()
                                                             where districts.Contains(a.districtID)
                                                             orderby a.createTime descending
                                                             select new List_InitiativeCheck
                                                             {
                                                                 id = a.id,
                                                                 district = c.districtName,
                                                                 createTime = a.createTime,
                                                                 remark = a.remark,
                                                                 userName = e.name,
                                                                 images = (from f in ds.DYNC_InitiativeCheck_Image
                                                                           where f.initiativeCheckID == a.id
                                                                           select new List_InitiativeCheck_Image
                                                                           {
                                                                               id = f.id,
                                                                               imageURL = f.imageURL
                                                                           }).ToArray()
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

        /*--------------存储图片----------*/
        public CommonOutput saveInitiativeCheckImage(string initiativeCheckID, string imageURL)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(initiativeCheckID) && !string.IsNullOrEmpty(imageURL))
            {
                try
                {
                    var x = new DYNC_InitiativeCheck_Image();
                    x.id = Guid.NewGuid().ToString();
                    x.imageURL = imageURL;
                    x.initiativeCheckID = initiativeCheckID;
                    ds.DYNC_InitiativeCheck_Image.InsertOnSubmit(x);
                    ds.SubmitChanges();
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
                returnData.message = "输入信息不完整！";
                return returnData;
            }
        }

        /*--------------新增主动巡检------*/
        public CommonOutput addInitiativeCheck(string districtID, string initiativeCheckID, string remark, string userID)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(districtID) && !string.IsNullOrEmpty(initiativeCheckID) && !string.IsNullOrEmpty(remark))
            {
                try
                {
                    var x = new DYNC_InitiativeCheck();
                    x.id = initiativeCheckID;
                    x.remark = remark;
                    x.districtID = districtID;
                    x.userID = userID;
                    x.createTime = DateTime.Now.ToString();
                    ds.DYNC_InitiativeCheck.InsertOnSubmit(x);
                    ds.SubmitChanges();
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
                returnData.message = "Error:所给信息不全，无法创建！";
                return returnData;
            }
        }

        /*--------------获取详情-------*/
        //public CommonOutputT<>
        #endregion
        #endregion

        #region APP
        #region 系统&个人模块
        /*--------------APP登陆------------*/
        public CommonOutputAppT<App_Login> appLogin(string name, string IDCard)
        {
            CommonOutputAppT<App_Login> returnData = new CommonOutputAppT<App_Login>();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(IDCard))
            {
                try
                {
                    var thisGuy = ds.POP_Basic.SingleOrDefault(d => d.name == name && d.IDCard == IDCard && d.status != 0);
                    if (thisGuy != null)
                    {
                        var client = new App_Login();
                        var thisClient = ds.DYNC_Client.SingleOrDefault(d => d.populationID == thisGuy.id);
                        if (thisClient != null)
                        {
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            client.clinentID = thisClient.id;
                            client.districtID = thisGuy.districtID;
                            returnData.Data = client;

                            return returnData;
                        }
                        else
                        {
                            var x = new DYNC_Client();
                            x.id = Guid.NewGuid().ToString();
                            x.nickName = "未设置";
                            x.populationID = thisGuy.id;
                            x.signature = "未设置";
                            ds.DYNC_Client.InsertOnSubmit(x);
                            ds.SubmitChanges();
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            client.clinentID = x.id;
                            client.districtID = thisGuy.districtID;
                            returnData.Data = client;
                            return returnData;
                        }
                    }
                    else
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：查无此人！";
                        return returnData;
                    }
                }
                catch (Exception ex)
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error：输入信息不全！";
                return returnData;
            }
        }

        /*--------------获取个人信息---------*/
        public CommonOutputAppT<App_ClientInformation> appGetClientInformation(string clientID)
        {
            ds.SubmitChanges();
            CommonOutputAppT<App_ClientInformation> returnData = new CommonOutputAppT<App_ClientInformation>();
            if (!string.IsNullOrEmpty(clientID))
            {
                try
                {
                    var thisClient = ds.DYNC_Client.SingleOrDefault(d => d.id == clientID);
                    if (thisClient != null)
                    {
                        var thisPopulation = ds.POP_Basic.SingleOrDefault(d => d.id == thisClient.populationID);
                        if (thisPopulation != null)
                        {
                            ds.SubmitChanges();
                            var clientInformation = new App_ClientInformation();
                            clientInformation.name = thisPopulation.name;
                            clientInformation.IDCard = thisPopulation.IDCard;
                            clientInformation.nickName = thisClient.nickName;
                            clientInformation.portrait = thisClient.portrait;
                            clientInformation.signature = thisClient.signature;
                            clientInformation.district = ds.SYS_District.SingleOrDefault(d => d.id == thisPopulation.districtID).districtName;
                            returnData.Data = clientInformation;
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            return returnData;
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error：您的人口信息在信息库里不全，请您尽快联系社区工作人员！";
                            return returnData;
                        }
                    }
                    else
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：用户信息不存在，请重登陆！";
                        return returnData;
                    }
                }
                catch (Exception ex)
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error：用户信息不存在，请重登陆！";
                return returnData;
            }
        }

        /*---------------修改昵称-------------*/
        public CommonOutputApp modifyNickName(string clientID, string nickName)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(clientID))
            {
                if (!string.IsNullOrEmpty(nickName))
                {
                    try
                    {
                        var thisClient = ds.DYNC_Client.SingleOrDefault(d => d.id == clientID);
                        if (thisClient != null)
                        {
                            thisClient.nickName = nickName;
                            ds.SubmitChanges();
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            return returnData;
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error：用户信息不存在，请重登陆！";
                            return returnData;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：输入信息不全！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error：用户信息不存在，请重登陆！";
                return returnData;
            }
        }

        /*---------------修改签名-------------*/
        public CommonOutputApp modifySignature(string clientID, string signature)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(clientID))
            {
                if (!string.IsNullOrEmpty(signature))
                {
                    try
                    {
                        var thisClient = ds.DYNC_Client.SingleOrDefault(d => d.id == clientID);
                        if (thisClient != null)
                        {
                            thisClient.signature = signature;
                            ds.SubmitChanges();
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            return returnData;
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error：用户信息不存在，请重登陆！";
                            return returnData;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：输入信息不全！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error：用户信息不存在，请重登陆！";
                return returnData;
            }
        }

        /*---------------保存头像-------------*/
        public CommonOutputApp savePortrait(string clientID, string ImageUrl)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(clientID))
            {
                if (!string.IsNullOrEmpty(ImageUrl))
                {
                    try
                    {
                        var thisClient = ds.DYNC_Client.SingleOrDefault(d => d.id == clientID);
                        if (thisClient != null)
                        {
                            thisClient.portrait = ImageUrl;
                            ds.SubmitChanges();
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            return returnData;
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error：用户信息不存在，请重登陆！";
                            return returnData;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：输入信息不全！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error：用户信息不存在，请重登陆！";
                return returnData;
            }
        }
        #endregion

        #region 信息公告
        /*-------------获取信息公告---------*/
        public CommonOutputAppT<App_Information[]> appGetInformation(string type, int offset, int limit)
        {
            CommonOutputAppT<App_Information[]> returnData = new CommonOutputAppT<App_Information[]>();
            if (!string.IsNullOrEmpty(type.ToString()))
            {
                if (!string.IsNullOrEmpty(offset.ToString()) && !string.IsNullOrEmpty(limit.ToString()))
                {
                    try
                    {
                        var x = from a in ds.DYNC_Information
                                join b in ds.SYS_District on a.district equals b.id into b1
                                from c in b1.DefaultIfEmpty()
                                join d in ds.SYS_User on a.author equals d.id into d1
                                from e in d1.DefaultIfEmpty()
                                where a.status != "0" && a.type == type
                                orderby a.title ascending
                                select new App_Information
                                {
                                    id = a.id,
                                    title = a.title,
                                    peek = a.peek,
                                    mainText = a.mainText,
                                    cover = a.cover,
                                    author = e.name,
                                    createTime = a.createTime,
                                    type = a.type
                                };
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.Data = x.ToArray();
                        returnData.IsOk = 1;
                        returnData.Msg = "success";
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：请输入页码和每页数目！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error：请选择信息类型！";
                return returnData;
            }
        }
        #endregion

        #region 业务预约
        /*-------------预约业务---------*/
        public CommonOutputApp appAddAppointment(string clientID, string districtID, string serviceType, string remark)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(clientID))
            {
                if (!string.IsNullOrEmpty(districtID))
                {
                    if (!string.IsNullOrEmpty(serviceType))
                    {
                        try
                        {
                            var thisClient = ds.DYNC_Client.SingleOrDefault(d => d.id == clientID);
                            if (thisClient != null)
                            {
                                var x = new DYNC_Appointment();
                                x.id = Guid.NewGuid().ToString();
                                x.clientID = clientID;
                                x.districtID = districtID;
                                x.serviceType = serviceType;
                                x.remark = remark;
                                x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                                x.status = "1";
                                ds.DYNC_Appointment.InsertOnSubmit(x);
                                ds.SubmitChanges();
                                returnData.IsOk = 1;
                                returnData.Msg = "success";
                                return returnData;
                            }
                            else
                            {
                                returnData.IsOk = 0;
                                returnData.Msg = "Error：用户信息不存在，请重登陆！";
                                return returnData;
                            }
                        }
                        catch (Exception ex)
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error：" + ex.Message;
                            return returnData;
                        }
                    }
                    else
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：请至少选择一个办理业务！";
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：您的人口未录入本地区系统，请您前往社区办事处办理！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error：用户信息不存在，请重登陆！";
                return returnData;
            }
        }

        /*-------------我的业务列表---------*/
        public CommonOutputAppT<App_Appointment[]> appGetAppointment(string clientID, int offset, int limit)
        {
            CommonOutputAppT<App_Appointment[]> returnData = new CommonOutputAppT<App_Appointment[]>();
            if (!string.IsNullOrEmpty(offset.ToString()) && !string.IsNullOrEmpty(limit.ToString()))
            {
                try
                {
                    var x = from a in ds.DYNC_Appointment
                            join b in ds.DYNC_Client on a.clientID equals b.id into b1
                            from b2 in b1.DefaultIfEmpty()
                            join c in ds.SYS_District on a.districtID equals c.id into c1
                            from c2 in c1.DefaultIfEmpty()
                            join d in ds.BUS_ServiceType on a.serviceType equals d.id into d1
                            from d2 in d1.DefaultIfEmpty()
                            join e in ds.BUS_BusinessType on d2.businessID equals e.id into e1
                            from e2 in e1.DefaultIfEmpty()
                            where a.clientID == clientID
                            orderby a.createTime descending
                            select new App_Appointment
                            {
                                id = a.id,
                                nickName = b2.nickName,
                                portrait = b2.portrait,
                                signature = b2.signature,
                                status = a.status,
                                serviceType = d2.serviceName,
                                businessType = e2.businessName,
                                createTime = a.createTime,
                                district = c2.districtName,
                                answers = (from f in ds.DYNC_Appointment_Answer
                                           join g in ds.SYS_User on f.userID equals g.id into g1
                                           from g2 in g1.DefaultIfEmpty()
                                           where f.appointmentID == a.id
                                           orderby f.answerTime descending
                                           select new App_Appointment_Answer
                                           {
                                               id = f.id,
                                               answerContent = f.answerContent,
                                               answerTime = f.answerTime,
                                               userName = g2.name
                                           }).ToArray()
                            };
                    x = x.Skip(offset);
                    x = x.Take(limit);
                    returnData.Data = x.ToArray();
                    returnData.IsOk = 1;
                    returnData.Msg = "success";
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error：请输入页码和每页数目！";
                return returnData;
            }
        }

        /*-------------获取业务类型列表---------*/
        public CommonOutputAppT<App_BusinessType[]> appGetServiceType()
        {
            CommonOutputAppT<App_BusinessType[]> returnData = new CommonOutputAppT<App_BusinessType[]>();
            try
            {
                var x = from a in ds.BUS_BusinessType
                        select new App_BusinessType
                        {
                            id = a.id,
                            businessName = a.businessName,
                            service = (from b in ds.BUS_ServiceType
                                       where b.businessID == a.id
                                       select new App_ServiceType
                                       {
                                           id = b.id,
                                           serviceName = b.serviceName
                                       }).ToArray()
                        };
                returnData.Data = x.ToArray();
                returnData.IsOk = 1;
                returnData.Msg = "success";
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:" + ex.Message;
                return returnData;
            }
        }
        #endregion

        #region 随手拍
        /*---------------添加随手拍-------------*/
        public CommonOutputT<string> appAddPhotoTake(string clientID, string photoContent, string districtID)
        {
            CommonOutputT<string> returnData = new CommonOutputT<string>();
            if (!string.IsNullOrEmpty(clientID) || !string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var x = new DYNC_PhotoTake();
                    x.id = Guid.NewGuid().ToString();
                    x.photoContent = photoContent;
                    x.clientID = clientID;
                    x.districtID = districtID;
                    x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    x.status = "1";
                    ds.DYNC_PhotoTake.InsertOnSubmit(x);
                    ds.SubmitChanges();
                    returnData.success = true;
                    returnData.message = "success";
                    returnData.data = x.id;
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
                returnData.message = "Error:确保用户信息未过期！";
                return returnData;
            }
        }

        /*---------------存储随手拍图片-------------*/
        public CommonOutput appPhoto2PhotoTake(string photoTakeID, string imageURL)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(photoTakeID) || !string.IsNullOrEmpty(photoTakeID))
            {
                try
                {
                    var x = new DYNC_PhotoTake_Image();
                    x.id = Guid.NewGuid().ToString();
                    x.imageURL = imageURL;
                    x.phototakeID = photoTakeID;
                    ds.DYNC_PhotoTake_Image.InsertOnSubmit(x);
                    ds.SubmitChanges();
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
                returnData.message = "Error:photoTakeID或imageURL无效！";
                return returnData;
            }
        }

        /*---------------获取随手拍列表-------------*/
        public CommonOutputAppT<App_PhotoTake[]> appGetPhotoTake(string clientID, int offset, int limit, int isMine)
        {
            CommonOutputAppT<App_PhotoTake[]> returnData = new CommonOutputAppT<App_PhotoTake[]>();
            if (isMine == 1)
            {
                if (!string.IsNullOrEmpty(offset.ToString()) && !string.IsNullOrEmpty(limit.ToString()))
                {
                    try
                    {
                        var x = from a in ds.DYNC_PhotoTake
                                join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                from b2 in b1.DefaultIfEmpty()
                                where a.clientID == clientID
                                orderby a.createTime descending
                                select new App_PhotoTake
                                {
                                    id = a.id,
                                    nickName = b2.nickName,
                                    portrait = b2.portrait,
                                    signature = b2.signature,
                                    photoContent = a.photoContent,
                                    status = a.status,
                                    supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id),
                                    createTime = a.createTime,
                                    images = (from c in ds.DYNC_PhotoTake_Image
                                              where c.phototakeID == a.id
                                              select new App_PhotoTake_Image
                                              {
                                                  id = c.id,
                                                  imageURL = c.imageURL
                                              }).ToArray(),
                                    answers = (from d in ds.DYNC_PhotoTake_Answer
                                               join e in ds.SYS_User on d.userID equals e.id into e1
                                               from e2 in e1.DefaultIfEmpty()
                                               where d.phototakeID == a.id
                                               orderby d.answerTime descending
                                               select new App_PhotoTake_Answer
                                               {
                                                   id = d.id,
                                                   answerContent = d.answerContent,
                                                   answerTime = d.answerTime,
                                                   userName = e2.name
                                               }).ToArray(),
                                    comments = (from f in ds.DYNC_PhotoTake_Comment
                                                join g in ds.DYNC_Client on f.clientID equals g.id into g1
                                                from g2 in g1.DefaultIfEmpty()
                                                where f.photoTakeID == a.id
                                                orderby f.commentTime descending
                                                select new App_PhotoTake_Comment
                                                {
                                                    id = f.id,
                                                    clientID = f.clientID,
                                                    commentContent = f.commentContent,
                                                    commentTime = f.commentTime,
                                                    nickName = g2.nickName,
                                                    portrait = g2.portrait,
                                                    signature = g2.signature
                                                }).ToArray()
                                };
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.Data = x.ToArray();
                        foreach (var i in returnData.Data)
                        {
                            var m = ds.DYNC_PhotoTake_Support.SingleOrDefault(d => d.phototakeID == i.id && d.clientID == clientID);
                            if (m != null)
                            {
                                i.isSupport = true;
                            }
                            else
                            {
                                i.isSupport = false;
                            }
                        }
                        returnData.IsOk = 1;
                        returnData.Msg = "success";
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：请输入页码和每页数目！";
                    return returnData;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(offset.ToString()) && !string.IsNullOrEmpty(limit.ToString()))
                {
                    try
                    {
                        var x = from a in ds.DYNC_PhotoTake
                                join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                from b2 in b1.DefaultIfEmpty()
                                where a.status == "2" || a.status == "4"
                                orderby a.createTime descending
                                select new App_PhotoTake
                                {
                                    id = a.id,
                                    nickName = b2.nickName,
                                    photoContent = a.photoContent,
                                    status = a.status,
                                    supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == a.id),
                                    createTime = a.createTime,
                                    images = (from c in ds.DYNC_PhotoTake_Image
                                              where c.phototakeID == a.id
                                              select new App_PhotoTake_Image
                                              {
                                                  id = c.id,
                                                  imageURL = c.imageURL
                                              }).ToArray(),
                                    answers = (from d in ds.DYNC_PhotoTake_Answer
                                               join e in ds.SYS_User on d.userID equals e.id into e1
                                               from e2 in e1.DefaultIfEmpty()
                                               where d.phototakeID == a.id
                                               orderby d.answerTime descending
                                               select new App_PhotoTake_Answer
                                               {
                                                   id = d.id,
                                                   answerContent = d.answerContent,
                                                   answerTime = d.answerTime,
                                                   userName = e2.name
                                               }).ToArray(),
                                    comments = (from f in ds.DYNC_PhotoTake_Comment
                                                join g in ds.DYNC_Client on f.clientID equals g.id into g1
                                                from g2 in g1.DefaultIfEmpty()
                                                where f.photoTakeID == a.id
                                                orderby f.commentTime descending
                                                select new App_PhotoTake_Comment
                                                {
                                                    id = f.id,
                                                    clientID = f.clientID,
                                                    commentContent = f.commentContent,
                                                    commentTime = f.commentTime,
                                                    nickName = g2.nickName,
                                                    portrait = g2.portrait,
                                                    signature = g2.signature
                                                }).ToArray()
                                };
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.Data = x.ToArray();
                        foreach (var i in returnData.Data)
                        {
                            var m = ds.DYNC_PhotoTake_Support.SingleOrDefault(d => d.phototakeID == i.id && d.clientID == clientID);
                            if (m != null)
                            {
                                i.isSupport = true;
                            }
                            else
                            {
                                i.isSupport = false;
                            }
                        }
                        returnData.IsOk = 1;
                        returnData.Msg = "success";
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：请输入页码和每页数目！";
                    return returnData;
                }
            }
        }

        /*----------------获取随手拍详情-------------*/
        public CommonOutputAppT<App_PhotoTake> appGetPhotoDetail(string id, string clientID)
        {
            CommonOutputAppT<App_PhotoTake> returnData = new CommonOutputAppT<App_PhotoTake>();
            if (!string.IsNullOrEmpty(clientID))
            {
                if (!string.IsNullOrEmpty(id))
                {
                    try
                    {
                        var x = ds.DYNC_PhotoTake.SingleOrDefault(d => d.id == id);
                        if (x != null)
                        {
                            var thisClient = ds.DYNC_Client.SingleOrDefault(d => d.id == x.clientID);
                            App_PhotoTake y = new App_PhotoTake();
                            y.id = id;
                            y.nickName = thisClient.nickName;
                            y.portrait = thisClient.portrait;
                            y.signature = thisClient.signature;
                            y.photoContent = x.photoContent;
                            y.status = x.status;
                            y.supportNum = ds.DYNC_PhotoTake_Support.Count(d => d.phototakeID == x.id);
                            y.createTime = x.createTime;
                            y.images = (from c in ds.DYNC_PhotoTake_Image
                                        where c.phototakeID == x.id
                                        select new App_PhotoTake_Image
                                        {
                                            id = c.id,
                                            imageURL = c.imageURL
                                        }).ToArray();
                            y.answers = (from d in ds.DYNC_PhotoTake_Answer
                                         join e in ds.SYS_User on d.userID equals e.id into e1
                                         from e2 in e1.DefaultIfEmpty()
                                         where d.phototakeID == x.id
                                         orderby d.answerTime descending
                                         select new App_PhotoTake_Answer
                                         {
                                             id = d.id,
                                             answerContent = d.answerContent,
                                             answerTime = d.answerTime,
                                             userName = e2.name
                                         }).ToArray();
                            y.comments = (from f in ds.DYNC_PhotoTake_Comment
                                          join g in ds.DYNC_Client on f.clientID equals g.id into g1
                                          from g2 in g1.DefaultIfEmpty()
                                          where f.photoTakeID == x.id
                                          orderby f.commentTime descending
                                          select new App_PhotoTake_Comment
                                          {
                                              id = f.id,
                                              clientID = f.clientID,
                                              commentContent = f.commentContent,
                                              commentTime = f.commentTime,
                                              nickName = g2.nickName,
                                              portrait = g2.portrait,
                                              signature = g2.signature
                                          }).ToArray();
                            returnData.Data = y;
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            return returnData;
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error:所选目标不存在！";
                            return returnData;
                        }

                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:请至少选择一个目标！";
                    return returnData;
                }

            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:没有登陆信息！";
                return returnData;
            }
        }

        /*----------------手动取消已发送的随手拍---------------*/
        public CommonOutputApp appCancelPhotoTake(string photoTakeID, string clientID)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(photoTakeID))
            {
                if (!string.IsNullOrEmpty(clientID))
                {
                    try
                    {
                        var x = ds.DYNC_PhotoTake.SingleOrDefault(d => d.id == photoTakeID);
                        if (x != null)
                        {
                            if (x.clientID == clientID)
                            {
                                x.status = "0";
                                ds.SubmitChanges();
                                returnData.IsOk = 1;
                                returnData.Msg = "success";
                                return returnData;
                            }
                            else
                            {
                                returnData.IsOk = 0;
                                returnData.Msg = "Error:您无权这么做！";
                                return returnData;
                            }
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error:所选随手拍不存在！";
                            return returnData;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:缺少登陆信息，请您重新登陆！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        /*----------------随手拍点赞/取消点赞---------------*/
        public CommonOutputApp appSupportPhotoTake(string photoTakeID, string clientID)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(photoTakeID))
            {
                if (!string.IsNullOrEmpty(clientID))
                {
                    try
                    {
                        var x = ds.DYNC_PhotoTake.SingleOrDefault(d => d.id == photoTakeID);
                        if (x != null)
                        {
                            var y = ds.DYNC_PhotoTake_Support.SingleOrDefault(d => d.phototakeID == photoTakeID && d.clientID == clientID);
                            if (y == null)
                            {
                                //点赞
                                var z = new DYNC_PhotoTake_Support();
                                z.id = Guid.NewGuid().ToString();
                                z.clientID = clientID;
                                z.phototakeID = photoTakeID;
                                ds.DYNC_PhotoTake_Support.InsertOnSubmit(z);
                            }
                            else
                            {
                                //取消点赞
                                ds.DYNC_PhotoTake_Support.DeleteOnSubmit(y);
                            }
                            ds.SubmitChanges();
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            return returnData;
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error:所选随手拍不存在！";
                            return returnData;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:缺少登陆信息，请您重新登陆！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        /*----------------举报随手拍---------------*/
        public CommonOutputApp appInformPhotoTake(string photoTakeID, string clientID)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(photoTakeID))
            {
                if (!string.IsNullOrEmpty(clientID))
                {
                    try
                    {
                        var x = ds.DYNC_PhotoTake.SingleOrDefault(d => d.id == photoTakeID);
                        if (x != null)
                        {
                            if (x.clientID == clientID)
                            {
                                x.status = "4";
                                ds.SubmitChanges();
                                returnData.IsOk = 1;
                                returnData.Msg = "success";
                                return returnData;
                            }
                            else
                            {
                                returnData.IsOk = 0;
                                returnData.Msg = "Error:您无权这么做！";
                                return returnData;
                            }
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error:所选随手拍不存在！";
                            return returnData;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:缺少登陆信息，请您重新登陆！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        /*----------------随手拍评论---------------*/
        public CommonOutputApp appCommentPhotoTake(string photoTakeID, string clientID, string commentContent)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(photoTakeID))
            {
                if (!string.IsNullOrEmpty(clientID))
                {
                    if (!string.IsNullOrEmpty(commentContent))
                    {
                        try
                        {
                            var x = ds.DYNC_PhotoTake.SingleOrDefault(d => d.id == photoTakeID);
                            if (x != null)
                            {
                                if (x.clientID == clientID)
                                {
                                    var y = new DYNC_PhotoTake_Comment();
                                    y.id = Guid.NewGuid().ToString();
                                    y.photoTakeID = photoTakeID;
                                    y.commentContent = commentContent;
                                    y.clientID = clientID;
                                    y.commentTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                                    ds.DYNC_PhotoTake_Comment.InsertOnSubmit(y);
                                    ds.SubmitChanges();
                                    returnData.IsOk = 1;
                                    returnData.Msg = "success";
                                    return returnData;
                                }
                                else
                                {
                                    returnData.IsOk = 0;
                                    returnData.Msg = "Error:您无权这么做！";
                                    return returnData;
                                }
                            }
                            else
                            {
                                returnData.IsOk = 0;
                                returnData.Msg = "Error:所选随手拍不存在！";
                                return returnData;
                            }
                        }
                        catch (Exception ex)
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error:" + ex.Message;
                            return returnData;
                        }
                    }
                    else
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:没有输入任何评论信息！";
                        return returnData;
                    }

                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:缺少登陆信息，请您重新登陆！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        /*----------------取消评论---------------*/
        public CommonOutputApp appCancelCommentPhotoTake(string commentID, string clientID)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(commentID))
            {
                if (!string.IsNullOrEmpty(clientID))
                {
                    try
                    {
                        var x = ds.DYNC_PhotoTake_Comment.SingleOrDefault(d => d.id == commentID);
                        if (x != null)
                        {
                            if (x.clientID == clientID)
                            {
                                ds.DYNC_PhotoTake_Comment.DeleteOnSubmit(x);
                                ds.SubmitChanges();
                                returnData.IsOk = 1;
                                returnData.Msg = "success";
                                return returnData;
                            }
                            else
                            {
                                returnData.IsOk = 0;
                                returnData.Msg = "Error:您无权这么做！";
                                return returnData;
                            }
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error:所选评论不存在或已删除！";
                            return returnData;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:缺少登陆信息，请您重新登陆！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        #endregion

        #region 提建议
        /*---------------添加建议-------------*/
        public CommonOutputApp appAddSuggestion(string districtID, string clientID, string suggestContent)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(districtID) && !string.IsNullOrEmpty(clientID))
            {
                if (!string.IsNullOrEmpty(suggestContent))
                {
                    try
                    {
                        var x = new DYNC_Suggestion();
                        x.id = Guid.NewGuid().ToString();
                        x.clientID = clientID;
                        x.districtID = districtID;
                        x.suggestContent = suggestContent;
                        x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        x.status = "1";
                        ds.DYNC_Suggestion.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.IsOk = 1;
                        returnData.Msg = "success";
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:输入了空的建议信息！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:登陆信息已失效，请重新登陆！";
                return returnData;
            }
        }

        /*---------------查看我的建议列表--------------*/
        public CommonOutputAppT<App_Suggestion[]> appGetSuggestion(string clientID, int offset, int limit)
        {
            CommonOutputAppT<App_Suggestion[]> returnData = new CommonOutputAppT<App_Suggestion[]>();
            if (!string.IsNullOrEmpty(offset.ToString()) && !string.IsNullOrEmpty(limit.ToString()))
            {
                try
                {
                    var x = from a in ds.DYNC_Suggestion
                            join b in ds.DYNC_Client on a.clientID equals b.id into b1
                            from b2 in b1.DefaultIfEmpty()
                            join c in ds.SYS_District on a.districtID equals c.id into c1
                            from c2 in c1.DefaultIfEmpty()
                            where a.clientID == clientID
                            orderby a.createTime descending
                            select new App_Suggestion
                            {
                                id = a.id,
                                nickName = b2.nickName,
                                portrait = b2.portrait,
                                signature = b2.signature,
                                status = a.status,
                                suggestContent = a.suggestContent,
                                createTime = a.createTime,
                                district = c2.districtName,
                                answers = (from f in ds.DYNC_Suggestion_Answer
                                           join g in ds.SYS_User on f.userID equals g.id into g1
                                           from g2 in g1.DefaultIfEmpty()
                                           where f.suggestionID == a.id
                                           orderby f.processTime descending
                                           select new App_Suggestion_Answer
                                           {
                                               id = f.id,
                                               answerContent = f.answerContent,
                                               answerTime = f.processTime,
                                               userName = g2.name
                                           }).ToArray()
                            };
                    x = x.Skip(offset);
                    x = x.Take(limit);
                    returnData.Data = x.ToArray();
                    returnData.IsOk = 1;
                    returnData.Msg = "success";
                    return returnData;
                }
                catch (Exception ex)
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：" + ex.Message;
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error：请输入页码和每页数目！";
                return returnData;
            }
        }
        #endregion

        #region 软件反馈
        /*---------------新增反馈----------------*/
        public CommonOutputApp appAddFeedback(string clientID, string districtID, string feedbackContent)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(clientID))
            {
                if (!string.IsNullOrEmpty(feedbackContent))
                {
                    try
                    {
                        var x = new DYNC_Feedback();
                        x.id = Guid.NewGuid().ToString();
                        x.clientID = clientID;
                        x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        x.districtID = districtID;
                        x.feedbackContent = feedbackContent;
                        x.status = 1;
                        ds.DYNC_Feedback.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.IsOk = 1;
                        returnData.Msg = "success";
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:上传失败，没有信息输入！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:您的登录信息已过期，请重新登陆！";
                return returnData;
            }
        }
        #endregion

        #region 社区活动
        /*-------------添加活动----------*/
        public CommonOutputT<string> appAddActivity(string clientID, string theme, string activityContent, string activityTime, string address, string phone)
        {
            CommonOutputT<string> returnData = new CommonOutputT<string>();
            if (!string.IsNullOrEmpty(clientID))
            {
                if (!string.IsNullOrEmpty(theme) && !string.IsNullOrEmpty(activityContent))
                {
                    try
                    {
                        var x = new DYNC_Activity();
                        x.id = Guid.NewGuid().ToString();
                        x.activityContent = activityContent;
                        x.clientID = clientID;
                        x.activityTime = activityTime;
                        x.theme = theme;
                        x.address = address;
                        x.phone = phone;
                        x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        x.status = "1";
                        ds.DYNC_Activity.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.data = x.id;
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
                    returnData.message = "Error:无效的活动信息！";
                    return returnData;
                }
            }
            else
            {
                returnData.success = false;
                returnData.message = "Error:确保用户信息未过期！";
                return returnData;
            }
        }

        /*---------------存储活动图片-------------*/
        public CommonOutput appPhoto2Activity(string ActivityID, string imageURL)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(ActivityID) || !string.IsNullOrEmpty(imageURL))
            {
                try
                {
                    var x = new DYNC_Activity_Image();
                    x.id = Guid.NewGuid().ToString();
                    x.imageUrl = imageURL;
                    x.activityID = ActivityID;
                    ds.DYNC_Activity_Image.InsertOnSubmit(x);
                    ds.SubmitChanges();
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
                returnData.message = "Error:photoTakeID或imageURL无效！";
                return returnData;
            }
        }

        /*-------------查看活动（我的）列表----------*/
        public CommonOutputAppT<App_Activity[]> appGetActivity(string clientID, int offset, int limit, int isMine)
        {
            CommonOutputAppT<App_Activity[]> returnData = new CommonOutputAppT<App_Activity[]>();
            if (isMine == 1)
            {
                if (!string.IsNullOrEmpty(offset.ToString()) && !string.IsNullOrEmpty(limit.ToString()))
                {
                    try
                    {
                        var x = from a in ds.DYNC_Activity
                                join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                from b2 in b1.DefaultIfEmpty()
                                where a.clientID == clientID
                                orderby a.createTime descending
                                select new App_Activity
                                {
                                    id = a.id,
                                    nickName = b2.nickName,
                                    portrait = b2.portrait,
                                    signature = b2.signature,
                                    theme = a.theme,
                                    phone = a.phone,
                                    activityContent = a.activityContent,
                                    activityTime = a.activityTime,
                                    address = a.address,
                                    status = a.status,
                                    supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                    participateNum=ds.DYNC_Activity_Participator.Count(d=>d.activityID==a.id),
                                    createTime = a.createTime,
                                    images = (from c in ds.DYNC_Activity_Image
                                              where c.activityID == a.id
                                              select new App_Activity_Image
                                              {
                                                  id = c.id,
                                                  imageURL = c.imageUrl
                                              }).ToArray(),
                                    participators = (from f in ds.DYNC_Activity_Participator
                                                     join g in ds.DYNC_Client on f.participatorID equals g.id into g1
                                                     from g2 in g1.DefaultIfEmpty()
                                                     where f.activityID == a.id
                                                     select new App_Activity_Participator
                                                     {
                                                         id = f.id,
                                                         clientID = f.participatorID,
                                                         nickName = g2.nickName,
                                                         portrait = g2.portrait,
                                                         signature = g2.signature
                                                     }).ToArray()
                                };
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.Data = x.ToArray();
                        foreach (var i in returnData.Data)
                        {
                            var m = ds.DYNC_Activity_Support.SingleOrDefault(d => d.activityID == i.id && d.clientID == clientID);
                            var n = ds.DYNC_Activity_Participator.SingleOrDefault(d => d.activityID == i.id && d.participatorID == clientID);
                            if (m != null)
                            {
                                i.isSupport = true;
                            }
                            else
                            {
                                i.isSupport = false;
                            }
                            if (n != null)
                            {
                                i.isParticipate = true;
                            }
                            else
                            {
                                i.isParticipate = false;
                            }
                        }
                        returnData.IsOk = 1;
                        returnData.Msg = "success";
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：请输入页码和每页数目！";
                    return returnData;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(offset.ToString()) && !string.IsNullOrEmpty(limit.ToString()))
                {
                    try
                    {
                        var x = from a in ds.DYNC_Activity
                                join b in ds.DYNC_Client on a.clientID equals b.id into b1
                                from b2 in b1.DefaultIfEmpty()
                                where a.status != "0"
                                orderby a.createTime descending
                                select new App_Activity
                                {
                                    id = a.id,
                                    nickName = b2.nickName,
                                    portrait = b2.portrait,
                                    signature = b2.signature,
                                    theme = a.theme,
                                    phone = a.phone,
                                    activityContent = a.activityContent,
                                    activityTime = a.activityTime,
                                    status = a.status,
                                    address = a.address,
                                    supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == a.id),
                                    participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == a.id),
                                    createTime = a.createTime,
                                    images = (from c in ds.DYNC_Activity_Image
                                              where c.activityID == a.id
                                              select new App_Activity_Image
                                              {
                                                  id = c.id,
                                                  imageURL = c.imageUrl
                                              }).ToArray(),
                                    participators = (from f in ds.DYNC_Activity_Participator
                                                     join g in ds.DYNC_Client on f.participatorID equals g.id into g1
                                                     from g2 in g1.DefaultIfEmpty()
                                                     where f.activityID == a.id
                                                     select new App_Activity_Participator
                                                     {
                                                         id = f.id,
                                                         clientID = f.participatorID,
                                                         nickName = g2.nickName,
                                                         portrait = g2.portrait,
                                                         signature = g2.signature
                                                     }).ToArray()
                                };
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.Data = x.ToArray();
                        foreach (var i in returnData.Data)
                        {
                            var m = ds.DYNC_Activity_Support.SingleOrDefault(d => d.activityID == i.id && d.clientID == clientID);
                            var n = ds.DYNC_Activity_Participator.SingleOrDefault(d => d.activityID == i.id && d.participatorID == clientID);
                            if (m != null)
                            {
                                i.isSupport = true;
                            }
                            else
                            {
                                i.isSupport = false;
                            }
                            if (n != null)
                            {
                                i.isParticipate = true;
                            }
                            else
                            {
                                i.isParticipate = false;
                            }
                        }
                        returnData.IsOk = 1;
                        returnData.Msg = "success";
                        return returnData;
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error：" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error：请输入页码和每页数目！";
                    return returnData;
                }
            }
        }

        /*-------------查看活动详情----------*/
        public CommonOutputAppT<App_Activity> appGetActivityDetail(string id, string clientID)
        {
            ds.SubmitChanges();
            CommonOutputAppT<App_Activity> returnData = new CommonOutputAppT<App_Activity>();
            if (!string.IsNullOrEmpty(clientID))
            {
                if (!string.IsNullOrEmpty(id))
                {
                    try
                    {
                        var x = ds.DYNC_Activity.SingleOrDefault(d => d.id == id);
                        if (x != null)
                        {
                            var thisClient = ds.DYNC_Client.SingleOrDefault(d => d.id == x.clientID);
                            App_Activity y = new App_Activity();
                            y.id = id;
                            y.nickName = thisClient.nickName;
                            y.portrait = thisClient.portrait;
                            y.signature = thisClient.signature;
                            y.activityContent = x.activityContent;
                            y.activityTime = x.activityTime;
                            y.address = x.address;
                            y.phone = x.phone;
                            y.createTime = x.createTime;
                            y.status = x.status;
                            y.supportNum = ds.DYNC_Activity_Support.Count(d => d.activityID == x.id);
                            y.participateNum = ds.DYNC_Activity_Participator.Count(d => d.activityID == x.id);
                            y.theme = x.theme;
                            y.isParticipate = (ds.DYNC_Activity_Participator.SingleOrDefault(d => d.activityID == x.id && d.participatorID == clientID) != null) ? true : false;
                            y.isSupport = (ds.DYNC_Activity_Support.SingleOrDefault(d => d.activityID == x.id && d.clientID == clientID) != null) ? true : false;
                            y.images = (from c in ds.DYNC_Activity_Image
                                        where c.activityID == x.id
                                        select new App_Activity_Image
                                        {
                                            id = c.id,
                                            imageURL = c.imageUrl
                                        }).ToArray();
                            y.participators = (from f in ds.DYNC_Activity_Participator
                                               join g in ds.DYNC_Client on f.participatorID equals g.id into g1
                                               from g2 in g1.DefaultIfEmpty()
                                               where f.activityID == x.id
                                               select new App_Activity_Participator
                                               {
                                                   id = f.id,
                                                   clientID = f.participatorID,
                                                   nickName = g2.nickName,
                                                   portrait = g2.portrait,
                                                   signature = g2.signature
                                               }).ToArray();
                            returnData.Data = y;
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            return returnData;
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error:所选目标不存在！";
                            return returnData;
                        }

                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:请至少选择一个目标！";
                    return returnData;
                }

            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:没有登陆信息！";
                return returnData;
            }
        }

        /*-------------取消发起的活动---------------*/
        public CommonOutputApp appCancelActivity(string activityID, string clientID)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(activityID))
            {
                if (!string.IsNullOrEmpty(clientID))
                {
                    try
                    {
                        var x = ds.DYNC_Activity.SingleOrDefault(d => d.id == activityID);
                        if (x != null)
                        {
                            if (x.clientID == clientID)
                            {
                                x.status = "0";
                                ds.SubmitChanges();
                                returnData.IsOk = 1;
                                returnData.Msg = "success";
                                return returnData;
                            }
                            else
                            {
                                returnData.IsOk = 0;
                                returnData.Msg = "Error:您无权这么做！";
                                return returnData;
                            }
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error:所选随手拍不存在！";
                            return returnData;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:缺少登陆信息，请您重新登陆！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        /*-------------参与（取消参与）活动--------------*/
        public CommonOutputApp appParticipateActivity(string activityID, string clientID)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(activityID))
            {
                if (!string.IsNullOrEmpty(clientID))
                {
                    try
                    {
                        var x = ds.DYNC_Activity.SingleOrDefault(d => d.id == activityID);
                        if (x != null)
                        {
                            var y = ds.DYNC_Activity_Participator.SingleOrDefault(d => d.activityID == activityID && d.participatorID == clientID);
                            if (y == null)
                            {
                                //点赞
                                var z = new DYNC_Activity_Participator();
                                z.id = Guid.NewGuid().ToString();
                                z.participatorID = clientID;
                                z.activityID = activityID;
                                ds.DYNC_Activity_Participator.InsertOnSubmit(z);
                            }
                            else
                            {
                                //取消点赞
                                ds.DYNC_Activity_Participator.DeleteOnSubmit(y);
                            }
                            ds.SubmitChanges();
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            return returnData;
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error:所选活动不存在！";
                            return returnData;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:缺少登陆信息，请您重新登陆！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        /*-------------点赞（取消点赞）活动--------------*/
        public CommonOutputApp appSupportActivity(string activityID, string clientID)
        {
            CommonOutputApp returnData = new CommonOutputApp();
            if (!string.IsNullOrEmpty(activityID))
            {
                if (!string.IsNullOrEmpty(clientID))
                {
                    try
                    {
                        var x = ds.DYNC_Activity.SingleOrDefault(d => d.id == activityID);
                        if (x != null)
                        {
                            var y = ds.DYNC_Activity_Support.SingleOrDefault(d => d.activityID == activityID && d.clientID == clientID);
                            if (y == null)
                            {
                                //点赞
                                var z = new DYNC_Activity_Support();
                                z.id = Guid.NewGuid().ToString();
                                z.clientID = clientID;
                                z.activityID = activityID;
                                ds.DYNC_Activity_Support.InsertOnSubmit(z);
                            }
                            else
                            {
                                //取消点赞
                                ds.DYNC_Activity_Support.DeleteOnSubmit(y);
                            }
                            ds.SubmitChanges();
                            returnData.IsOk = 1;
                            returnData.Msg = "success";
                            return returnData;
                        }
                        else
                        {
                            returnData.IsOk = 0;
                            returnData.Msg = "Error:所选活动不存在！";
                            return returnData;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnData.IsOk = 0;
                        returnData.Msg = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    returnData.IsOk = 0;
                    returnData.Msg = "Error:缺少登陆信息，请您重新登陆！";
                    return returnData;
                }
            }
            else
            {
                returnData.IsOk = 0;
                returnData.Msg = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        #endregion
        #endregion


        #region 统计 

        #region 信息公告
        /*---------十日内信息公告发布统计---------*/
        public CommonOutputT<DYNC_Information_10> getInformationAnalysis_10(string districtID)
        {
            CommonOutputT<DYNC_Information_10> returnData = new CommonOutputT<DYNC_Information_10>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = new DYNC_Information_10();
                    x.date = new string[] {
                        DateTime.Now.AddDays(-10).ToString("M月d日"),
                        DateTime.Now.AddDays(-9).ToString("M月d日"),
                        DateTime.Now.AddDays(-8).ToString("M月d日"),
                        DateTime.Now.AddDays(-7).ToString("M月d日"),
                        DateTime.Now.AddDays(-6).ToString("M月d日"),
                        DateTime.Now.AddDays(-5).ToString("M月d日"),
                        DateTime.Now.AddDays(-4).ToString("M月d日"),
                        DateTime.Now.AddDays(-3).ToString("M月d日"),
                        DateTime.Now.AddDays(-2).ToString("M月d日"),
                        DateTime.Now.AddDays(-1).ToString("M月d日") };
                    x.tongzhigonggao = new int[]{
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0")};
                    x.bianminfuwu = new int[] {
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0")};
                    x.dangjianyaowen = new int[] {
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0")};
                    x.shequtese = new int[] {
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_Information.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0")};
                    x.sum = new int[]{
                        x.tongzhigonggao.Sum(),
                        x.bianminfuwu.Sum(),
                        x.dangjianyaowen.Sum(),
                        x.shequtese.Sum()};
                    returnData.data = x;
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
                returnData.message = "Error:无区域信息，请登录后重试！";
                return returnData;
            }
        }
        #endregion

        #region 随手拍

        /*---------十日内随手拍统计---------*/
        public CommonOutputT<DYNC_PhotoTake_10> getPhotoTake_10(string districtID)
        {
            CommonOutputT<DYNC_PhotoTake_10> returnData = new CommonOutputT<DYNC_PhotoTake_10>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = new DYNC_PhotoTake_10();
                    x.date = new string[] {
                        DateTime.Now.AddDays(-10).ToString("M月d日"),
                        DateTime.Now.AddDays(-9).ToString("M月d日"),
                        DateTime.Now.AddDays(-8).ToString("M月d日"),
                        DateTime.Now.AddDays(-7).ToString("M月d日"),
                        DateTime.Now.AddDays(-6).ToString("M月d日"),
                        DateTime.Now.AddDays(-5).ToString("M月d日"),
                        DateTime.Now.AddDays(-4).ToString("M月d日"),
                        DateTime.Now.AddDays(-3).ToString("M月d日"),
                        DateTime.Now.AddDays(-2).ToString("M月d日"),
                        DateTime.Now.AddDays(-1).ToString("M月d日") };
                    x.yichuli = new int[]{
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.status=="2"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.status=="2"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.status=="2"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.status=="2"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.status=="2"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.status=="2"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.status=="2"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.status=="2"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.status=="2"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.status=="2")};
                    x.weichuli = new int[] {
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.status=="1"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.status=="1"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.status=="1"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.status=="1"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.status=="1"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.status=="1"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.status=="1"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.status=="1"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.status=="1"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.status=="1")};
                    x.yijujue = new int[] {
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.status=="3"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.status=="3"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.status=="3"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.status=="3"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.status=="3"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.status=="3"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.status=="3"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.status=="3"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.status=="3"),
                        ds.DYNC_PhotoTake.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.status=="3")};
                    x.sum = new int[]{
                        x.yichuli.Sum(),
                        x.weichuli.Sum(),
                        x.yijujue.Sum() };
                    returnData.data = x;
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
                returnData.message = "Error:无区域信息，请登录后重试！";
                return returnData;
            }
        }
        #endregion

        #region 建议处理
        /*---------十日内建议处理统计---------*/
        public CommonOutputT<DYNC_Suggestion_10> getSuggestion_10(string districtID)
        {
            CommonOutputT<DYNC_Suggestion_10> returnData = new CommonOutputT<DYNC_Suggestion_10>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = new DYNC_Suggestion_10();
                    x.date = new string[] {
                        DateTime.Now.AddDays(-10).ToString("M月d日"),
                        DateTime.Now.AddDays(-9).ToString("M月d日"),
                        DateTime.Now.AddDays(-8).ToString("M月d日"),
                        DateTime.Now.AddDays(-7).ToString("M月d日"),
                        DateTime.Now.AddDays(-6).ToString("M月d日"),
                        DateTime.Now.AddDays(-5).ToString("M月d日"),
                        DateTime.Now.AddDays(-4).ToString("M月d日"),
                        DateTime.Now.AddDays(-3).ToString("M月d日"),
                        DateTime.Now.AddDays(-2).ToString("M月d日"),
                        DateTime.Now.AddDays(-1).ToString("M月d日") };
                    x.tongguo = new int[]{ // 建议处理有三个状态 1 未处理 2 已处理 3 拒绝
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy年M月d日")&&d.status=="2"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy年M月d日")&&d.status=="2"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy年M月d日")&&d.status=="2"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy年M月d日")&&d.status=="2"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy年M月d日")&&d.status=="2"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy年M月d日")&&d.status=="2"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy年M月d日")&&d.status=="2"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy年M月d日")&&d.status=="2"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy年M月d日")&&d.status=="2"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy年M月d日")&&d.status=="2")};
                    x.weitongguo = new int[] {
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy年M月d日")&&d.status=="3"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy年M月d日")&&d.status=="3"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy年M月d日")&&d.status=="3"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy年M月d日")&&d.status=="3"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy年M月d日")&&d.status=="3"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy年M月d日")&&d.status=="3"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy年M月d日")&&d.status=="3"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy年M月d日")&&d.status=="3"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy年M月d日")&&d.status=="3"),
                        ds.DYNC_Suggestion.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy年M月d日")&&d.status=="3")};
                    x.sum = new int[]{
                        x.tongguo.Sum(),
                        x.weitongguo.Sum()};
                    returnData.data = x;
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
                returnData.message = "Error:无区域信息，请登录后重试！";
                return returnData;
            }
        }
        #endregion

        #region  社区活动
        /*---------十日内社区活动数目统计---------*/
        public CommonOutputT<getActivityList_10> getActivityList_10()
        {
            CommonOutputT<getActivityList_10> returnData = new CommonOutputT<getActivityList_10>();
            if (!string.IsNullOrEmpty("1"))
            {
                try
                {
                    //    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = new getActivityList_10();
                    x.date = new string[] {
                        DateTime.Now.AddDays(-10).ToString("M月d日"),
                        DateTime.Now.AddDays(-9).ToString("M月d日"),
                        DateTime.Now.AddDays(-8).ToString("M月d日"),
                        DateTime.Now.AddDays(-7).ToString("M月d日"),
                        DateTime.Now.AddDays(-6).ToString("M月d日"),
                        DateTime.Now.AddDays(-5).ToString("M月d日"),
                        DateTime.Now.AddDays(-4).ToString("M月d日"),
                        DateTime.Now.AddDays(-3).ToString("M月d日"),
                        DateTime.Now.AddDays(-2).ToString("M月d日"),
                        DateTime.Now.AddDays(-1).ToString("M月d日") };
                    x.huodongshumu = new int[]{
                        ds.DYNC_Activity.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy年M月d日")&&d.status!="0"),
                        ds.DYNC_Activity.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy年M月d日")&&d.status!="0"),
                        ds.DYNC_Activity.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy年M月d日")&&d.status!="0"),
                        ds.DYNC_Activity.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy年M月d日")&&d.status!="0"),
                        ds.DYNC_Activity.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy年M月d日")&&d.status!="0"),
                        ds.DYNC_Activity.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy年M月d日")&&d.status!="0"),
                        ds.DYNC_Activity.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy年M月d日")&&d.status!="0"),
                        ds.DYNC_Activity.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy年M月d日")&&d.status!="0"),
                        ds.DYNC_Activity.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy年M月d日")&&d.status!="0"),
                        ds.DYNC_Activity.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy年M月d日")&&d.status!="0")};
                    x.sum = new int[]{
                        x.huodongshumu.Sum()};
                    returnData.data = x;
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
                returnData.message = "Error:无区域信息，请登录后重试！";
                return returnData;
            }
        }
        #endregion

        #region 主动巡检
        /*---------十日内主动巡检数目统计---------*/
        public CommonOutputT<getInitiativeCheck_10> getInitiativeCheck_10(string districtID)
        {
            CommonOutputT<getInitiativeCheck_10> returnData = new CommonOutputT<getInitiativeCheck_10>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = new getInitiativeCheck_10();
                    x.date = new string[] {
                        DateTime.Now.AddDays(-10).ToString("M月d日"),
                        DateTime.Now.AddDays(-9).ToString("M月d日"),
                        DateTime.Now.AddDays(-8).ToString("M月d日"),
                        DateTime.Now.AddDays(-7).ToString("M月d日"),
                        DateTime.Now.AddDays(-6).ToString("M月d日"),
                        DateTime.Now.AddDays(-5).ToString("M月d日"),
                        DateTime.Now.AddDays(-4).ToString("M月d日"),
                        DateTime.Now.AddDays(-3).ToString("M月d日"),
                        DateTime.Now.AddDays(-2).ToString("M月d日"),
                        DateTime.Now.AddDays(-1).ToString("M月d日") };
                    x.xunjian = new int[]{
                        ds.DYNC_InitiativeCheck.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/M/d")),
                        ds.DYNC_InitiativeCheck.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/M/d")),
                        ds.DYNC_InitiativeCheck.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/M/d")),
                        ds.DYNC_InitiativeCheck.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/M/d")),
                        ds.DYNC_InitiativeCheck.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/M/d")),
                        ds.DYNC_InitiativeCheck.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/M/d")),
                        ds.DYNC_InitiativeCheck.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/M/d")),
                        ds.DYNC_InitiativeCheck.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/M/d")),
                        ds.DYNC_InitiativeCheck.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/M/d")),
                        ds.DYNC_InitiativeCheck.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/M/d"))};
                    x.sum = new int[]{
                        x.xunjian.Sum()};
                    returnData.data = x;
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
                returnData.message = "Error:无区域信息，请登录后重试！";
                return returnData;
            }
        }
        #endregion

        #region 社情民意
        /*---------十日内社区民意统计---------*/
        public CommonOutputT<getPeopleCaring_10> getPeopleCaring_10(string districtID)
        {
            CommonOutputT<getPeopleCaring_10> returnData = new CommonOutputT<getPeopleCaring_10>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = new getPeopleCaring_10();
                    x.date = new string[] {
                        DateTime.Now.AddDays(-10).ToString("M月d日"),
                        DateTime.Now.AddDays(-9).ToString("M月d日"),
                        DateTime.Now.AddDays(-8).ToString("M月d日"),
                        DateTime.Now.AddDays(-7).ToString("M月d日"),
                        DateTime.Now.AddDays(-6).ToString("M月d日"),
                        DateTime.Now.AddDays(-5).ToString("M月d日"),
                        DateTime.Now.AddDays(-4).ToString("M月d日"),
                        DateTime.Now.AddDays(-3).ToString("M月d日"),
                        DateTime.Now.AddDays(-2).ToString("M月d日"),
                        DateTime.Now.AddDays(-1).ToString("M月d日") };
                    x.zhixun = new int[]{
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="1"&&d.status!="0")};
                    x.qiuzhu = new int[] {
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="2"&&d.status!="0")};
                    x.zoufang = new int[] {
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="3"&&d.status!="0")};
                    x.tiaojie = new int[] {
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="4"&&d.status!="0")};
                    x.toushu = new int[] {
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="5"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="5"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="5"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="5"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="5"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="5"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="5"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="5"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="5"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="5"&&d.status!="0")};
                    x.maodun = new int[] {
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="7"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="7"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="7"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="7"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="7"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="7"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="7"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="7"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="7"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="7"&&d.status!="0")};
                    x.jiufen = new int[] {
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.type=="6"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.type=="6"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.type=="6"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.type=="6"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.type=="6"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.type=="6"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.type=="6"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.type=="6"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.type=="6"&&d.status!="0"),
                        ds.DYNC_PeopleCaring.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.type=="6"&&d.status!="0")};

                    x.sum = new int[]{
                        x.zhixun.Sum(),
                        x.qiuzhu.Sum(),
                        x.zoufang.Sum(),
                        x.tiaojie.Sum(),
                        x.toushu.Sum(),
                        x.maodun.Sum(),
                        x.jiufen.Sum(),
                        };
                    returnData.data = x;
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
                returnData.message = "Error:无区域信息，请登录后重试！";
                return returnData;
            }
        }
        #endregion

        #endregion
    }
}
