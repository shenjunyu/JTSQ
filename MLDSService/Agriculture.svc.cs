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
    public class Agriculture : IAgriculture
    {
        private static MLDSDataContext ds = new MLDSDataContext();

        #region 农产品
        /*-----------列表查看-----------*/
        public PageRows<List_Product[]> getAgricultureProduct(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Product[]> returnData = new PageRows<List_Product[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Product> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "type":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.type.Contains(search) || a.name.Contains(search))
                                        orderby a.type ascending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                case "name":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.type.Contains(search) || a.name.Contains(search))
                                        orderby a.name ascending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.type.Contains(search) || a.name.Contains(search))
                                        orderby c.districtName ascending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.type.Contains(search) || a.name.Contains(search))
                                        orderby a.type ascending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "type":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.type.Contains(search) || a.name.Contains(search))
                                        orderby a.type descending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                case "name":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.type.Contains(search) || a.name.Contains(search))
                                        orderby a.name descending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.type.Contains(search) || a.name.Contains(search))
                                        orderby c.districtName descending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.type.Contains(search) || a.name.Contains(search))
                                        orderby a.type descending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
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
                else
                {
                    try
                    {
                        IQueryable<List_Product> x = from a in ds.AGR_Product
                                                     join b in ds.SYS_District on a.districtID equals b.id into b1
                                                     from c in b1.DefaultIfEmpty()
                                                     where districts.Contains(a.districtID) && (a.type.Contains(search) || a.name.Contains(search))
                                                     orderby a.type descending
                                                     select new List_Product
                                                     {
                                                         id = a.id,
                                                         type = a.type,
                                                         name = a.name,
                                                         imageURL = a.imageURL,
                                                         pin = a.pin,
                                                         description = a.description,
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
            else
            {
                if (!string.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Product> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "type":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.type ascending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                case "name":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.name ascending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby c.districtName ascending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.type ascending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "type":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.type descending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                case "name":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.name descending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                case "district":
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby c.districtName descending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
                                            district = c.districtName
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_Product
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.type descending
                                        select new List_Product
                                        {
                                            id = a.id,
                                            type = a.type,
                                            name = a.name,
                                            imageURL = a.imageURL,
                                            pin = a.pin,
                                            description = a.description,
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
                        IQueryable<List_Product> x = from a in ds.AGR_Product
                                                     join b in ds.SYS_District on a.districtID equals b.id into b1
                                                     from c in b1.DefaultIfEmpty()
                                                     where districts.Contains(a.districtID)
                                                     orderby a.type descending
                                                     select new List_Product
                                                     {
                                                         id = a.id,
                                                         type = a.type,
                                                         name = a.name,
                                                         imageURL = a.imageURL,
                                                         pin = a.pin,
                                                         description = a.description,
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

        #endregion

        #region 农场
        /*-----------列表查看-----------*/
        public PageRows<List_Farm[]> getAgricultureFarm(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_Farm[]> returnData = new PageRows<List_Farm[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_Farm> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_Farm
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.contractorID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search))
                                        orderby a.name ascending
                                        select new List_Farm
                                        {
                                            id = a.id,
                                            contractor = d2.name,
                                            name = a.name,
                                            district = c.districtName,
                                            products = (from e in ds.AGR_Farm_Product
                                                        join f in ds.AGR_Product on e.productID equals f.id into f1
                                                        from f2 in f1.DefaultIfEmpty()
                                                        join g in ds.AGR_Expert on e.expertID equals g.id into g1
                                                        from g2 in g1.DefaultIfEmpty()
                                                        where e.farmID == a.id
                                                        select new List_Farm_Product
                                                        {
                                                            id = e.id,
                                                            area = (double)e.area,
                                                            type = f2.type,
                                                            name = f2.name,
                                                            expert = g2.name,
                                                            description = f2.description,
                                                            imageURL = f2.imageURL,
                                                            location = e.location,
                                                            pin = f2.pin,
                                                            values = (from h in ds.AGR_Farm_Product_Value
                                                                      where h.farmProductID == e.id
                                                                      select new List_Farm_Product_Value
                                                                      {
                                                                          id = h.id,
                                                                          production = h.production,
                                                                          value = h.value,
                                                                          year = h.year
                                                                      }).ToArray()
                                                        }).ToArray()
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_Farm
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.contractorID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search))
                                        orderby a.name ascending
                                        select new List_Farm
                                        {
                                            id = a.id,
                                            contractor = d2.name,
                                            name = a.name,
                                            district = c.districtName,
                                            products = (from e in ds.AGR_Farm_Product
                                                        join f in ds.AGR_Product on e.productID equals f.id into f1
                                                        from f2 in f1.DefaultIfEmpty()
                                                        join g in ds.AGR_Expert on e.expertID equals g.id into g1
                                                        from g2 in g1.DefaultIfEmpty()
                                                        where e.farmID == a.id
                                                        select new List_Farm_Product
                                                        {
                                                            id = e.id,
                                                            area = (double)e.area,
                                                            type = f2.type,
                                                            name = f2.name,
                                                            expert = g2.name,
                                                            description = f2.description,
                                                            imageURL = f2.imageURL,
                                                            location = e.location,
                                                            pin = f2.pin,
                                                            values = (from h in ds.AGR_Farm_Product_Value
                                                                      where h.farmProductID == e.id
                                                                      select new List_Farm_Product_Value
                                                                      {
                                                                          id = h.id,
                                                                          production = h.production,
                                                                          value = h.value,
                                                                          year = h.year
                                                                      }).ToArray()
                                                        }).ToArray()
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_Farm
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.contractorID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search))
                                        orderby a.name descending
                                        select new List_Farm
                                        {
                                            id = a.id,
                                            contractor = d2.name,
                                            name = a.name,
                                            district = c.districtName,
                                            products = (from e in ds.AGR_Farm_Product
                                                        join f in ds.AGR_Product on e.productID equals f.id into f1
                                                        from f2 in f1.DefaultIfEmpty()
                                                        join g in ds.AGR_Expert on e.expertID equals g.id into g1
                                                        from g2 in g1.DefaultIfEmpty()
                                                        where e.farmID == a.id
                                                        select new List_Farm_Product
                                                        {
                                                            id = e.id,
                                                            area = (double)e.area,
                                                            type = f2.type,
                                                            name = f2.name,
                                                            expert = g2.name,
                                                            description = f2.description,
                                                            imageURL = f2.imageURL,
                                                            location = e.location,
                                                            pin = f2.pin,
                                                            values = (from h in ds.AGR_Farm_Product_Value
                                                                      where h.farmProductID == e.id
                                                                      select new List_Farm_Product_Value
                                                                      {
                                                                          id = h.id,
                                                                          production = h.production,
                                                                          value = h.value,
                                                                          year = h.year
                                                                      }).ToArray()
                                                        }).ToArray()
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_Farm
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.contractorID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID) && (a.name.Contains(search))
                                        orderby a.name descending
                                        select new List_Farm
                                        {
                                            id = a.id,
                                            contractor = d2.name,
                                            name = a.name,
                                            district = c.districtName,
                                            products = (from e in ds.AGR_Farm_Product
                                                        join f in ds.AGR_Product on e.productID equals f.id into f1
                                                        from f2 in f1.DefaultIfEmpty()
                                                        join g in ds.AGR_Expert on e.expertID equals g.id into g1
                                                        from g2 in g1.DefaultIfEmpty()
                                                        where e.farmID == a.id
                                                        select new List_Farm_Product
                                                        {
                                                            id = e.id,
                                                            area = (double)e.area,
                                                            type = f2.type,
                                                            name = f2.name,
                                                            expert = g2.name,
                                                            description = f2.description,
                                                            imageURL = f2.imageURL,
                                                            location = e.location,
                                                            pin = f2.pin,
                                                            values = (from h in ds.AGR_Farm_Product_Value
                                                                      where h.farmProductID == e.id
                                                                      select new List_Farm_Product_Value
                                                                      {
                                                                          id = h.id,
                                                                          production = h.production,
                                                                          value = h.value,
                                                                          year = h.year
                                                                      }).ToArray()
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
                        IQueryable<List_Farm> x = from a in ds.AGR_Farm
                                                  join b in ds.SYS_District on a.districtID equals b.id into b1
                                                  from c in b1.DefaultIfEmpty()
                                                  join d in ds.POP_Basic on a.contractorID equals d.id into d1
                                                  from d2 in d1.DefaultIfEmpty()
                                                  where districts.Contains(a.districtID) && (a.name.Contains(search))
                                                  orderby a.name descending
                                                  select new List_Farm
                                                  {
                                                      id = a.id,
                                                      contractor = d2.name,
                                                      name = a.name,
                                                      district = c.districtName,
                                                      products = (from e in ds.AGR_Farm_Product
                                                                  join f in ds.AGR_Product on e.productID equals f.id into f1
                                                                  from f2 in f1.DefaultIfEmpty()
                                                                  join g in ds.AGR_Expert on e.expertID equals g.id into g1
                                                                  from g2 in g1.DefaultIfEmpty()
                                                                  where e.farmID == a.id
                                                                  select new List_Farm_Product
                                                                  {
                                                                      id = e.id,
                                                                      area = (double)e.area,
                                                                      type = f2.type,
                                                                      name = f2.name,
                                                                      expert = g2.name,
                                                                      description = f2.description,
                                                                      imageURL = f2.imageURL,
                                                                      location = e.location,
                                                                      pin = f2.pin,
                                                                      values = (from h in ds.AGR_Farm_Product_Value
                                                                                where h.farmProductID == e.id
                                                                                select new List_Farm_Product_Value
                                                                                {
                                                                                    id = h.id,
                                                                                    production = h.production,
                                                                                    value = h.value,
                                                                                    year = h.year
                                                                                }).ToArray()
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
                        IQueryable<List_Farm> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_Farm
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.contractorID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.name ascending
                                        select new List_Farm
                                        {
                                            id = a.id,
                                            contractor = d2.name,
                                            name = a.name,
                                            district = c.districtName,
                                            products = (from e in ds.AGR_Farm_Product
                                                        join f in ds.AGR_Product on e.productID equals f.id into f1
                                                        from f2 in f1.DefaultIfEmpty()
                                                        join g in ds.AGR_Expert on e.expertID equals g.id into g1
                                                        from g2 in g1.DefaultIfEmpty()
                                                        where e.farmID == a.id
                                                        select new List_Farm_Product
                                                        {
                                                            id = e.id,
                                                            area = (double)e.area,
                                                            type = f2.type,
                                                            name = f2.name,
                                                            expert = g2.name,
                                                            description = f2.description,
                                                            imageURL = f2.imageURL,
                                                            location = e.location,
                                                            pin = f2.pin,
                                                            values = (from h in ds.AGR_Farm_Product_Value
                                                                      where h.farmProductID == e.id
                                                                      select new List_Farm_Product_Value
                                                                      {
                                                                          id = h.id,
                                                                          production = h.production,
                                                                          value = h.value,
                                                                          year = h.year
                                                                      }).ToArray()
                                                        }).ToArray()
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_Farm
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.contractorID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.name ascending
                                        select new List_Farm
                                        {
                                            id = a.id,
                                            contractor = d2.name,
                                            name = a.name,
                                            district = c.districtName,
                                            products = (from e in ds.AGR_Farm_Product
                                                        join f in ds.AGR_Product on e.productID equals f.id into f1
                                                        from f2 in f1.DefaultIfEmpty()
                                                        join g in ds.AGR_Expert on e.expertID equals g.id into g1
                                                        from g2 in g1.DefaultIfEmpty()
                                                        where e.farmID == a.id
                                                        select new List_Farm_Product
                                                        {
                                                            id = e.id,
                                                            area = (double)e.area,
                                                            type = f2.type,
                                                            name = f2.name,
                                                            expert = g2.name,
                                                            description = f2.description,
                                                            imageURL = f2.imageURL,
                                                            location = e.location,
                                                            pin = f2.pin,
                                                            values = (from h in ds.AGR_Farm_Product_Value
                                                                      where h.farmProductID == e.id
                                                                      select new List_Farm_Product_Value
                                                                      {
                                                                          id = h.id,
                                                                          production = h.production,
                                                                          value = h.value,
                                                                          year = h.year
                                                                      }).ToArray()
                                                        }).ToArray()
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_Farm
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.contractorID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.name descending
                                        select new List_Farm
                                        {
                                            id = a.id,
                                            contractor = d2.name,
                                            name = a.name,
                                            district = c.districtName,
                                            products = (from e in ds.AGR_Farm_Product
                                                        join f in ds.AGR_Product on e.productID equals f.id into f1
                                                        from f2 in f1.DefaultIfEmpty()
                                                        join g in ds.AGR_Expert on e.expertID equals g.id into g1
                                                        from g2 in g1.DefaultIfEmpty()
                                                        where e.farmID == a.id
                                                        select new List_Farm_Product
                                                        {
                                                            id = e.id,
                                                            area = (double)e.area,
                                                            type = f2.type,
                                                            name = f2.name,
                                                            expert = g2.name,
                                                            description = f2.description,
                                                            imageURL = f2.imageURL,
                                                            location = e.location,
                                                            pin = f2.pin,
                                                            values = (from h in ds.AGR_Farm_Product_Value
                                                                      where h.farmProductID == e.id
                                                                      select new List_Farm_Product_Value
                                                                      {
                                                                          id = h.id,
                                                                          production = h.production,
                                                                          value = h.value,
                                                                          year = h.year
                                                                      }).ToArray()
                                                        }).ToArray()
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_Farm
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.contractorID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.name descending
                                        select new List_Farm
                                        {
                                            id = a.id,
                                            contractor = d2.name,
                                            name = a.name,
                                            district = c.districtName,
                                            products = (from e in ds.AGR_Farm_Product
                                                        join f in ds.AGR_Product on e.productID equals f.id into f1
                                                        from f2 in f1.DefaultIfEmpty()
                                                        join g in ds.AGR_Expert on e.expertID equals g.id into g1
                                                        from g2 in g1.DefaultIfEmpty()
                                                        where e.farmID == a.id
                                                        select new List_Farm_Product
                                                        {
                                                            id = e.id,
                                                            area = (double)e.area,
                                                            type = f2.type,
                                                            name = f2.name,
                                                            expert = g2.name,
                                                            description = f2.description,
                                                            imageURL = f2.imageURL,
                                                            location = e.location,
                                                            pin = f2.pin,
                                                            values = (from h in ds.AGR_Farm_Product_Value
                                                                      where h.farmProductID == e.id
                                                                      select new List_Farm_Product_Value
                                                                      {
                                                                          id = h.id,
                                                                          production = h.production,
                                                                          value = h.value,
                                                                          year = h.year
                                                                      }).ToArray()
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
                        IQueryable<List_Farm> x = from a in ds.AGR_Farm
                                                  join b in ds.SYS_District on a.districtID equals b.id into b1
                                                  from c in b1.DefaultIfEmpty()
                                                  join d in ds.POP_Basic on a.contractorID equals d.id into d1
                                                  from d2 in d1.DefaultIfEmpty()
                                                  where districts.Contains(a.districtID)
                                                  orderby a.name descending
                                                  select new List_Farm
                                                  {
                                                      id = a.id,
                                                      contractor = d2.name,
                                                      name = a.name,
                                                      district = c.districtName,
                                                      products = (from e in ds.AGR_Farm_Product
                                                                  join f in ds.AGR_Product on e.productID equals f.id into f1
                                                                  from f2 in f1.DefaultIfEmpty()
                                                                  join g in ds.AGR_Expert on e.expertID equals g.id into g1
                                                                  from g2 in g1.DefaultIfEmpty()
                                                                  where e.farmID == a.id
                                                                  select new List_Farm_Product
                                                                  {
                                                                      id = e.id,
                                                                      area = (double)e.area,
                                                                      type = f2.type,
                                                                      name = f2.name,
                                                                      expert = g2.name,
                                                                      description = f2.description,
                                                                      imageURL = f2.imageURL,
                                                                      location = e.location,
                                                                      pin = f2.pin,
                                                                      values = (from h in ds.AGR_Farm_Product_Value
                                                                                where h.farmProductID == e.id
                                                                                select new List_Farm_Product_Value
                                                                                {
                                                                                    id = h.id,
                                                                                    production = h.production,
                                                                                    value = h.value,
                                                                                    year = h.year
                                                                                }).ToArray()
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


        #endregion

        #region 农技人员
        /*-----------列表查看-----------*/
        public PageRows<AGR_Expert[]> getAgricultureExpert(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<AGR_Expert[]> returnData = new PageRows<AGR_Expert[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<AGR_Expert> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_Expert
                                        where a.name.Contains(search) || a.IDCard.Contains(search)
                                        orderby a.name ascending
                                        select a;
                                    break;
                                case "IDCard":
                                    x = from a in ds.AGR_Expert
                                        where a.name.Contains(search) || a.IDCard.Contains(search)
                                        orderby a.IDCard ascending
                                        select a;
                                    break;
                                default:
                                    x = from a in ds.AGR_Expert
                                        where a.name.Contains(search) || a.IDCard.Contains(search)
                                        orderby a.name ascending
                                        select a;
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_Expert
                                        where a.name.Contains(search) ||a.IDCard.Contains(search)
                                        orderby a.name descending
                                        select a;
                                    break;
                                case "IDCard":
                                    x = from a in ds.AGR_Expert
                                        where a.name.Contains(search) ||a.IDCard.Contains(search)
                                        orderby a.IDCard descending
                                        select a;
                                    break;
                                default:
                                    x = from a in ds.AGR_Expert
                                        where a.name.Contains(search) || a.IDCard.Contains(search)
                                        orderby a.name descending
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
                        returnData.message = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else
                {
                    try
                    {
                        IQueryable<AGR_Expert> x = from a in ds.AGR_Expert
                                                   where a.name.Contains(search) || a.IDCard.Contains(search)
                                                   orderby a.name descending
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
                        IQueryable<AGR_Expert> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_Expert
                                        orderby a.name ascending
                                        select a;
                                    break;
                                case "IDCard":
                                    x = from a in ds.AGR_Expert
                                        orderby a.IDCard ascending
                                        select a;
                                    break;
                                default:
                                    x = from a in ds.AGR_Expert
                                        orderby a.name ascending
                                        select a;
                                    break;

                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_Expert
                                        orderby a.name descending
                                        select a;
                                    break;
                                case "IDCard":
                                    x = from a in ds.AGR_Expert
                                        orderby a.IDCard descending
                                        select a;
                                    break;
                                default:
                                    x = from a in ds.AGR_Expert
                                        orderby a.name descending
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
                        returnData.message = "Error:" + ex.Message;
                        return returnData;
                    }
                }
                else//二者都为空，即启动状态
                {
                    try
                    {
                        IQueryable<AGR_Expert> x = x = from a in ds.AGR_Expert
                                                       orderby a.name descending
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
                        returnData.message = "Error:" + ex.Message;
                        return returnData;
                    }
                }
            }
        }

        #endregion

        #region 农田
        /*-----------列表查看-----------*/
        public PageRows<List_FarmLand[]> getAgricultureFarmLand(string districtID, int offset, int limit, string order, string search, string sort)
        {
            var districts = CommonMethod.getSubDistrict(districtID);
            PageRows<List_FarmLand[]> returnData = new PageRows<List_FarmLand[]>();
            //搜索是否为空
            if (!String.IsNullOrEmpty(search))
            {
                //排序字段是否为空
                if (!String.IsNullOrEmpty(sort))
                {
                    try
                    {
                        IQueryable<List_FarmLand> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        &&(d2.name.Contains(search)||d2.IDCard.Contains(search)||d2.phone.Contains(search)||a.farmLandID.Contains(search)||a.address.Contains(search))
                                        orderby d2.name ascending
                                        select new List_FarmLand
                                        {
                                            id=a.id,
                                            address=a.address,
                                            district=c.districtName,
                                            farmLandID=a.farmLandID,
                                            IDCard=d2.IDCard,
                                            name=d2.name,
                                            phone=d2.phone
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby d2.IDCard ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby d2.phone ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "farmLandID":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby a.farmLandID ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby a.address ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby a.farmLandID ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby d2.name descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby d2.IDCard descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby d2.phone descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "farmLandID":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby a.farmLandID descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby a.address descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                        orderby a.farmLandID descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
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
                        IQueryable<List_FarmLand> x = from a in ds.AGR_FarmLand
                                                      join b in ds.SYS_District on a.districtID equals b.id into b1
                                                      from c in b1.DefaultIfEmpty()
                                                      join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                      from d2 in d1.DefaultIfEmpty()
                                                      where districts.Contains(a.districtID)
                                                      && (d2.name.Contains(search) || d2.IDCard.Contains(search) || d2.phone.Contains(search) || a.farmLandID.Contains(search) || a.address.Contains(search))
                                                      orderby a.farmLandID descending
                                                      select new List_FarmLand
                                                      {
                                                          id = a.id,
                                                          address = a.address,
                                                          district = c.districtName,
                                                          farmLandID = a.farmLandID,
                                                          IDCard = d2.IDCard,
                                                          name = d2.name,
                                                          phone = d2.phone
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
                        IQueryable<List_FarmLand> x = null;
                        if (order == "asc" || order == "")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby d2.name ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby d2.IDCard ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby d2.phone ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "farmLandID":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.farmLandID ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.address ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.farmLandID ascending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                            }
                        }
                        else if (order == "desc")
                        {
                            switch (sort)
                            {
                                case "name":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby d2.name descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "IDCard":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby d2.IDCard descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "phone":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby d2.phone descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "farmLandID":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.farmLandID descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                case "address":
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.address descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
                                        };
                                    break;
                                default:
                                    x = from a in ds.AGR_FarmLand
                                        join b in ds.SYS_District on a.districtID equals b.id into b1
                                        from c in b1.DefaultIfEmpty()
                                        join d in ds.POP_Basic on a.populationID equals d.id into d1
                                        from d2 in d1.DefaultIfEmpty()
                                        where districts.Contains(a.districtID)
                                        orderby a.farmLandID descending
                                        select new List_FarmLand
                                        {
                                            id = a.id,
                                            address = a.address,
                                            district = c.districtName,
                                            farmLandID = a.farmLandID,
                                            IDCard = d2.IDCard,
                                            name = d2.name,
                                            phone = d2.phone
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
                        IQueryable<List_FarmLand> x = from a in ds.AGR_FarmLand
                                                      join b in ds.SYS_District on a.districtID equals b.id into b1
                                                      from c in b1.DefaultIfEmpty()
                                                      join d in ds.POP_Basic on a.populationID equals d.id into d1
                                                      from d2 in d1.DefaultIfEmpty()
                                                      where districts.Contains(a.districtID)
                                                      orderby a.farmLandID descending
                                                      select new List_FarmLand
                                                      {
                                                          id = a.id,
                                                          address = a.address,
                                                          district = c.districtName,
                                                          farmLandID = a.farmLandID,
                                                          IDCard = d2.IDCard,
                                                          name = d2.name,
                                                          phone = d2.phone
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
    }
}
