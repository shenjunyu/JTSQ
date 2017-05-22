using System;
using System.Linq;
using MLDSData;
using MLDSService.DataContracts;
using System.Web;
using MLDSService.Methods;
using System.IO;
using MLDSService.DataContracts.Analysis;


namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Dynamic”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Dynamic.svc 或 Dynamic.svc.cs，然后开始调试。
    public class Business : IBusiness
    {
        private static MLDSDataContext ds = new MLDSDataContext();

        #region 业务管理
        /*------------列表查看------------*/
        public PageRows<List_Business[]> getBusinessList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Business[]> returnData = new PageRows<List_Business[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Business> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.phone ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby i.businessName ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby g.serviceName ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.processTime ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime ascending, a.processTime ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.phone descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby i.businessName descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby g.serviceName descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.processTime descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime descending, a.processTime descending
                                        select new List_Business
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
                        IQueryable<List_Business> x = x = from a in ds.BUS_BusinessList
                                                          join b in ds.SYS_District on a.districtID equals b.id into b1
                                                          from c in b1.DefaultIfEmpty()
                                                          join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                          from e in d1.DefaultIfEmpty()
                                                          join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                                          from g in f1.DefaultIfEmpty()
                                                          join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                                          from i in h1.DefaultIfEmpty()
                                                          where districts.Contains(a.districtID) && a.status != "0" && (
                                                          e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                                          a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                                          orderby a.createTime descending, a.processTime descending
                                                          select new List_Business
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
                        IQueryable<List_Business> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.name ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.phone ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.IDCard ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby i.businessName ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby g.serviceName ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.processTime ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby c.districtName ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending, a.processTime ascending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.name descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.phone descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.IDCard descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby i.businessName descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby g.serviceName descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.processTime descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby c.districtName descending
                                        select new List_Business
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
                                    x = from a in ds.BUS_BusinessList
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                        from i in h1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending, a.processTime descending
                                        select new List_Business
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
                        IQueryable<List_Business> x = from a in ds.BUS_BusinessList
                                                      join b in ds.SYS_District on a.districtID equals b.id into b1
                                                      from c in b1.DefaultIfEmpty()
                                                      join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                      from e in d1.DefaultIfEmpty()
                                                      join f in ds.BUS_ServiceType on a.serviceType equals f.id into f1
                                                      from g in f1.DefaultIfEmpty()
                                                      join h in ds.BUS_BusinessType on g.businessID equals h.id into h1
                                                      from i in h1.DefaultIfEmpty()
                                                      where districts.Contains(a.districtID) && a.status != "0"
                                                      orderby a.createTime descending, a.processTime descending
                                                      select new List_Business
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
        }


        /// <summary>
        /// 有问题
        /// </summary>
        /// <param name="IDCard"></param>
        /// <param name="serviceName"></param>
        /// <param name="remark"></param>
        /// <param name="userID"></param>
        /// <param name="districtID"></param>
        /// <param name="createTime"></param>
        /// <param name="status"></param>
        /// <param name="processTime"></param>
        /// <returns></returns>

        /*------------新增业务-------------*/
        public CommonOutput addBusiness(string IDCard, string serviceName, string remark, string userID,
            string districtID, string createTime, string status, string processTime)
        {
            CommonOutput returnData = new CommonOutput();

            try
            {
                var x = new BUS_BusinessList();
                x.id = Guid.NewGuid().ToString();
                x.districtID = districtID;
                x.serviceType = ds.BUS_ServiceType.SingleOrDefault(d => d.serviceName == serviceName).id;
                x.userID = ds.SYS_User.SingleOrDefault(d => d.name == userID).id;
                x.remark = remark;
                x.createTime = createTime;
                x.processTime = processTime;
                x.status = status;
                x.populationID = ds.POP_Basic.SingleOrDefault(d => d.IDCard == IDCard).id;
                ds.BUS_BusinessList.InsertOnSubmit(x);
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

        /*------------获取业务信息--------------*/
        public PageRows<BUS_BusinessType[]> getbusinessName()
        {
            PageRows<BUS_BusinessType[]> returnData = new PageRows<BUS_BusinessType[]>();
            try
            {
                IQueryable<BUS_BusinessType> x = null;
                x = from a in ds.BUS_BusinessType
                    select a;
                returnData.success = true;
                returnData.message = "success";
                returnData.total = x.ToArray<BUS_BusinessType>().Length;
                returnData.rows = x.ToArray<BUS_BusinessType>();
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.success = false;
                returnData.message = "Error:" + ex.Message;
                return returnData;
            }
        }

        /*------------根据业务获取服务信息--------------*/
        public PageRows<BUS_ServiceType[]> getserviceNameBybusinessID(string id)
        {
            PageRows<BUS_ServiceType[]> returnData = new PageRows<BUS_ServiceType[]>();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    IQueryable<BUS_ServiceType> x = null;
                    x = from a in ds.BUS_BusinessType
                        join b in ds.BUS_ServiceType on a.id equals b.businessID into b1
                        from c in b1.DefaultIfEmpty()
                        where c.id == id
                        select c;
                    returnData.success = true;
                    returnData.message = "success";
                    returnData.total = x.ToArray<BUS_ServiceType>().Length;
                    returnData.rows = x.ToArray<BUS_ServiceType>();
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
                returnData.message = "Error:输入了无效信息！";
                return returnData;
            }
        }
        #endregion

        #region 违章建筑
        /*------------列表查看------------*/
        public PageRows<List_IllegalBuilding[]> getIllegalBuildingList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_IllegalBuilding[]> returnData = new PageRows<List_IllegalBuilding[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_IllegalBuilding> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.phone ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "illegalBuildingAddress":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.processTime ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime ascending, a.processTime ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
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
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.phone descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "illegalBuildingAddress":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.processTime descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (
                                        e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                        a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                        orderby a.createTime descending, a.processTime descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
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
                        IQueryable<List_IllegalBuilding> x = from a in ds.BUS_IllegalBuilding
                                                             join b in ds.SYS_District on a.districtID equals b.id into b1
                                                             from c in b1.DefaultIfEmpty()
                                                             join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                             from e in d1.DefaultIfEmpty()
                                                             where districts.Contains(a.districtID) && a.status != "0" && (
                                                             e.name.Contains(search) || e.phone.Contains(search) || e.IDCard.Contains(search) ||
                                                             a.createTime.Contains(search) || a.processTime.Contains(search) || c.districtName.Contains(search))
                                                             orderby a.createTime descending, a.processTime descending
                                                             select new List_IllegalBuilding
                                                             {
                                                                 id = a.id,
                                                                 illegalBuildingAddress = a.illegalBuildingAddress,
                                                                 name = e.name,
                                                                 phone = e.phone,
                                                                 IDCard = e.IDCard,
                                                                 processTime = a.processTime,
                                                                 district = c.districtName,
                                                                 createTime = a.createTime,
                                                                 status = a.status,
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
                        IQueryable<List_IllegalBuilding> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.name ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.phone ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.IDCard ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "illegalBuildingAddress":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.name ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.processTime ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby c.districtName ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime ascending, a.processTime ascending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
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
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.name descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.phone descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.IDCard descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "illegalBuildingAddress":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby e.name descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "createTime":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "processTime":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.processTime descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby c.districtName descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
                                            remark = a.remark
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_IllegalBuilding
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
                                        orderby a.createTime descending, a.processTime descending
                                        select new List_IllegalBuilding
                                        {
                                            id = a.id,
                                            illegalBuildingAddress = a.illegalBuildingAddress,
                                            name = e.name,
                                            phone = e.phone,
                                            IDCard = e.IDCard,
                                            processTime = a.processTime,
                                            district = c.districtName,
                                            createTime = a.createTime,
                                            status = a.status,
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
                        IQueryable<List_IllegalBuilding> x = from a in ds.BUS_IllegalBuilding
                                                             join b in ds.SYS_District on a.districtID equals b.id into b1
                                                             from c in b1.DefaultIfEmpty()
                                                             join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                             from e in d1.DefaultIfEmpty()
                                                             where districts.Contains(a.districtID) && a.status != "0"
                                                             orderby a.createTime descending, a.processTime descending
                                                             select new List_IllegalBuilding
                                                             {
                                                                 id = a.id,
                                                                 illegalBuildingAddress = a.illegalBuildingAddress,
                                                                 name = e.name,
                                                                 phone = e.phone,
                                                                 IDCard = e.IDCard,
                                                                 processTime = a.processTime,
                                                                 district = c.districtName,
                                                                 createTime = a.createTime,
                                                                 status = a.status,
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

        #endregion

        #region 少儿医保
        /*------------列表查看吕------------*/
        public PageRows<List_ChildrenInsurance[]> getChildrenInsuranceList(string year, string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_ChildrenInsurance[]> returnData = new PageRows<List_ChildrenInsurance[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_ChildrenInsurance> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.name ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.phone ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.IDCard ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.sex ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "peopleID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.peopleID ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "accountProperty":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.accountProperty ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "contract":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.contract ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "exemptionID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.exemptionID ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "exemptionType":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.exemptionType ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "institutionID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.institutionID ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "studentNum":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.studentNum ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.institutionID ascending, a.peopleID ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.name descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.phone descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.IDCard descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby c.districtName descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.sex descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "peopleID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.peopleID descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "accountProperty":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.accountProperty descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "contract":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.contract descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "exemptionID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.exemptionID descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "exemptionType":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.exemptionType descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "institutionID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.institutionID descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "studentNum":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.studentNum descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search) ||
                                        a.studentNum.Contains(search) || c.districtName.Contains(search))
                                        orderby a.institutionID descending, a.peopleID descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
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
                        IQueryable<List_ChildrenInsurance> x = from a in ds.BUS_ChildrenInsurance
                                                               join b in ds.SYS_District on a.districtID equals b.id into b1
                                                               from c in b1.DefaultIfEmpty()
                                                               join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                               from e in d1.DefaultIfEmpty()
                                                               where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                                               a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                                               a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                                               a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                                               a.name.Contains(search) || a.peopleID.Contains(search) ||
                                                               a.phone.Contains(search) || a.sex.Contains(search) ||
                                                               a.studentNum.Contains(search) || c.districtName.Contains(search))
                                                               orderby a.institutionID descending, a.peopleID descending
                                                               select new List_ChildrenInsurance
                                                               {
                                                                   id = a.id,
                                                                   name = a.name,
                                                                   phone = a.phone,
                                                                   IDCard = a.IDCard,
                                                                   district = c.districtName,
                                                                   status = a.status,
                                                                   sex = a.sex,
                                                                   peopleID = a.peopleID,
                                                                   accountProperty = a.accountProperty,
                                                                   contract = a.contract,
                                                                   exemptionID = a.exemptionID,
                                                                   exemptionType = a.exemptionType,
                                                                   institutionID = a.institutionID,
                                                                   studentNum = a.studentNum
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
                        IQueryable<List_ChildrenInsurance> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.name ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.phone ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.IDCard ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby c.districtName ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.sex ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "peopleID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.peopleID ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "accountProperty":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.accountProperty ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "contract":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.contract ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "exemptionID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.exemptionID ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "exemptionType":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.exemptionType ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "institutionID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.institutionID ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "studentNum":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.studentNum ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.institutionID ascending, a.peopleID ascending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.name descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.phone descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.IDCard descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby c.districtName descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.sex descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "peopleID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.peopleID descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "accountProperty":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.accountProperty descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "contract":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.contract descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "exemptionID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.exemptionID descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "exemptionType":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.exemptionType descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "institutionID":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.institutionID descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                case "studentNum":
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.studentNum descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_ChildrenInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.institutionID descending, a.peopleID descending
                                        select new List_ChildrenInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            accountProperty = a.accountProperty,
                                            contract = a.contract,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType,
                                            institutionID = a.institutionID,
                                            studentNum = a.studentNum
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
                        IQueryable<List_ChildrenInsurance> x = from a in ds.BUS_ChildrenInsurance
                                                               join b in ds.SYS_District on a.districtID equals b.id into b1
                                                               from c in b1.DefaultIfEmpty()
                                                               join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                               from e in d1.DefaultIfEmpty()
                                                               where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                                               orderby a.institutionID descending, a.peopleID descending
                                                               select new List_ChildrenInsurance
                                                               {
                                                                   id = a.id,
                                                                   name = a.name,
                                                                   phone = a.phone,
                                                                   IDCard = a.IDCard,
                                                                   district = c.districtName,
                                                                   status = a.status,
                                                                   sex = a.sex,
                                                                   peopleID = a.peopleID,
                                                                   accountProperty = a.accountProperty,
                                                                   contract = a.contract,
                                                                   exemptionID = a.exemptionID,
                                                                   exemptionType = a.exemptionType,
                                                                   institutionID = a.institutionID,
                                                                   studentNum = a.studentNum
                                                               };
                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_ChildrenInsurance>().Length;
                        x = x.Skip<List_ChildrenInsurance>(offset);
                        x = x.Take<List_ChildrenInsurance>(limit);
                        returnData.rows = x.ToArray<List_ChildrenInsurance>();
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

        /*------------列表查看郭------------*/
        public PageRows<List_ChildrenInsurance[]> getsubChildrenInsuranceList(string year, string districtID, string subdistrictID, int offset, int limit, string order, string search, string sort)
        {
            if (string.IsNullOrEmpty(subdistrictID))
            {
                var districts = CommonMethod.getSubDistrict(districtID);  //??
                PageRows<List_ChildrenInsurance[]> returnData = new PageRows<List_ChildrenInsurance[]>();

                if (!String.IsNullOrEmpty(search))
                {
                    //排序字段是否为空
                    if (!string.IsNullOrEmpty(sort))
                    {
                        try
                        {
                            IQueryable<List_ChildrenInsurance> x = null;
                            if (order == "asc" || order == "")
                            {
                                switch (sort)
                                {
                                    case "name":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.name ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "phone":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.phone ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "IDCard":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.IDCard ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "district":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby c.districtName ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "sex":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.sex ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "peopleID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.peopleID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "accountProperty":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.accountProperty ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "contract":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.contract ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.exemptionID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionType":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.exemptionType ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "institutionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.institutionID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "studentNum":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.studentNum ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    default:
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.institutionID ascending, a.peopleID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                }

                            }
                            else if (order == "desc")
                            {
                                switch (sort)
                                {
                                    case "name":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.name descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "phone":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.phone descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "IDCard":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.IDCard descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "district":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby c.districtName descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "sex":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.sex descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "peopleID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.peopleID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "accountProperty":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.accountProperty descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "contract":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.contract descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.exemptionID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionType":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.exemptionType descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "institutionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.institutionID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "studentNum":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.studentNum descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    default:
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.institutionID descending, a.peopleID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
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
                            IQueryable<List_ChildrenInsurance> x = from a in ds.BUS_ChildrenInsurance
                                                                   join b in ds.SYS_District on a.districtID equals b.id into b1
                                                                   from c in b1.DefaultIfEmpty()
                                                                   join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                                   from e in d1.DefaultIfEmpty()
                                                                   where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                                                   a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                                                   a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                                                   a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                                                   a.name.Contains(search) || a.peopleID.Contains(search) ||
                                                                   a.phone.Contains(search) || a.sex.Contains(search) ||
                                                                   a.studentNum.Contains(search) || c.districtName.Contains(search))
                                                                   orderby a.institutionID descending, a.peopleID descending
                                                                   select new List_ChildrenInsurance
                                                                   {
                                                                       id = a.id,
                                                                       name = a.name,
                                                                       phone = a.phone,
                                                                       IDCard = a.IDCard,
                                                                       district = c.districtName,
                                                                       status = a.status,
                                                                       sex = a.sex,
                                                                       peopleID = a.peopleID,
                                                                       accountProperty = a.accountProperty,
                                                                       contract = a.contract,
                                                                       exemptionID = a.exemptionID,
                                                                       exemptionType = a.exemptionType,
                                                                       institutionID = a.institutionID,
                                                                       studentNum = a.studentNum
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
                            IQueryable<List_ChildrenInsurance> x = null;
                            if (order == "asc" || order == "")
                            {
                                switch (sort)
                                {
                                    case "name":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.name ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "phone":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.phone ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "IDCard":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.IDCard ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "district":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby c.districtName ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "sex":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.sex ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "peopleID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.peopleID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "accountProperty":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.accountProperty ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "contract":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.contract ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.exemptionID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionType":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.exemptionType ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "institutionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.institutionID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "studentNum":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.studentNum ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    default:
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.institutionID ascending, a.peopleID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                }
                            }
                            else if (order == "desc")
                            {
                                switch (sort)
                                {
                                    case "name":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.name descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "phone":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.phone descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "IDCard":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.IDCard descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "district":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby c.districtName descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "sex":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.sex descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "peopleID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.peopleID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "accountProperty":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.accountProperty descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "contract":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.contract descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.exemptionID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionType":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.exemptionType descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "institutionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.institutionID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "studentNum":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.studentNum descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    default:
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                            orderby a.institutionID descending, a.peopleID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
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
                            IQueryable<List_ChildrenInsurance> x = from a in ds.BUS_ChildrenInsurance
                                                                   join b in ds.SYS_District on a.districtID equals b.id into b1
                                                                   from c in b1.DefaultIfEmpty()
                                                                   join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                                   from e in d1.DefaultIfEmpty()
                                                                   where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                                                   orderby a.institutionID descending, a.peopleID descending
                                                                   select new List_ChildrenInsurance
                                                                   {
                                                                       id = a.id,
                                                                       name = a.name,
                                                                       phone = a.phone,
                                                                       IDCard = a.IDCard,
                                                                       district = c.districtName,
                                                                       status = a.status,
                                                                       sex = a.sex,
                                                                       peopleID = a.peopleID,
                                                                       accountProperty = a.accountProperty,
                                                                       contract = a.contract,
                                                                       exemptionID = a.exemptionID,
                                                                       exemptionType = a.exemptionType,
                                                                       institutionID = a.institutionID,
                                                                       studentNum = a.studentNum
                                                                   };
                            returnData.success = true;
                            returnData.message = "Success";
                            returnData.total = x.ToArray<List_ChildrenInsurance>().Length;
                            x = x.Skip<List_ChildrenInsurance>(offset);
                            x = x.Take<List_ChildrenInsurance>(limit);
                            returnData.rows = x.ToArray<List_ChildrenInsurance>();
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
            else  //镇级平台查看村级平台
            {
                var districts = CommonMethod.getSubDistrict(districtID); //??
                PageRows<List_ChildrenInsurance[]> returnData = new PageRows<List_ChildrenInsurance[]>();
                if (!String.IsNullOrEmpty(search))
                {
                    //排序字段是否为空
                    if (!String.IsNullOrEmpty(sort))
                    {
                        try
                        {
                            IQueryable<List_ChildrenInsurance> x = null;
                            if (order == "asc" || order == "")
                            {
                                switch (sort)
                                {
                                    case "name":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.name ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "phone":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.phone ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "IDCard":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.IDCard ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "district":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby c.districtName ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "sex":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.sex ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "peopleID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.peopleID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "accountProperty":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.accountProperty ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "contract":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.contract ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.exemptionID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionType":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.exemptionType ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "institutionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.institutionID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "studentNum":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.studentNum ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    default:
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.institutionID ascending, a.peopleID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                }

                            }
                            else if (order == "desc")
                            {
                                switch (sort)
                                {
                                    case "name":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.name descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "phone":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.phone descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "IDCard":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.IDCard descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "district":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby c.districtName descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "sex":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.sex descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "peopleID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.peopleID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "accountProperty":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.accountProperty descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "contract":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.contract descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.exemptionID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionType":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.exemptionType descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "institutionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.institutionID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "studentNum":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.studentNum descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    default:
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                            a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                            a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                            a.phone.Contains(search) || a.sex.Contains(search) ||
                                            a.studentNum.Contains(search) || c.districtName.Contains(search))
                                            orderby a.institutionID descending, a.peopleID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
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
                            IQueryable<List_ChildrenInsurance> x = from a in ds.BUS_ChildrenInsurance
                                                                   join b in ds.SYS_District on a.districtID equals b.id into b1
                                                                   from c in b1.DefaultIfEmpty()
                                                                   join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                                   from e in d1.DefaultIfEmpty()
                                                                   where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year && (
                                                                   a.accountProperty.Contains(search) || a.contract.Contains(search) ||
                                                                   a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                                                   a.IDCard.Contains(search) || a.institutionID.Contains(search) ||
                                                                   a.name.Contains(search) || a.peopleID.Contains(search) ||
                                                                   a.phone.Contains(search) || a.sex.Contains(search) ||
                                                                   a.studentNum.Contains(search) || c.districtName.Contains(search))
                                                                   orderby a.institutionID descending, a.peopleID descending
                                                                   select new List_ChildrenInsurance
                                                                   {
                                                                       id = a.id,
                                                                       name = a.name,
                                                                       phone = a.phone,
                                                                       IDCard = a.IDCard,
                                                                       district = c.districtName,
                                                                       status = a.status,
                                                                       sex = a.sex,
                                                                       peopleID = a.peopleID,
                                                                       accountProperty = a.accountProperty,
                                                                       contract = a.contract,
                                                                       exemptionID = a.exemptionID,
                                                                       exemptionType = a.exemptionType,
                                                                       institutionID = a.institutionID,
                                                                       studentNum = a.studentNum
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
                            IQueryable<List_ChildrenInsurance> x = null;
                            if (order == "asc" || order == "")
                            {
                                switch (sort)
                                {
                                    case "name":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.name ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "phone":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.phone ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "IDCard":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.IDCard ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "district":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby c.districtName ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "sex":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.sex ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "peopleID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.peopleID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "accountProperty":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.accountProperty ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "contract":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.contract ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.exemptionID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionType":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.exemptionType ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "institutionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.institutionID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "studentNum":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.studentNum ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    default:
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.institutionID ascending, a.peopleID ascending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                }
                            }
                            else if (order == "desc")
                            {
                                switch (sort)
                                {
                                    case "name":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.name descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "phone":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.phone descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "IDCard":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.IDCard descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "district":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby c.districtName descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "sex":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.sex descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "peopleID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.peopleID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "accountProperty":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.accountProperty descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "contract":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.contract descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.exemptionID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "exemptionType":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.exemptionType descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "institutionID":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.institutionID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    case "studentNum":
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.studentNum descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
                                            };
                                        break;
                                    default:
                                        x = from a in ds.BUS_ChildrenInsurance
                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                            from c in b1.DefaultIfEmpty()
                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                            from e in d1.DefaultIfEmpty()
                                            where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                            orderby a.institutionID descending, a.peopleID descending
                                            select new List_ChildrenInsurance
                                            {
                                                id = a.id,
                                                name = a.name,
                                                phone = a.phone,
                                                IDCard = a.IDCard,
                                                district = c.districtName,
                                                status = a.status,
                                                sex = a.sex,
                                                peopleID = a.peopleID,
                                                accountProperty = a.accountProperty,
                                                contract = a.contract,
                                                exemptionID = a.exemptionID,
                                                exemptionType = a.exemptionType,
                                                institutionID = a.institutionID,
                                                studentNum = a.studentNum
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
                            IQueryable<List_ChildrenInsurance> x = from a in ds.BUS_ChildrenInsurance
                                                                   join b in ds.SYS_District on a.districtID equals b.id into b1
                                                                   from c in b1.DefaultIfEmpty()
                                                                   join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                                   from e in d1.DefaultIfEmpty()
                                                                   where districts.Contains(a.districtID) && subdistrictID == a.districtID && a.status != "0" && a.year == year
                                                                   orderby a.institutionID descending, a.peopleID descending
                                                                   select new List_ChildrenInsurance
                                                                   {
                                                                       id = a.id,
                                                                       name = a.name,
                                                                       phone = a.phone,
                                                                       IDCard = a.IDCard,
                                                                       district = c.districtName,
                                                                       status = a.status,
                                                                       sex = a.sex,
                                                                       peopleID = a.peopleID,
                                                                       accountProperty = a.accountProperty,
                                                                       contract = a.contract,
                                                                       exemptionID = a.exemptionID,
                                                                       exemptionType = a.exemptionType,
                                                                       institutionID = a.institutionID,
                                                                       studentNum = a.studentNum
                                                                   };
                            returnData.success = true;
                            returnData.message = "Success";
                            returnData.total = x.ToArray<List_ChildrenInsurance>().Length;
                            x = x.Skip<List_ChildrenInsurance>(offset);
                            x = x.Take<List_ChildrenInsurance>(limit);
                            returnData.rows = x.ToArray<List_ChildrenInsurance>();
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
        }

        /*-------------新增少儿医保郭---------*/
        public CommonOutput addChildrenInsuranceList(string year, string districtID, string institutionID, string peopleID, string name, string IDCard, string sex, string accountProperty, string studentNum, string exemptionType, string exemptionID, string contract, string phone)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(IDCard))
            {
                try
                {
                    var thisGuy = ds.BUS_ChildrenInsurance.SingleOrDefault(d => d.name == name && d.IDCard == IDCard);
                    var y = ds.POP_Basic.SingleOrDefault(d => d.IDCard == IDCard && d.name == name);// 通过身份证号和姓名检索该人是否存在
                    if (thisGuy == null)
                    {
                        var x = new BUS_ChildrenInsurance();
                        x.id = Guid.NewGuid().ToString();
                        x.districtID = districtID;
                        x.year = year;
                        x.institutionID = institutionID;
                        x.peopleID = peopleID;
                        x.name = name;
                        x.IDCard = IDCard;
                        //x.addressID = ds.POP_Building.SingleOrDefault(d => d.districtID == districtID && d.plot == plot && d.houseNum == houseNum).id;
                        x.sex = sex;
                        x.accountProperty = accountProperty;
                        x.studentNum = studentNum;
                        x.exemptionType = exemptionType;
                        x.exemptionID = exemptionID;
                        x.contract = contract;
                        x.phone = phone;
                        x.populationID = y.id; // 将人口表里面的id给 BUS_ChildrenInsurance的populationID
                        x.status = "1";
                        ds.BUS_ChildrenInsurance.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                    }
                    else
                    {
                        if (thisGuy.status == "0")
                        {
                            var x = new BUS_ChildrenInsurance();
                            x.id = Guid.NewGuid().ToString();
                            x.districtID = districtID;
                            x.year = year;
                            x.institutionID = institutionID;
                            x.peopleID = peopleID;
                            x.name = name;
                            x.IDCard = IDCard;
                            //x.addressID = ds.POP_Building.SingleOrDefault(d => d.districtID == districtID && d.plot == plot && d.houseNum == houseNum).id;
                            x.sex = sex;
                            x.accountProperty = accountProperty;
                            x.studentNum = studentNum;
                            x.exemptionType = exemptionType;
                            x.exemptionID = exemptionID;
                            x.contract = contract;
                            x.phone = phone;
                            x.status = "1";
                            ds.BUS_ChildrenInsurance.InsertOnSubmit(x);
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
                returnData.message = "Error:请填写基础信息！";
                return returnData;
            }
        }

        /*-------------编辑少儿医保郭---------*/
        public CommonOutput editChildrenInsuranceList(string id, string year, string districtID, string institutionID, string peopleID, string name, string IDCard, string sex, string accountProperty, string studentNum, string exemptionType, string exemptionID, string contract, string phone)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(IDCard))
            {
                try
                {
                    BUS_ChildrenInsurance x = ds.BUS_ChildrenInsurance.SingleOrDefault(d => d.id == id);
                    if (x == null)
                    {
                        returnData.success = false;
                        returnData.message = "不存在该条信息";
                    }
                    x.districtID = districtID;
                    x.year = year;
                    x.institutionID = institutionID;
                    x.peopleID = peopleID;
                    x.name = name;
                    x.IDCard = IDCard;
                    x.sex = sex;
                    x.accountProperty = accountProperty;
                    x.studentNum = studentNum;
                    x.exemptionType = exemptionType;
                    x.exemptionID = exemptionID;
                    x.contract = contract;
                    x.phone = phone;
                    x.status = "1";
                    //    ds.BUS_ChildrenInsurance.InsertOnSubmit(x);
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
                returnData.message = "Error:请填写基础信息！";
                return returnData;
            }
        }

        /*-------------删除少儿医保郭---------*/
        public CommonOutput deleteChildrenInsuranceList(string id)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.BUS_ChildrenInsurance.SingleOrDefault(d => d.id == id);
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

        /*-------------批量删除少儿医保郭-----*/
        public CommonOutput deleteMultiChildrenInsuranceList(string idStr)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(idStr))
            {
                try
                {
                    string[] ids = idStr.Split(',');
                    foreach (var id in ids)
                    {
                        var x = ds.BUS_ChildrenInsurance.SingleOrDefault(d => d.id == id);
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

        #region 农村医疗
        /*------------列表查看------------*/
        public PageRows<List_RuralInsurance[]> getRuralInsuranceList(string year, string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_RuralInsurance[]> returnData = new PageRows<List_RuralInsurance[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_RuralInsurance> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.name ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.phone ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.IDCard ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.sex ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "peopleID":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.peopleID ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "exemptionID":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.exemptionID ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "exemptionType":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.exemptionType ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.peopleID ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.name descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.phone descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.IDCard descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby c.districtName descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.sex descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "peopleID":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.peopleID descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "exemptionID":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.exemptionID descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "exemptionType":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.exemptionType descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                        a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                        a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        a.name.Contains(search) || a.peopleID.Contains(search) ||
                                        a.phone.Contains(search) || a.sex.Contains(search))
                                        orderby a.peopleID descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
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
                        IQueryable<List_RuralInsurance> x = from a in ds.BUS_RuralInsurance
                                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                                            from c in b1.DefaultIfEmpty()
                                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                            from e in d1.DefaultIfEmpty()
                                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year && (
                                                            a.exemptionID.Contains(search) || a.exemptionType.Contains(search) ||
                                                            a.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                                            a.name.Contains(search) || a.peopleID.Contains(search) ||
                                                            a.phone.Contains(search) || a.sex.Contains(search))
                                                            orderby a.peopleID descending
                                                            select new List_RuralInsurance
                                                            {
                                                                id = a.id,
                                                                name = a.name,
                                                                phone = a.phone,
                                                                IDCard = a.IDCard,
                                                                district = c.districtName,
                                                                status = a.status,
                                                                sex = a.sex,
                                                                peopleID = a.peopleID,
                                                                exemptionID = a.exemptionID,
                                                                exemptionType = a.exemptionType
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
                        IQueryable<List_RuralInsurance> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.name ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.phone ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.IDCard ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby c.districtName ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.sex ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "peopleID":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.peopleID ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "exemptionID":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.exemptionID ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "exemptionType":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.exemptionType ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.peopleID ascending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.name descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.phone descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.IDCard descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby c.districtName descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.sex descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "peopleID":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.peopleID descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "exemptionID":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.exemptionID descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                case "exemptionType":
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.exemptionType descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
                                        };
                                    break;
                                default:
                                    x = from a in ds.BUS_RuralInsurance
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                        orderby a.peopleID descending
                                        select new List_RuralInsurance
                                        {
                                            id = a.id,
                                            name = a.name,
                                            phone = a.phone,
                                            IDCard = a.IDCard,
                                            district = c.districtName,
                                            status = a.status,
                                            sex = a.sex,
                                            peopleID = a.peopleID,
                                            exemptionID = a.exemptionID,
                                            exemptionType = a.exemptionType
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
                        IQueryable<List_RuralInsurance> x = from a in ds.BUS_RuralInsurance
                                                            join b in ds.SYS_District on a.districtID equals b.id into b1
                                                            from c in b1.DefaultIfEmpty()
                                                            join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                            from e in d1.DefaultIfEmpty()
                                                            where districts.Contains(a.districtID) && a.status != "0" && a.year == year
                                                            orderby a.peopleID descending
                                                            select new List_RuralInsurance
                                                            {
                                                                id = a.id,
                                                                name = a.name,
                                                                phone = a.phone,
                                                                IDCard = a.IDCard,
                                                                district = c.districtName,
                                                                status = a.status,
                                                                sex = a.sex,
                                                                peopleID = a.peopleID,
                                                                exemptionID = a.exemptionID,
                                                                exemptionType = a.exemptionType
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

        /*-------------新增农村医疗---------*/
        public CommonOutput addRuralInsuranceList(string year, string districtID, string peopleID, string name, string IDCard, string sex, string phone, string exemptionType, string exemptionID)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(IDCard))
            {
                try
                {
                    var thisGuy = ds.BUS_RuralInsurance.SingleOrDefault(d => d.name == name && d.IDCard == IDCard);
                    var y = ds.POP_Basic.SingleOrDefault(d => d.IDCard == IDCard && d.name == name);// 通过身份证号和姓名检索该人是否存在
                    if (thisGuy == null)
                    {
                        var x = new BUS_RuralInsurance();
                        x.id = Guid.NewGuid().ToString();
                        x.districtID = districtID;
                        x.year = year;
                        x.peopleID = peopleID;
                        x.name = name;
                        x.IDCard = IDCard;
                        //x.addressID = ds.POP_Building.SingleOrDefault(d => d.districtID == districtID && d.plot == plot && d.houseNum == houseNum).id;
                        x.sex = sex;
                        x.exemptionType = exemptionType;
                        x.exemptionID = exemptionID;
                        x.phone = phone;
                        x.populationID = y.id; // 将人口表里面的id给 BUS_ChildrenInsurance的populationID
                        x.status = "1";
                        ds.BUS_RuralInsurance.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                    }
                    else
                    {
                        if (thisGuy.status == "0")
                        {
                            var x = new BUS_RuralInsurance();
                            x.id = Guid.NewGuid().ToString();
                            x.districtID = districtID;
                            x.year = year;
                            x.peopleID = peopleID;
                            x.name = name;
                            x.IDCard = IDCard;
                            //x.addressID = ds.POP_Building.SingleOrDefault(d => d.districtID == districtID && d.plot == plot && d.houseNum == houseNum).id;
                            x.sex = sex;
                            x.exemptionType = exemptionType;
                            x.exemptionID = exemptionID;
                            x.phone = phone;
                            x.populationID = y.id; // 将人口表里面的id给 BUS_ChildrenInsurance的populationID
                            x.status = "1";
                            ds.BUS_RuralInsurance.InsertOnSubmit(x);
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
                returnData.message = "Error:请填写基础信息！";
                return returnData;
            }
        }
        /*-------------编辑农村医疗---------*/
        public CommonOutput editRuralInsuranceList(string id, string year, string districtID, string peopleID, string name, string IDCard, string sex, string phone, string exemptionType, string exemptionID)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(IDCard))
            {
                try
                {
                    BUS_RuralInsurance x = ds.BUS_RuralInsurance.SingleOrDefault(d => d.id == id);
                    if (x == null)
                    {
                        returnData.success = false;
                        returnData.message = "不存在该条信息";
                    }
                    x.districtID = districtID;
                    x.year = year;
                    x.peopleID = peopleID;
                    x.name = name;
                    x.IDCard = IDCard;
                    x.sex = sex;
                    x.exemptionType = exemptionType;
                    x.exemptionID = exemptionID;
                    x.phone = phone;
                    x.status = "1";
                    //    ds.BUS_ChildrenInsurance.InsertOnSubmit(x);
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
                returnData.message = "Error:请填写基础信息！";
                return returnData;
            }
        }

        /*-------------删除农村医疗---------*/
        public CommonOutput deleteRuralInsuranceList(string id)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.BUS_RuralInsurance.SingleOrDefault(d => d.id == id);
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
        /*-------------批量删除农村医疗-----*/
        public CommonOutput deleteMultiRuralInsuranceList(string idStr)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(idStr))
            {
                try
                {
                    string[] ids = idStr.Split(',');
                    foreach (var id in ids)
                    {
                        var x = ds.BUS_RuralInsurance.SingleOrDefault(d => d.id == id);
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

        #region 政务通知
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "镇级通知";
                                    break;
                                case "2":
                                    i.type = "下发通知";
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
                        IQueryable<CommonInformation> x = from a in ds.BUS_InternalInformation
                                                          join b in ds.SYS_District on a.districtID equals b.id into b1
                                                          from c in b1.DefaultIfEmpty()
                                                          join d in ds.SYS_User on a.author equals d.id into d1
                                                          from e in d1.DefaultIfEmpty()
                                                          where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    i.type = "镇级通知";
                                    break;
                                case "2":
                                    i.type = "下发通知";
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_InternalInformation
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "镇级通知";
                                    break;
                                case "2":
                                    i.type = "下发通知";
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
                        IQueryable<CommonInformation> x = from a in ds.BUS_InternalInformation
                                                          join b in ds.SYS_District on a.districtID equals b.id into b1
                                                          from c in b1.DefaultIfEmpty()
                                                          join d in ds.SYS_User on a.author equals d.id into d1
                                                          from e in d1.DefaultIfEmpty()
                                                          where districts.Contains(a.districtID) && a.status != "0"
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
                                    i.type = "镇级通知";
                                    break;
                                case "2":
                                    i.type = "下发通知";
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
                        var x = new BUS_InternalInformation();
                        x.id = Guid.NewGuid().ToString();
                        x.title = title;
                        x.type = type;
                        x.peek = peek;
                        x.cover = imageURL;
                        x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        x.status = "1";
                        x.author = userID;
                        x.districtID = districtID;
                        x.mainText = HttpUtility.UrlDecode(htmlContent);
                        //x.mainText = x.mainText.Replace("MLDS/MLDS../../../..", "http://122.193.9.83:8079/MLDS");
                        //StreamWriter SW = File.CreateText("E:\\DongShan\\MLDS\\MLDS\\upload\\publish\\" + x.id + ".html");
                        //SW.WriteLine("<!doctype html>");
                        //SW.WriteLine("<html>");
                        //SW.WriteLine("<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes\"  />");
                        //SW.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                        //SW.WriteLine("<style type=\"text/css\">");
                        //SW.WriteLine("body {width: 95%;height: auto;}");
                        //SW.WriteLine("img {width: 100%; position:relative;}");
                        //SW.WriteLine("h2 {text-align:center}");
                        //SW.WriteLine(".author {text-align:center}");
                        //SW.WriteLine("</style>");
                        //SW.WriteLine("</head>");
                        //SW.WriteLine("<body><div style=\"margin:5px;\">");
                        //SW.WriteLine("<h2>" + x.title + "</h2>");
                        //SW.WriteLine("<p class=\"author\">" + ds.SYS_User.SingleOrDefault(d => d.id == x.author).name + "</p>");
                        //SW.WriteLine("<HR style=\"border: 3 double\" width=\"80 % \" SIZE=3>");
                        //SW.WriteLine(x.mainText);
                        //SW.WriteLine("</div></body></html>");
                        //SW.Close();

                        ds.BUS_InternalInformation.InsertOnSubmit(x);
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
                            var x = ds.BUS_InternalInformation.SingleOrDefault(d => d.id == id);
                            x.title = title;
                            x.type = type;
                            x.peek = peek;
                            x.cover = imageURL;
                            x.mainText = HttpUtility.UrlDecode(htmlContent);
                            x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                            x.author = userID;
                            x.districtID = districtID;
                            //x.mainText = x.mainText.Replace("MLDS/MLDS../../../..", "http://122.193.9.83:8079/MLDS");
                            //StreamWriter SW = File.CreateText("E:\\DongShan\\MLDS\\MLDS\\upload\\publish\\" + x.id + ".html");
                            //SW.WriteLine("<!doctype html>");
                            //SW.WriteLine("<html>");
                            //SW.WriteLine("<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes\"  />");
                            //SW.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                            //SW.WriteLine("<style type=\"text/css\">");
                            //SW.WriteLine("body {width: 95%;height: auto;}");
                            //SW.WriteLine("img {width: 100%; position:relative;}");
                            //SW.WriteLine("h2 {text-align:center}");
                            //SW.WriteLine(".author {text-align:center}");
                            //SW.WriteLine("</style>");
                            //SW.WriteLine("</head>");
                            //SW.WriteLine("<body><div style=\"margin:5px;\">");
                            //SW.WriteLine("<h2>" + x.title + "</h2>");
                            //SW.WriteLine("<p class=\"author\">" + ds.SYS_User.SingleOrDefault(d => d.id == x.author).name + "</p>");
                            //SW.WriteLine("<HR style=\"border: 3 double\" width=\"80 % \" SIZE=3>");
                            //SW.WriteLine(x.mainText);
                            //SW.WriteLine("</div></body></html>");
                            //SW.Close();

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
        public CommonOutputT<BUS_InternalInformation> getSingleInformation(string id)
        {
            CommonOutputT<BUS_InternalInformation> returnData = new CommonOutputT<BUS_InternalInformation>();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.BUS_InternalInformation.SingleOrDefault(d => d.id == id);
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
                    var x = ds.BUS_InternalInformation.SingleOrDefault(d => d.id == id);
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
                        var x = ds.BUS_InternalInformation.SingleOrDefault(d => d.id == id);
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

        #region 会议管理
        /*--------------列表查看-----------*/
        public PageRows<CommonInformation[]> getMeeting(string districtID, int offset, int limit, string order, string search, string sort)
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "普通会议";
                                    break;
                                case "2":
                                    i.type = "紧急会议";
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
                        IQueryable<CommonInformation> x = from a in ds.BUS_Meeting
                                                          join b in ds.SYS_District on a.districtID equals b.id into b1
                                                          from c in b1.DefaultIfEmpty()
                                                          join d in ds.SYS_User on a.author equals d.id into d1
                                                          from e in d1.DefaultIfEmpty()
                                                          where districts.Contains(a.districtID) && a.status != "0" && (a.title.Contains(search) || e.name.Contains(search) || a.createTime.Contains(search))
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
                                    i.type = "普通会议";
                                    break;
                                case "2":
                                    i.type = "紧急会议";
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                                    x = from a in ds.BUS_Meeting
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.SYS_User on a.author equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && a.status != "0"
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
                        returnData.total = x.ToArray().Length;
                        x = x.Skip(offset);
                        x = x.Take(limit);
                        returnData.rows = x.ToArray();
                        foreach (var i in returnData.rows)
                        {
                            switch (i.type)
                            {
                                case "1":
                                    i.type = "普通会议";
                                    break;
                                case "2":
                                    i.type = "紧急会议";
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
                        IQueryable<CommonInformation> x = from a in ds.BUS_Meeting
                                                          join b in ds.SYS_District on a.districtID equals b.id into b1
                                                          from c in b1.DefaultIfEmpty()
                                                          join d in ds.SYS_User on a.author equals d.id into d1
                                                          from e in d1.DefaultIfEmpty()
                                                          where districts.Contains(a.districtID) && a.status != "0"
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
                                    i.type = "普通会议";
                                    break;
                                case "2":
                                    i.type = "紧急会议";
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
        public CommonOutput addMeeting(string title, string type, string peek, string imageURL, string htmlContent, string userID, string districtID)
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
                        var x = new BUS_Meeting();
                        x.id = Guid.NewGuid().ToString();
                        x.title = title;
                        x.type = type;
                        x.peek = peek;
                        x.cover = imageURL;
                        x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        x.status = "1";
                        x.author = userID;
                        x.districtID = districtID;
                        x.mainText = HttpUtility.UrlDecode(htmlContent);
                        //x.mainText = x.mainText.Replace("MLDS/MLDS../../../..", "http://122.193.9.83:8079/MLDS");
                        //StreamWriter SW = File.CreateText("E:\\DongShan\\MLDS\\MLDS\\upload\\publish\\" + x.id + ".html");
                        //SW.WriteLine("<!doctype html>");
                        //SW.WriteLine("<html>");
                        //SW.WriteLine("<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes\"  />");
                        //SW.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                        //SW.WriteLine("<style type=\"text/css\">");
                        //SW.WriteLine("body {width: 95%;height: auto;}");
                        //SW.WriteLine("img {width: 100%; position:relative;}");
                        //SW.WriteLine("h2 {text-align:center}");
                        //SW.WriteLine(".author {text-align:center}");
                        //SW.WriteLine("</style>");
                        //SW.WriteLine("</head>");
                        //SW.WriteLine("<body><div style=\"margin:5px;\">");
                        //SW.WriteLine("<h2>" + x.title + "</h2>");
                        //SW.WriteLine("<p class=\"author\">" + ds.SYS_User.SingleOrDefault(d => d.id == x.author).name + "</p>");
                        //SW.WriteLine("<HR style=\"border: 3 double\" width=\"80 % \" SIZE=3>");
                        //SW.WriteLine(x.mainText);
                        //SW.WriteLine("</div></body></html>");
                        //SW.Close();

                        ds.BUS_Meeting.InsertOnSubmit(x);
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
        public CommonOutput editMeeting(string id, string title, string type, string peek, string imageURL, string htmlContent, string userID, string districtID)
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
                            var x = ds.BUS_Meeting.SingleOrDefault(d => d.id == id);
                            x.title = title;
                            x.type = type;
                            x.peek = peek;
                            x.cover = imageURL;
                            x.mainText = HttpUtility.UrlDecode(htmlContent);
                            x.createTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                            x.author = userID;
                            x.districtID = districtID;
                            //x.mainText = x.mainText.Replace("MLDS/MLDS../../../..", "http://122.193.9.83:8079/MLDS");
                            //StreamWriter SW = File.CreateText("E:\\DongShan\\MLDS\\MLDS\\upload\\publish\\" + x.id + ".html");
                            //SW.WriteLine("<!doctype html>");
                            //SW.WriteLine("<html>");
                            //SW.WriteLine("<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes\"  />");
                            //SW.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                            //SW.WriteLine("<style type=\"text/css\">");
                            //SW.WriteLine("body {width: 95%;height: auto;}");
                            //SW.WriteLine("img {width: 100%; position:relative;}");
                            //SW.WriteLine("h2 {text-align:center}");
                            //SW.WriteLine(".author {text-align:center}");
                            //SW.WriteLine("</style>");
                            //SW.WriteLine("</head>");
                            //SW.WriteLine("<body><div style=\"margin:5px;\">");
                            //SW.WriteLine("<h2>" + x.title + "</h2>");
                            //SW.WriteLine("<p class=\"author\">" + ds.SYS_User.SingleOrDefault(d => d.id == x.author).name + "</p>");
                            //SW.WriteLine("<HR style=\"border: 3 double\" width=\"80 % \" SIZE=3>");
                            //SW.WriteLine(x.mainText);
                            //SW.WriteLine("</div></body></html>");
                            //SW.Close();

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
        public CommonOutputT<BUS_Meeting> getSingleMeeting(string id)
        {
            CommonOutputT<BUS_Meeting> returnData = new CommonOutputT<BUS_Meeting>();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.BUS_Meeting.SingleOrDefault(d => d.id == id);
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
        public CommonOutput deleteMeeting(string id)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.BUS_Meeting.SingleOrDefault(d => d.id == id);
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
        public CommonOutput deleteMultiMeeting(string idStr)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(idStr))
            {
                try
                {
                    string[] ids = idStr.Split(',');
                    foreach (var id in ids)
                    {
                        var x = ds.BUS_Meeting.SingleOrDefault(d => d.id == id);
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

        #region 统计管理

        #region 少儿医保
        /*---------本年内少儿医保统计---------*/  // status 为0 不可用 1为正常 2 不正常
        public CommonOutputT<BUS_ChildrenInsurance_10> getChildrenInsurance_10(string districtID)
        {
            CommonOutputT<BUS_ChildrenInsurance_10> returnData = new CommonOutputT<BUS_ChildrenInsurance_10>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = new BUS_ChildrenInsurance_10();
                    x.date = new string[] {
                        DateTime.Now.AddYears(0).ToString("yyyy年")};
                    x.zhengchang = new int[]{
                        ds.BUS_ChildrenInsurance.Count(d=>d.year== DateTime.Now.AddYears(0).ToString("yyyy")&&d.status=="1"),};
                    x.buzhengchang = new int[] {
                        ds.BUS_ChildrenInsurance.Count(d=>d.year== DateTime.Now.AddYears(0).ToString("yyyy")&&d.status!="1"),};
                    x.sum = new int[]{
                        x.zhengchang.Sum(),
                        x.buzhengchang.Sum()};
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

        #region 农村医疗
        /*---------本年内农村医疗统计---------*/  // status 为0 不可用 1为正常 2 不正常
        public CommonOutputT<BUS_RuralInsurance_10> getRuralInsurance_10(string districtID)
        {
            CommonOutputT<BUS_RuralInsurance_10> returnData = new CommonOutputT<BUS_RuralInsurance_10>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = new BUS_RuralInsurance_10();
                    x.date = new string[] {
                        DateTime.Now.AddYears(0).ToString("yyyy年")};
                    x.zhengchang = new int[]{
                        ds.BUS_RuralInsurance.Count(d=>d.year== DateTime.Now.AddYears(0).ToString("yyyy")&&d.status=="1"),};
                    x.buzhengchang = new int[] {
                        ds.BUS_RuralInsurance.Count(d=>d.year== DateTime.Now.AddYears(0).ToString("yyyy")&&d.status!="1"),};
                    x.sum = new int[]{
                        x.zhengchang.Sum(),
                        x.buzhengchang.Sum()};
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

        #region 政务通知
        /*-----------十天内政务通知统计---------*/  // status 为0 不可用 1为正常 2 不正常
        public CommonOutputT<BUS_Information_10> getInformation_10(string districtID)
        {
            CommonOutputT<BUS_Information_10> returnData = new CommonOutputT<BUS_Information_10>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = new BUS_Information_10();
                    var y = new BUS_InternalInformation();
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
                    x.zongshu = new int[]{
                        ds.BUS_InternalInformation.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_InternalInformation.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_InternalInformation.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_InternalInformation.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_InternalInformation.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_InternalInformation.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_InternalInformation.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_InternalInformation.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_InternalInformation.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_InternalInformation.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.status!="0")};
                    x.sum = new int[]{
                        x.zongshu.Sum()};
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

        #region 会议公告
        /*---------十天内会议公告统计---------*/  // status 为0 不可用 1为正常 2 不正常
        public CommonOutputT<BUS_Meeting_10> getMeeting_10(string districtID)
        {
            CommonOutputT<BUS_Meeting_10> returnData = new CommonOutputT<BUS_Meeting_10>();
            if (!string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var districts = CommonMethod.getSubDistrict(districtID);
                    var x = new BUS_Meeting_10();
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

                    x.zongshu = new int[] {
                        ds.BUS_Meeting.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_Meeting.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-9).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_Meeting.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-8).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_Meeting.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_Meeting.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_Meeting.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_Meeting.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_Meeting.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_Meeting.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd")&&d.status!="0"),
                        ds.BUS_Meeting.Count(d=>d.createTime.Substring(0,10)== DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd")&&d.status!="0")};
                    x.sum = new int[]{
                     //   x.z.Sum(),
                        x.zongshu.Sum()};
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
