using System;
using System.Linq;
using MLDSData;
using MLDSService.DataContracts;
using MLDSService.Methods;
using System.Data.Linq.SqlClient;
using System.Collections.Generic;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Population”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Population.svc 或 Population.svc.cs，然后开始调试。
    public class Population : IPopulation
    {
        private static MLDSDataContext ds = new MLDSDataContext();
        #region 基础人口
        /*------------列表查看-------------*/
        public PageRows<List_BasicPopulation[]> getBasicPopulationList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_BasicPopulation[]> returnData = new PageRows<List_BasicPopulation[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_BasicPopulation> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.name ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.sex ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.IDCard ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "nation":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.nation ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "marriageStatus":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.marriageStatus ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "politicsStatus":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.politicsStatus ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby e.plot ascending, e.houseNum ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.phone ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "educationDegree":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.educationDegree ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "bookletNum":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.bookletNum ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.bookletNum ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.name descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.sex descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.IDCard descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "nation":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.nation descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "marriageStatus":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.marriageStatus descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "politicsStatus":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.politicsStatus descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby e.plot descending, e.houseNum descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby c.districtName descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.phone descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "educationDegree":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.educationDegree descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "bookletNum":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.bookletNum descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                        a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                        a.sex.Contains(search) || a.nation.Contains(search) ||
                                        a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                        a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                        e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                        a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                        a.educationDegree.Contains(search))
                                        orderby a.bookletNum descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                            }
                        }
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.total = x.ToArray<List_BasicPopulation>().Length;
                        x = x.Skip<List_BasicPopulation>(offset);
                        x = x.Take<List_BasicPopulation>(limit);
                        returnData.rows = x.ToArray<List_BasicPopulation>();
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
                        IQueryable<List_BasicPopulation> x = from a in ds.POP_Basic
                                                             join b in ds.SYS_District on a.districtID equals b.id into b1
                                                             from c in b1.DefaultIfEmpty()
                                                             join d in ds.POP_Building on a.addressID equals d.id into d1
                                                             from e in d1.DefaultIfEmpty()
                                                             where a.status != 0 && districts.Contains(a.districtID) && (a.name.Contains(search) ||
                                                             a.IDCard.Contains(search) || a.phone.Contains(search) ||
                                                             a.sex.Contains(search) || a.nation.Contains(search) ||
                                                             a.marriageStatus.Contains(search) || a.politicsStatus.Contains(search) ||
                                                             a.censusRegister.Contains(search) || e.plot.Contains(search) ||
                                                             e.houseNum.Contains(search) || a.bookletNum.Contains(search) ||
                                                             a.populationType.Contains(search) || a.workPlace.Contains(search) ||
                                                             a.educationDegree.Contains(search))
                                                             orderby a.bookletNum descending
                                                             select new List_BasicPopulation
                                                             {
                                                                 id = a.id,
                                                                 name = a.name,
                                                                 IDCard = a.IDCard,
                                                                 phone = a.phone,
                                                                 sex = a.sex,
                                                                 nation = a.nation,
                                                                 marriageStatus = a.marriageStatus,
                                                                 politicsStatus = a.politicsStatus,
                                                                 censusRegister = a.censusRegister,
                                                                 bookletNum = a.bookletNum,
                                                                 populationType = a.populationType,
                                                                 workPlace = a.workPlace,
                                                                 educationDegree = a.educationDegree,
                                                                 district = c.districtName,
                                                                 address = e.plot + e.houseNum
                                                             };

                        returnData.success = true;
                        returnData.message = "success";
                        returnData.total = x.ToArray<List_BasicPopulation>().Length;
                        x = x.Skip<List_BasicPopulation>(offset);
                        x = x.Take<List_BasicPopulation>(limit);
                        returnData.rows = x.ToArray<List_BasicPopulation>();
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
                        IQueryable<List_BasicPopulation> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.name ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.sex ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.IDCard ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "nation":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.nation ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "marriageStatus":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.marriageStatus ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "politicsStatus":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.politicsStatus ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.plot ascending, e.houseNum ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby c.districtName ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.phone ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "educationDegree":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.educationDegree ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "bookletNum":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.bookletNum ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.bookletNum ascending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.name descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.sex descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.IDCard descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "nation":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.nation descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "marriageStatus":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.marriageStatus descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "politicsStatus":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.politicsStatus descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.plot descending, e.houseNum descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby c.districtName descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.phone descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "educationDegree":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.educationDegree descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "bookletNum":
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.bookletNum descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Basic
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.bookletNum descending
                                        select new List_BasicPopulation
                                        {
                                            id = a.id,
                                            name = a.name,
                                            IDCard = a.IDCard,
                                            phone = a.phone,
                                            sex = a.sex,
                                            nation = a.nation,
                                            marriageStatus = a.marriageStatus,
                                            politicsStatus = a.politicsStatus,
                                            censusRegister = a.censusRegister,
                                            bookletNum = a.bookletNum,
                                            populationType = a.populationType,
                                            workPlace = a.workPlace,
                                            educationDegree = a.educationDegree,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                            }
                        }

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_BasicPopulation>().Length;
                        x = x.Skip<List_BasicPopulation>(offset);
                        x = x.Take<List_BasicPopulation>(limit);
                        returnData.rows = x.ToArray<List_BasicPopulation>();
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
                        IQueryable<List_BasicPopulation> x = from a in ds.POP_Basic
                                                             join b in ds.SYS_District on a.districtID equals b.id into b1
                                                             from c in b1.DefaultIfEmpty()
                                                             join d in ds.POP_Building on a.addressID equals d.id into d1
                                                             from e in d1.DefaultIfEmpty()
                                                             where a.status != 0 && districts.Contains(a.districtID)
                                                             orderby a.bookletNum descending
                                                             select new List_BasicPopulation
                                                             {
                                                                 id = a.id,
                                                                 name = a.name,
                                                                 IDCard = a.IDCard,
                                                                 phone = a.phone,
                                                                 sex = a.sex,
                                                                 nation = a.nation,
                                                                 marriageStatus = a.marriageStatus,
                                                                 politicsStatus = a.politicsStatus,
                                                                 censusRegister = a.censusRegister,
                                                                 bookletNum = a.bookletNum,
                                                                 populationType = a.populationType,
                                                                 workPlace = a.workPlace,
                                                                 educationDegree = a.educationDegree,
                                                                 district = c.districtName,
                                                                 address = e.plot + e.houseNum
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

        /*------------新增人口-------------*/
        public CommonOutput addBasicPopulation(string districtID, string name, string IDCard,
            string sex, string nation, string plot, string houseNum, string bookletNum, string relationship,
            string censusRegister, string populationType, string marriageStatus, string politicsStatus,
            string educationDegree, string phone, string workPlace)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(IDCard))
            {
                try
                {
                    var thisGuy = ds.POP_Basic.SingleOrDefault(d => d.name == name && d.IDCard == IDCard);
                    if (thisGuy == null)
                    {
                        var x = new POP_Basic();
                        x.id = Guid.NewGuid().ToString();
                        x.districtID = districtID;
                        x.name = name;
                        x.IDCard = IDCard;
                        x.sex = sex;
                        x.nation = nation;
                        //x.addressID = ds.POP_Building.SingleOrDefault(d => d.districtID == districtID && d.plot == plot && d.houseNum == houseNum).id;
                        x.bookletNum = bookletNum;
                        x.relationship = relationship;
                        x.censusRegister = censusRegister;
                        x.populationType = populationType;
                        x.marriageStatus = marriageStatus;
                        x.politicsStatus = politicsStatus;
                        x.educationDegree = educationDegree;
                        x.status = 1;
                        x.phone = phone;
                        x.workPlace = workPlace;
                        ds.POP_Basic.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                    }
                    else
                    {
                        if (thisGuy.status == 0)
                        {
                            var x = new POP_Basic();
                            x.id = Guid.NewGuid().ToString();
                            x.districtID = districtID;
                            x.name = name;
                            x.IDCard = IDCard;
                            x.sex = sex;
                            x.nation = nation;
                            //x.addressID = ds.POP_Building.SingleOrDefault(d => d.districtID == districtID && d.plot == plot && d.houseNum == houseNum).id;
                            x.bookletNum = bookletNum;
                            x.relationship = relationship;
                            x.censusRegister = censusRegister;
                            x.populationType = populationType;
                            x.marriageStatus = marriageStatus;
                            x.politicsStatus = politicsStatus;
                            x.educationDegree = educationDegree;
                            x.status = 1;
                            x.phone = phone;
                            x.workPlace = workPlace;
                            ds.POP_Basic.InsertOnSubmit(x);
                            ds.SubmitChanges();
                            returnData.success = true;
                            returnData.message = "success";
                        }
                        else
                        {
                            returnData.success = false;
                            returnData.message = "Error:人口库中已存在此信息，请勿重复添加！";
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

        /*------------编辑人口-------------*/
        public CommonOutput editBasicPopulation(string id, string districtID, string name, string IDCard,
           string sex, string nation, string plot, string houseNum, string bookletNum, string relationship,
           string censusRegister, string populationType, string marriageStatus, string politicsStatus,
           string educationDegree, string phone, string workPlace)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(IDCard))
            {
                try
                {
                    var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
                    x.districtID = districtID;
                    x.name = name;
                    x.IDCard = IDCard;
                    x.sex = sex;
                    x.nation = nation;
                    x.addressID = ds.POP_Building.SingleOrDefault(d => d.districtID == districtID && d.plot == plot && d.houseNum == houseNum).id;
                    x.bookletNum = bookletNum;
                    x.relationship = relationship;
                    x.censusRegister = censusRegister;
                    x.populationType = populationType;
                    x.marriageStatus = marriageStatus;
                    x.politicsStatus = politicsStatus;
                    x.educationDegree = educationDegree;
                    x.phone = phone;
                    x.workPlace = workPlace;
                    ds.POP_Basic.InsertOnSubmit(x);
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

        /*------------删除人口-------------*/
        public CommonOutput deleteBasicPopulation(string id)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
                    if (x != null)
                    {
                        x.status = 0;
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
        /*------------批量删除人口-------------*/
        public CommonOutput deleteMultiBasicPopulation(string idStr)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(idStr))
            {
                try
                {
                    string[] ids = idStr.Split(',');
                    foreach (var id in ids)
                    {
                        var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
                        if (x != null)
                        {
                            x.status = 0;
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

        /*------------根据身份证获取个人信息--------------*/
        public CommonOutputT<POP_Basic> getSinglePopulationByIDCard(string IDCard, string districtID)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            CommonOutputT<POP_Basic> returnData = new CommonOutputT<POP_Basic>();
            if (!string.IsNullOrEmpty(IDCard) || !string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var x = ds.POP_Basic.SingleOrDefault(d => d.IDCard == IDCard && districts.Contains(d.districtID) && d.status != 0);
                    if (x != null)
                    {
                        POP_Basic thisGuy = new POP_Basic();
                        thisGuy.id = x.id;
                        thisGuy.name = x.name;
                        thisGuy.sex = x.sex;
                        thisGuy.nation = x.nation;
                        thisGuy.phone = x.phone;
                        thisGuy.workPlace = x.workPlace;
                        returnData.data = thisGuy;
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;

                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:不存在此人信息，请现在基础人口中登记！";
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
                returnData.message = "Error:输入了无效信息！";
                return returnData;
            }
        }

        /*------------根据id获取个人信息--------------*/
        public CommonOutputT<List_BasicPopulation[]> getSinglePopulationByID(string id, string districtID)
        {
            CommonOutputT<List_BasicPopulation[]> returnData = new CommonOutputT<List_BasicPopulation[]>();
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.POP_Basic.SingleOrDefault(d => d.id == id && d.status != 0);
                    var districts = CommonMethod.getSubDistrict(districtID);
                    if (x != null)
                    {
                        var y = from a in ds.POP_Basic
                                join b in ds.SYS_District on a.districtID equals b.id into b1
                                from c in b1.DefaultIfEmpty()
                                join d in ds.POP_Building on a.addressID equals d.id into d1
                                from e in d1.DefaultIfEmpty()
                                where a.status != 0 && a.id == id && districts.Contains(a.districtID)
                                select new List_BasicPopulation
                                {
                                    id = a.id,
                                    name = a.name,
                                    IDCard = a.IDCard,
                                    phone = a.phone,
                                    sex = a.sex,
                                    nation = a.nation,
                                    marriageStatus = a.marriageStatus,
                                    politicsStatus = a.politicsStatus,
                                    censusRegister = a.censusRegister,
                                    bookletNum = a.bookletNum,
                                    populationType = a.populationType,
                                    workPlace = a.workPlace,
                                    educationDegree = a.educationDegree,
                                    district = c.districtName,
                                    address = e.plot + e.houseNum
                                };
                        returnData.data = y.ToArray();
                        //returnData.data.id = x.id;
                        //returnData.data.name = x.name;
                        //returnData.data.IDCard = x.IDCard;
                        //returnData.data.phone = x.phone;
                        //returnData.data.sex = x.sex;
                        //returnData.data.nation = x.nation;
                        //returnData.data.marriageStatus = x.marriageStatus;
                        //returnData.data.politicsStatus = x.politicsStatus;
                        //returnData.data.censusRegister = x.censusRegister;
                        //returnData.data.bookletNum = x.bookletNum;
                        //returnData.data.populationType = x.populationType;
                        //returnData.data.workPlace = x.workPlace;
                        //returnData.data.educationDegree = x.educationDegree;
                        ////returnData.data.district = ds.SYS_District.SingleOrDefault(d => d.id == x.districtID).districtName;
                        ////returnData.data.address = ds.POP_Building.SingleOrDefault(d => d.id == x.addressID).plot + ds.POP_Building.SingleOrDefault(d => d.id == x.addressID).houseNum;
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;

                    }
                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:不存在此人信息，请现在基础人口中登记！";
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
                returnData.message = "Error:输入了无效信息！";
                return returnData;
            }
        }

        #endregion

        #region 家庭档案
        /*------------列表查看-------------*/
        public PageRows<List_Family[]> getFamilyList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Family[]> returnData = new PageRows<List_Family[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Family> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "bookletNum":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby a.bookletNum ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "bookletType":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby a.bookletType ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolder":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby g.name ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolderIDCard":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby g.IDCard ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolderPhone":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby g.phone ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby e.plot ascending, e.houseNum ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;

                                default:
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby a.bookletNum ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                            }

                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "bookletNum":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby a.bookletNum descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "bookletType":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby a.bookletType descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolder":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby g.name descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolderIDCard":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby g.IDCard descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolderPhone":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby g.phone descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby c.districtName descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby e.plot descending, e.houseNum descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;

                                default:
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                        a.bookletType.Contains(search) || g.name.Contains(search) ||
                                        g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                        e.plot.Contains(search) || e.houseNum.Contains(search))
                                        orderby a.bookletNum descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                            }
                        }
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.total = x.ToArray<List_Family>().Length;
                        x = x.Skip<List_Family>(offset);
                        x = x.Take<List_Family>(limit);
                        returnData.rows = x.ToArray<List_Family>();
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
                        IQueryable<List_Family> x = from a in ds.POP_Family
                                                    join b in ds.SYS_District on a.districtID equals b.id into b1
                                                    from c in b1.DefaultIfEmpty()
                                                    join d in ds.POP_Building on a.addressID equals d.id into d1
                                                    from e in d1.DefaultIfEmpty()
                                                    join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                                    from g in f1.DefaultIfEmpty()
                                                    where a.status != 0 && districts.Contains(a.districtID) && (a.bookletNum.Contains(search) ||
                                                    a.bookletType.Contains(search) || g.name.Contains(search) ||
                                                    g.IDCard.Contains(search) || g.phone.Contains(search) ||
                                                    e.plot.Contains(search) || e.houseNum.Contains(search))
                                                    orderby a.bookletNum descending
                                                    select new List_Family
                                                    {
                                                        id = a.id,
                                                        bookletType = a.bookletType,
                                                        bookletNum = a.bookletNum,
                                                        houseHolder = g.name,
                                                        houseHolderIDCard = g.IDCard,
                                                        houseHolderPhone = g.phone,
                                                        district = c.districtName,
                                                        address = e.plot + e.houseNum
                                                    };

                        returnData.success = true;
                        returnData.message = "success";
                        returnData.total = x.ToArray<List_Family>().Length;
                        x = x.Skip<List_Family>(offset);
                        x = x.Take<List_Family>(limit);
                        returnData.rows = x.ToArray<List_Family>();
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
                        IQueryable<List_Family> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "bookletNum":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.bookletNum ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "bookletType":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.bookletType ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolder":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby g.name ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolderIDCard":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby g.IDCard ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolderPhone":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby g.phone ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby c.districtName ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.plot ascending, e.houseNum ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;

                                default:
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.bookletNum ascending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "bookletNum":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.bookletNum descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "bookletType":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.bookletType descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolder":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby g.name descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolderIDCard":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby g.IDCard descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "houseHolderPhone":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby g.phone descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby c.districtName descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.plot descending, e.houseNum descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;

                                default:
                                    x = from a in ds.POP_Family
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Building on a.addressID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.bookletNum descending
                                        select new List_Family
                                        {
                                            id = a.id,
                                            bookletType = a.bookletType,
                                            bookletNum = a.bookletNum,
                                            houseHolder = g.name,
                                            houseHolderIDCard = g.IDCard,
                                            houseHolderPhone = g.phone,
                                            district = c.districtName,
                                            address = e.plot + e.houseNum
                                        };
                                    break;
                            }
                        }

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_Family>().Length;
                        x = x.Skip<List_Family>(offset);
                        x = x.Take<List_Family>(limit);
                        returnData.rows = x.ToArray<List_Family>();
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
                        IQueryable<List_Family> x = from a in ds.POP_Family
                                                    join b in ds.SYS_District on a.districtID equals b.id into b1
                                                    from c in b1.DefaultIfEmpty()
                                                    join d in ds.POP_Building on a.addressID equals d.id into d1
                                                    from e in d1.DefaultIfEmpty()
                                                    join f in ds.POP_Basic on a.houseHolderID equals f.id into f1
                                                    from g in f1.DefaultIfEmpty()
                                                    where a.status != 0 && districts.Contains(a.districtID)
                                                    orderby a.bookletNum descending
                                                    select new List_Family
                                                    {
                                                        id = a.id,
                                                        bookletType = a.bookletType,
                                                        bookletNum = a.bookletNum,
                                                        houseHolder = g.name,
                                                        houseHolderIDCard = g.IDCard,
                                                        houseHolderPhone = g.phone,
                                                        district = c.districtName,
                                                        address = e.plot + e.houseNum
                                                    };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_Family>().Length;
                        x = x.Skip<List_Family>(offset);
                        x = x.Take<List_Family>(limit);
                        returnData.rows = x.ToArray<List_Family>();
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

        /*------------查看家庭人员-------------*/
        public PageRows<List_FamilyMember[]> getFamilyMember(string bookletNum)
        {
            PageRows<List_FamilyMember[]> returnData = new PageRows<List_FamilyMember[]>();
            if (!String.IsNullOrEmpty(bookletNum))
            {
                try
                {
                    var x = from a in ds.POP_Basic
                            where a.bookletNum == bookletNum
                            select new List_FamilyMember
                            {
                                id = a.id,
                                IDCard = a.IDCard,
                                name = a.name,
                                sex = a.sex,
                                relationship = a.relationship,
                                age = CommonMethod.IDCard2Age(a.IDCard)
                            };
                    returnData.success = true;
                    returnData.message = "success";
                    returnData.rows = x.ToArray<List_FamilyMember>();
                    returnData.total = x.ToArray<List_FamilyMember>().Length;
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
                returnData.message = "Error:请至少选择一个目标！";
                return returnData;
            }
        }

        /*------------新增人口-------------*/

        /*------------编辑人口-------------*/

        /*------------删除人口-------------*/
        //public CommonOutput deleteBasicPopulation(string id)
        //{
        //    CommonOutput returnData = new CommonOutput();
        //    if (!String.IsNullOrEmpty(id))
        //    {
        //        try
        //        {
        //            var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
        //            if (x != null)
        //            {
        //                x.status = 0;
        //                ds.SubmitChanges();
        //                returnData.success = true;
        //                returnData.message = "success";
        //                return returnData;
        //            }
        //            else
        //            {
        //                returnData.success = false;
        //                returnData.message = "Error:目标不存在，请重试！";
        //                return returnData;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            returnData.success = false;
        //            returnData.message = "Error:" + ex.Message;
        //            return returnData;
        //        }

        //    }
        //    else
        //    {
        //        returnData.success = false;
        //        returnData.message = "Error:目标选择错误，请重试！";
        //        return returnData;
        //    }
        //}
        ///*------------批量删除人口-------------*/
        //public CommonOutput deleteMultiBasicPopulation(string idStr)
        //{
        //    CommonOutput returnData = new CommonOutput();
        //    if (!String.IsNullOrEmpty(idStr))
        //    {
        //        try
        //        {
        //            string[] ids = idStr.Split(',');
        //            foreach (var id in ids)
        //            {
        //                var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
        //                if (x != null)
        //                {
        //                    x.status = 0;
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //            ds.SubmitChanges();
        //            returnData.success = true;
        //            returnData.message = "success";
        //            return returnData;
        //        }
        //        catch (Exception ex)
        //        {
        //            returnData.success = false;
        //            returnData.message = "Error:" + ex.Message;
        //            return returnData;
        //        }
        //    }
        //    else
        //    {
        //        returnData.success = false;
        //        returnData.message = "Error:目标选择错误，请重试！";
        //        return returnData;
        //    }
        //}
        #endregion

        #region 党员管理
        /*------------列表查看-------------*/
        public PageRows<List_PartyMember[]> getPartyMemberList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_PartyMember[]> returnData = new PageRows<List_PartyMember[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IEnumerable<List_PartyMember> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby e.name ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby e.sex ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby e.IDCard ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "joinTime":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby a.joinTime ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby CommonMethod.joinTime2partyAge(a.joinTime) ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "partyAge":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby CommonMethod.joinTime2partyAge(a.joinTime) ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "department":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby a.department ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby e.name ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby e.name descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby e.sex descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby e.IDCard descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "joinTime":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby a.joinTime descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby CommonMethod.IDCard2Age(e.IDCard) descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "partyAge":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby CommonMethod.joinTime2partyAge(a.joinTime) descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "department":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby a.department descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby c.districtName descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Party
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                        CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                        a.department.Contains(search))
                                        orderby e.name descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.total = x.ToArray<List_PartyMember>().Length;
                        x = x.Skip<List_PartyMember>(offset);
                        x = x.Take<List_PartyMember>(limit);
                        returnData.rows = x.ToArray<List_PartyMember>();
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
                        IQueryable<List_PartyMember> x = from a in ds.POP_Party
                                                         join b in ds.SYS_District on a.districtID equals b.id into b1
                                                         from c in b1.DefaultIfEmpty()
                                                         join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                         from e in d1.DefaultIfEmpty()
                                                         join f in ds.POP_Building on e.addressID equals f.id into f1
                                                         from g in f1.DefaultIfEmpty()
                                                         where a.status != 0 && districts.Contains(a.districtID) && (
                                                         e.name.Contains(search) || e.sex.Contains(search) ||
                                                         e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                                         CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ||
                                                         CommonMethod.joinTime2partyAge(a.joinTime).ToString().Contains(search) ||
                                                         a.department.Contains(search))
                                                         orderby e.name descending
                                                         select new List_PartyMember
                                                         {
                                                             id = a.id,
                                                             name = e.name,
                                                             sex = e.sex,
                                                             IDCard = e.IDCard,
                                                             joinTime = a.joinTime,
                                                             age = CommonMethod.IDCard2Age(e.IDCard),
                                                             partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                                             department = a.department,
                                                             district = c.districtName
                                                         };
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.total = x.ToArray<List_PartyMember>().Length;
                        x = x.Skip<List_PartyMember>(offset);
                        x = x.Take<List_PartyMember>(limit);
                        returnData.rows = x.ToArray<List_PartyMember>();
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
                        IEnumerable<List_PartyMember> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.name ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.sex ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.IDCard ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "joinTime":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.joinTime ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby CommonMethod.IDCard2Age(e.IDCard) ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "partyAge":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby CommonMethod.joinTime2partyAge(a.joinTime) ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "department":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.department ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby c.districtName ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.name ascending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.name descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.sex descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.IDCard descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "joinTime":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.joinTime descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby CommonMethod.IDCard2Age(e.IDCard) descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "partyAge":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby CommonMethod.joinTime2partyAge(a.joinTime) descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "department":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby a.department descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby c.districtName descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Party.AsEnumerable()
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        join f in ds.POP_Building on e.addressID equals f.id into f1
                                        from g in f1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID)
                                        orderby e.name descending
                                        select new List_PartyMember
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                            department = a.department,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_PartyMember>().Length;
                        x = x.Skip<List_PartyMember>(offset);
                        x = x.Take<List_PartyMember>(limit);
                        returnData.rows = x.ToArray<List_PartyMember>();
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
                        IQueryable<List_PartyMember> x = from a in ds.POP_Party
                                                         join b in ds.SYS_District on a.districtID equals b.id into b1
                                                         from c in b1.DefaultIfEmpty()
                                                         join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                         from e in d1.DefaultIfEmpty()
                                                         join f in ds.POP_Building on e.addressID equals f.id into f1
                                                         from g in f1.DefaultIfEmpty()
                                                         where a.status != 0 && districts.Contains(a.districtID)
                                                         orderby e.name descending
                                                         select new List_PartyMember
                                                         {
                                                             id = a.id,
                                                             name = e.name,
                                                             sex = e.sex,
                                                             IDCard = e.IDCard,
                                                             joinTime = a.joinTime,
                                                             age = CommonMethod.IDCard2Age(e.IDCard),
                                                             partyAge = CommonMethod.joinTime2partyAge(a.joinTime),
                                                             department = a.department,
                                                             district = c.districtName
                                                         };

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_PartyMember>().Length;
                        x = x.Skip<List_PartyMember>(offset);
                        x = x.Take<List_PartyMember>(limit);
                        returnData.rows = x.ToArray<List_PartyMember>();
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
        /*------------新增党员-------------*/
        public CommonOutput addPartyMember(string districtID, string populationID, string joinTime, string department, string portrait)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(populationID) || !string.IsNullOrEmpty(joinTime) || !string.IsNullOrEmpty(department) || !string.IsNullOrEmpty(districtID))
            {
                try
                {
                    var thisGuy = ds.POP_Party.SingleOrDefault(d => d.populationID == populationID);
                    if (thisGuy == null)
                    {
                        var x = new POP_Party();
                        x.id = Guid.NewGuid().ToString();
                        x.districtID = districtID;
                        x.populationID = populationID;
                        x.portrait = portrait;
                        x.joinTime = joinTime;
                        x.department = department;
                        x.status = 1;
                        ds.POP_Party.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                    }
                    else
                    {
                        if (thisGuy.status == 0)
                        {
                            var x = new POP_Party();
                            x.id = Guid.NewGuid().ToString();
                            x.districtID = districtID;
                            x.populationID = populationID;
                            x.portrait = portrait;
                            x.joinTime = joinTime;
                            x.department = department;
                            x.status = 1;
                            ds.POP_Party.InsertOnSubmit(x);
                            ds.SubmitChanges();
                            returnData.success = true;
                            returnData.message = "success";
                        }
                        else
                        {
                            returnData.success = false;
                            returnData.message = "Error:党员库中已存在此信息，请勿重复添加！";
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
                returnData.message = "Error:信息不全，请填写基础信息！";
                return returnData;
            }
        }
        /*------------编辑人口-------------*/

        /*------------删除人口-------------*/
        //public CommonOutput deleteBasicPopulation(string id)
        //{
        //    CommonOutput returnData = new CommonOutput();
        //    if (!String.IsNullOrEmpty(id))
        //    {
        //        try
        //        {
        //            var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
        //            if (x != null)
        //            {
        //                x.status = 0;
        //                ds.SubmitChanges();
        //                returnData.success = true;
        //                returnData.message = "success";
        //                return returnData;
        //            }
        //            else
        //            {
        //                returnData.success = false;
        //                returnData.message = "Error:目标不存在，请重试！";
        //                return returnData;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            returnData.success = false;
        //            returnData.message = "Error:" + ex.Message;
        //            return returnData;
        //        }

        //    }
        //    else
        //    {
        //        returnData.success = false;
        //        returnData.message = "Error:目标选择错误，请重试！";
        //        return returnData;
        //    }
        //}
        ///*------------批量删除人口-------------*/
        //public CommonOutput deleteMultiBasicPopulation(string idStr)
        //{
        //    CommonOutput returnData = new CommonOutput();
        //    if (!String.IsNullOrEmpty(idStr))
        //    {
        //        try
        //        {
        //            string[] ids = idStr.Split(',');
        //            foreach (var id in ids)
        //            {
        //                var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
        //                if (x != null)
        //                {
        //                    x.status = 0;
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //            ds.SubmitChanges();
        //            returnData.success = true;
        //            returnData.message = "success";
        //            return returnData;
        //        }
        //        catch (Exception ex)
        //        {
        //            returnData.success = false;
        //            returnData.message = "Error:" + ex.Message;
        //            return returnData;
        //        }
        //    }
        //    else
        //    {
        //        returnData.success = false;
        //        returnData.message = "Error:目标选择错误，请重试！";
        //        return returnData;
        //    }
        //}
        #endregion

        #region 民兵管理
        /*------------列表查看-------------*/
        public PageRows<List_Military[]> getMilitaryList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Military[]> returnData = new PageRows<List_Military[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Military> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.name ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.sex ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.IDCard ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "joinTime":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.joinTime ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "leaveTime":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.leaveTime ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby CommonMethod.IDCard2Age(e.IDCard) ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isActive":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.isActive ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isBasic":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.isBasic ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isDisable":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.isDisable ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby c.districtName ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.name ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.name descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.sex descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.IDCard descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "joinTime":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.joinTime descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "leaveTime":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.leaveTime descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby CommonMethod.IDCard2Age(e.IDCard) descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isActive":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.isActive descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isBasic":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.isBasic descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isDisable":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.isDisable descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby c.districtName descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                        a.leaveTime.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.name descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.total = x.ToArray<List_Military>().Length;
                        x = x.Skip<List_Military>(offset);
                        x = x.Take<List_Military>(limit);
                        returnData.rows = x.ToArray<List_Military>();
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
                        IQueryable<List_Military> x = from a in ds.POP_Military
                                                      join b in ds.SYS_District on a.districtID equals b.id into b1
                                                      from c in b1.DefaultIfEmpty()
                                                      join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                      from e in d1.DefaultIfEmpty()
                                                      where a.status != 0 && districts.Contains(a.districtID) && (
                                                      e.name.Contains(search) || e.sex.Contains(search) ||
                                                      e.IDCard.Contains(search) || a.joinTime.Contains(search) ||
                                                      a.leaveTime.Contains(search) ||
                                                      CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                                      orderby e.name descending
                                                      select new List_Military
                                                      {
                                                          id = a.id,
                                                          name = e.name,
                                                          sex = e.sex,
                                                          IDCard = e.IDCard,
                                                          joinTime = a.joinTime,
                                                          leaveTime = a.leaveTime,
                                                          age = CommonMethod.IDCard2Age(e.IDCard),
                                                          isActive = a.isActive,
                                                          isBasic = a.isBasic,
                                                          isDisable = a.isDisable,
                                                          district = c.districtName
                                                      };
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.total = x.ToArray<List_Military>().Length;
                        x = x.Skip<List_Military>(offset);
                        x = x.Take<List_Military>(limit);
                        returnData.rows = x.ToArray<List_Military>();
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
                        IQueryable<List_Military> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.name ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.sex ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.IDCard ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "joinTime":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.joinTime ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "leaveTime":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.leaveTime ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby CommonMethod.IDCard2Age(e.IDCard) ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isActive":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.isActive ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isBasic":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.isBasic ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isDisable":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.isDisable ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby c.districtName ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.name ascending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.name descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.sex descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.IDCard descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "joinTime":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.joinTime descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "leaveTime":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.leaveTime descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby CommonMethod.IDCard2Age(e.IDCard) descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isActive":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.isActive descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isBasic":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.isBasic descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "isDisable":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.isDisable descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby c.districtName descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Military
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.name descending
                                        select new List_Military
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            joinTime = a.joinTime,
                                            leaveTime = a.leaveTime,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            isActive = a.isActive,
                                            isBasic = a.isBasic,
                                            isDisable = a.isDisable,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_Military>().Length;
                        x = x.Skip<List_Military>(offset);
                        x = x.Take<List_Military>(limit);
                        returnData.rows = x.ToArray<List_Military>();
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
                        IQueryable<List_Military> x = from a in ds.POP_Military
                                                      join b in ds.SYS_District on a.districtID equals b.id into b1
                                                      from c in b1.DefaultIfEmpty()
                                                      join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                      from e in d1.DefaultIfEmpty()
                                                      where a.status != 0
                                                      orderby e.name descending
                                                      select new List_Military
                                                      {
                                                          id = a.id,
                                                          name = e.name,
                                                          sex = e.sex,
                                                          IDCard = e.IDCard,
                                                          joinTime = a.joinTime,
                                                          leaveTime = a.leaveTime,
                                                          age = CommonMethod.IDCard2Age(e.IDCard),
                                                          isActive = a.isActive,
                                                          isBasic = a.isBasic,
                                                          isDisable = a.isDisable,
                                                          district = c.districtName
                                                      };
                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_Military>().Length;
                        x = x.Skip<List_Military>(offset);
                        x = x.Take<List_Military>(limit);
                        returnData.rows = x.ToArray<List_Military>();
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
        /*------------新增人口-------------*/

        /*------------编辑人口-------------*/

        /*------------删除人口-------------*/
        //public CommonOutput deleteBasicPopulation(string id)
        //{
        //    CommonOutput returnData = new CommonOutput();
        //    if (!String.IsNullOrEmpty(id))
        //    {
        //        try
        //        {
        //            var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
        //            if (x != null)
        //            {
        //                x.status = 0;
        //                ds.SubmitChanges();
        //                returnData.success = true;
        //                returnData.message = "success";
        //                return returnData;
        //            }
        //            else
        //            {
        //                returnData.success = false;
        //                returnData.message = "Error:目标不存在，请重试！";
        //                return returnData;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            returnData.success = false;
        //            returnData.message = "Error:" + ex.Message;
        //            return returnData;
        //        }

        //    }
        //    else
        //    {
        //        returnData.success = false;
        //        returnData.message = "Error:目标选择错误，请重试！";
        //        return returnData;
        //    }
        //}
        ///*------------批量删除人口-------------*/
        //public CommonOutput deleteMultiBasicPopulation(string idStr)
        //{
        //    CommonOutput returnData = new CommonOutput();
        //    if (!String.IsNullOrEmpty(idStr))
        //    {
        //        try
        //        {
        //            string[] ids = idStr.Split(',');
        //            foreach (var id in ids)
        //            {
        //                var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
        //                if (x != null)
        //                {
        //                    x.status = 0;
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //            ds.SubmitChanges();
        //            returnData.success = true;
        //            returnData.message = "success";
        //            return returnData;
        //        }
        //        catch (Exception ex)
        //        {
        //            returnData.success = false;
        //            returnData.message = "Error:" + ex.Message;
        //            return returnData;
        //        }
        //    }
        //    else
        //    {
        //        returnData.success = false;
        //        returnData.message = "Error:目标选择错误，请重试！";
        //        return returnData;
        //    }
        //}
        #endregion

        #region 工作人员
        /*------------列表查看-------------*/
        public PageRows<List_Leader[]> getLeaderList(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Leader[]> returnData = new PageRows<List_Leader[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Leader> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.name ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.sex ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.IDCard ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.phone ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby c.districtName ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "duty":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.duty ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.duty ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.name descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.sex descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.IDCard descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby e.phone descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby c.districtName descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "duty":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.duty descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0 && districts.Contains(a.districtID) && (
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                        CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                        orderby a.duty descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                            }
                        }
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.total = x.ToArray<List_Leader>().Length;
                        x = x.Skip<List_Leader>(offset);
                        x = x.Take<List_Leader>(limit);
                        returnData.rows = x.ToArray<List_Leader>();
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
                        IQueryable<List_Leader> x = from a in ds.POP_Leader
                                                    join b in ds.SYS_District on a.districtID equals b.id into b1
                                                    from c in b1.DefaultIfEmpty()
                                                    join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                    from e in d1.DefaultIfEmpty()
                                                    where a.status != 0 && districts.Contains(a.districtID) && (
                                                    e.name.Contains(search) || e.sex.Contains(search) ||
                                                    e.IDCard.Contains(search) || c.districtName.Contains(search) ||
                                                    CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search))
                                                    orderby a.duty descending
                                                    select new List_Leader
                                                    {
                                                        id = a.id,
                                                        name = e.name,
                                                        sex = e.sex,
                                                        IDCard = e.IDCard,
                                                        age = CommonMethod.IDCard2Age(e.IDCard),
                                                        phone = e.phone,
                                                        portrait = a.portrait,
                                                        district = c.districtName,
                                                        duty = a.duty
                                                    };
                        returnData.success = true;
                        returnData.message = "success";
                        returnData.total = x.ToArray<List_Leader>().Length;
                        x = x.Skip<List_Leader>(offset);
                        x = x.Take<List_Leader>(limit);
                        returnData.rows = x.ToArray<List_Leader>();
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
                        IQueryable<List_Leader> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.name ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.sex ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.IDCard ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.phone ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby c.districtName ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "duty":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.duty ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.duty ascending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.name descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.sex descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.IDCard descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "age":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby CommonMethod.IDCard2Age(e.IDCard).ToString().Contains(search) descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby e.phone descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby c.districtName descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                case "duty":
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.duty descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Leader
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where a.status != 0
                                        orderby a.duty descending
                                        select new List_Leader
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            age = CommonMethod.IDCard2Age(e.IDCard),
                                            phone = e.phone,
                                            portrait = a.portrait,
                                            district = c.districtName,
                                            duty = a.duty
                                        };
                                    break;
                            }
                        }

                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_Leader>().Length;
                        x = x.Skip<List_Leader>(offset);
                        x = x.Take<List_Leader>(limit);
                        returnData.rows = x.ToArray<List_Leader>();
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
                        IQueryable<List_Leader> x = from a in ds.POP_Leader
                                                    join b in ds.SYS_District on a.districtID equals b.id into b1
                                                    from c in b1.DefaultIfEmpty()
                                                    join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                    from e in d1.DefaultIfEmpty()
                                                    where a.status != 0
                                                    orderby a.duty descending
                                                    select new List_Leader
                                                    {
                                                        id = a.id,
                                                        name = e.name,
                                                        sex = e.sex,
                                                        IDCard = e.IDCard,
                                                        age = CommonMethod.IDCard2Age(e.IDCard),
                                                        phone = e.phone,
                                                        portrait = a.portrait,
                                                        district = c.districtName,
                                                        duty = a.duty
                                                    };
                        returnData.success = true;
                        returnData.message = "Success";
                        returnData.total = x.ToArray<List_Leader>().Length;
                        x = x.Skip<List_Leader>(offset);
                        x = x.Take<List_Leader>(limit);
                        returnData.rows = x.ToArray<List_Leader>();
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
        /*------------新增人口-------------*/

        /*------------编辑人口-------------*/

        /*------------删除人口-------------*/
        //public CommonOutput deleteBasicPopulation(string id)
        //{
        //    CommonOutput returnData = new CommonOutput();
        //    if (!String.IsNullOrEmpty(id))
        //    {
        //        try
        //        {
        //            var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
        //            if (x != null)
        //            {
        //                x.status = 0;
        //                ds.SubmitChanges();
        //                returnData.success = true;
        //                returnData.message = "success";
        //                return returnData;
        //            }
        //            else
        //            {
        //                returnData.success = false;
        //                returnData.message = "Error:目标不存在，请重试！";
        //                return returnData;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            returnData.success = false;
        //            returnData.message = "Error:" + ex.Message;
        //            return returnData;
        //        }

        //    }
        //    else
        //    {
        //        returnData.success = false;
        //        returnData.message = "Error:目标选择错误，请重试！";
        //        return returnData;
        //    }
        //}
        ///*------------批量删除人口-------------*/
        //public CommonOutput deleteMultiBasicPopulation(string idStr)
        //{
        //    CommonOutput returnData = new CommonOutput();
        //    if (!String.IsNullOrEmpty(idStr))
        //    {
        //        try
        //        {
        //            string[] ids = idStr.Split(',');
        //            foreach (var id in ids)
        //            {
        //                var x = ds.POP_Basic.SingleOrDefault(d => d.id == id);
        //                if (x != null)
        //                {
        //                    x.status = 0;
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //            ds.SubmitChanges();
        //            returnData.success = true;
        //            returnData.message = "success";
        //            return returnData;
        //        }
        //        catch (Exception ex)
        //        {
        //            returnData.success = false;
        //            returnData.message = "Error:" + ex.Message;
        //            return returnData;
        //        }
        //    }
        //    else
        //    {
        //        returnData.success = false;
        //        returnData.message = "Error:目标选择错误，请重试！";
        //        return returnData;
        //    }
        //}
        #endregion

        #region 残疾人
        /*------------列表查看-------------*/
        public PageRows<List_Disable[]> getDisabled(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Disable[]> returnData = new PageRows<List_Disable[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Disable> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby e.sex ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                //case "address":
                                //    x = from a in ds.POP_Disabled
                                //        join b in ds.SYS_District on a.districtID equals b.id into b1
                                //        from c in b1.DefaultIfEmpty()
                                //        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                //        from e in d1.DefaultIfEmpty()
                                //        where districts.Contains(a.districtID) && c.id==districtID&&(  //字符串拼接成地址
                                //        e.name.Contains(search) || e.sex.Contains(search) ||
                                //        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                //        orderby .address ascending
                                //        select new List_Disable
                                //        {
                                //            id = a.id,
                                //            name = e.name,
                                //            sex = e.sex,
                                //            IDCard = e.IDCard,
                                //      //      address =f.districtName,
                                //            disableNum = a.disableNum,
                                //            disablelevel = a.disablelevel,
                                //            relieffunds = a.relieffunds,
                                //            guardian = a.guardian,
                                //            explain = a.explain,
                                //            district=c.districtName
                                //        };
                                //    break;
                                case "disableNum":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby a.disableNum ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "disablelevel":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby a.disablelevel ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "relieffunds":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby a.relieffunds ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "guardian":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby a.guardian ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "explain":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby a.explain ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby e.IDCard descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby e.sex descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                //case "address":
                                //    x = from a in ds.POP_Disabled
                                //        join b in ds.SYS_District on a.districtID equals b.id into b1
                                //        from c in b1.DefaultIfEmpty()
                                //        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                //        from e in d1.DefaultIfEmpty()
                                //        where districts.Contains(a.districtID) && c.id==districtID&&(  //字符串拼接成地址
                                //        e.name.Contains(search) || e.sex.Contains(search) ||
                                //        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                //        orderby .address ascending
                                //        select new List_Disable
                                //        {
                                //            id = a.id,
                                //            name = e.name,
                                //            sex = e.sex,
                                //            IDCard = e.IDCard,
                                //      //      address =f.districtName,
                                //            disableNum = a.disableNum,
                                //            disablelevel = a.disablelevel,
                                //            relieffunds = a.relieffunds,
                                //            guardian = a.guardian,
                                //            explain = a.explain,
                                //            district=c.districtName
                                //        };
                                //    break;
                                case "disableNum":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby a.disableNum descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "disablelevel":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby a.disablelevel descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "relieffunds":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby a.relieffunds descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "guardian":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby a.guardian descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "explain":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby a.explain descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                        e.name.Contains(search) || e.sex.Contains(search) ||
                                        e.IDCard.Contains(search) || c.districtName.Contains(search))
                                        orderby e.name descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        returnData.success = true;
                        returnData.message = "success";
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
                        IQueryable<List_Disable> x = from a in ds.POP_Disabled
                                                     join b in ds.SYS_District on a.districtID equals b.id into b1
                                                     from c in b1.DefaultIfEmpty()
                                                     join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                     from e in d1.DefaultIfEmpty()
                                                     where districts.Contains(a.districtID) && (  //字符串拼接成地址
                                                     e.name.Contains(search) || e.sex.Contains(search) ||
                                                     e.IDCard.Contains(search) || c.districtName.Contains(search))
                                                     orderby c.districtName ascending
                                                     select new List_Disable
                                                     {
                                                         id = a.id,
                                                         name = e.name,
                                                         sex = e.sex,
                                                         IDCard = e.IDCard,
                                                         //      address =f.districtName,
                                                         disableNum = a.disableNum,
                                                         disablelevel = a.disablelevel,
                                                         relieffunds = a.relieffunds,
                                                         guardian = a.guardian,
                                                         explain = a.explain,
                                                         district = c.districtName
                                                     };
                        returnData.success = true;
                        returnData.message = "success";
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
                        IQueryable<List_Disable> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址                                   
                                        orderby e.name ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)     //字符串拼接成地址
                                        orderby e.IDCard ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)     //字符串拼接成地址
                                        orderby e.sex ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby e.addressID ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "disableNum":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)   //字符串拼接成地址
                                        orderby a.disableNum ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "disablelevel":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby a.disablelevel ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "relieffunds":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby a.relieffunds ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "guardian":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby a.guardian ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "explain":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby a.explain ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby c.districtName ascending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby e.name descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)     //字符串拼接成地址
                                        orderby e.IDCard descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "sex":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby e.sex descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby e.addressID descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "disableNum":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)     //字符串拼接成地址
                                        orderby a.disableNum descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "disablelevel":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby a.disablelevel descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "relieffunds":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)     //字符串拼接成地址
                                        orderby a.relieffunds descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "guardian":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)     //字符串拼接成地址
                                        orderby a.guardian descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                case "explain":
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)    //字符串拼接成地址
                                        orderby a.explain descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.POP_Disabled
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from e in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)   //字符串拼接成地址
                                        orderby c.districtName descending
                                        select new List_Disable
                                        {
                                            id = a.id,
                                            name = e.name,
                                            sex = e.sex,
                                            IDCard = e.IDCard,
                                            //      address =f.districtName,
                                            disableNum = a.disableNum,
                                            disablelevel = a.disablelevel,
                                            relieffunds = a.relieffunds,
                                            guardian = a.guardian,
                                            explain = a.explain,
                                            district = c.districtName
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
                        IQueryable<List_Disable> x = from a in ds.POP_Disabled
                                                     join b in ds.SYS_District on a.districtID equals b.id into b1
                                                     from c in b1.DefaultIfEmpty()
                                                     join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                     from e in d1.DefaultIfEmpty()
                                                     where districts.Contains(a.districtID)    //字符串拼接成地址
                                                     orderby c.districtName descending
                                                     select new List_Disable
                                                     {
                                                         id = a.id,
                                                         name = e.name,
                                                         sex = e.sex,
                                                         IDCard = e.IDCard,
                                                         //      address =f.districtName,
                                                         disableNum = a.disableNum,
                                                         disablelevel = a.disablelevel,
                                                         relieffunds = a.relieffunds,
                                                         guardian = a.guardian,
                                                         explain = a.explain,
                                                         district = c.districtName
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

        /*-----------------新增残疾人--------------*/
        public CommonOutput addDisabled(string name, string sex, string IDCard, string disableNum, string disablelevel, string relieffunds, string guardian, string explain)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(sex) || !string.IsNullOrEmpty(IDCard) || !string.IsNullOrEmpty(disableNum))
            {
                try
                {
                    var thisGuy = ds.POP_Basic.SingleOrDefault(d => (d.name == name) && (d.IDCard == IDCard));  //残疾人是不是都在基础人口表里面的？
                    var thisMan = ds.POP_Disabled.SingleOrDefault(d => d.populationID == thisGuy.id);
                    if (thisMan == null)
                    {
                        var x = new POP_Disabled();
                        x.id = Guid.NewGuid().ToString();
                        x.populationID = thisGuy.id;
                        x.districtID = thisGuy.districtID;
                        x.disableNum = disableNum;
                        x.disablelevel = disablelevel;
                        x.relieffunds = relieffunds;
                        x.guardian = guardian;
                        x.explain = explain;
                        ds.POP_Disabled.InsertOnSubmit(x);
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                    }

                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:残疾人库中已存在此信息，请勿重复添加！";
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
                returnData.message = "Error:信息不全，请填写基础信息！";
                return returnData;
            }
        }

        /*-----------------编辑残疾人--------------*/
        public CommonOutput editDisabled(string id, string name, string sex, string IDCard, string disableNum, string disablelevel, string relieffunds, string guardian, string explain)
        {
            CommonOutput returnData = new CommonOutput();
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(sex) || !string.IsNullOrEmpty(IDCard) || !string.IsNullOrEmpty(id))
            {
                try
                {
                    POP_Disabled x = ds.POP_Disabled.SingleOrDefault(d => d.id == id);
                    if (x == null)
                    {
                        returnData.success = false;
                        returnData.message = "不存在该人信息";
                    }
                    var thisGuy = ds.POP_Basic.SingleOrDefault(d => (d.name == name) && (d.IDCard == IDCard));  //残疾人是不是都在基础人口表里面的？
                    var thisMan = ds.POP_Disabled.SingleOrDefault(d => d.populationID == thisGuy.id);
                    if (thisMan == null)
                    {
                        x.populationID = thisGuy.id;
                        x.districtID = thisGuy.districtID;
                        x.disableNum = disableNum;
                        x.disablelevel = disablelevel;
                        x.relieffunds = relieffunds;
                        x.guardian = guardian;
                        x.explain = explain;
                        ds.SubmitChanges();
                        returnData.success = true;
                        returnData.message = "success";
                        return returnData;
                    }

                    else
                    {
                        returnData.success = false;
                        returnData.message = "Error:残疾人库中已存在此信息，请勿重复添加！";
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
        /*-------------删除残疾人信息---------*/
        public CommonOutput deleteDisabled(string id)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    var x = ds.POP_Disabled.SingleOrDefault(d => d.id == id);
                    if (x != null)
                    {
                        ds.POP_Disabled.DeleteOnSubmit(x);
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

        /*-------------批量删除残疾人信息-----*/
        public CommonOutput deleteMultiDisabled(string idStr)
        {
            CommonOutput returnData = new CommonOutput();
            if (!String.IsNullOrEmpty(idStr))
            {
                try
                {
                    string[] ids = idStr.Split(',');
                    foreach (var id in ids)
                    {
                        var x = ds.POP_Disabled.SingleOrDefault(d => d.id == id);
                        if (x != null)
                        {
                            ds.POP_Disabled.DeleteOnSubmit(x);
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
    }
}
