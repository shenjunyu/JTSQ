using MLDSData;
using MLDSService.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ISystem”。
    [ServiceContract]
    public interface IAgriculture
    {
        #region 农产品
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAgricultureProduct?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Product[]> getAgricultureProduct(string districtID, int offset, int limit, string order, string search, string sort);
        #endregion

        #region 农场
        /*-----------列表查看-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAgricultureFarm?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Farm[]> getAgricultureFarm(string districtID, int offset, int limit, string order, string search, string sort);
        #endregion

        #region 农技人员
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAgricultureExpert?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<AGR_Expert[]> getAgricultureExpert(string districtID, int offset, int limit, string order, string search, string sort);

        #endregion

        #region 农田

        /*-----------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAgricultureFarmLand?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_FarmLand[]> getAgricultureFarmLand(string districtID, int offset, int limit, string order, string search, string sort);

        #endregion
    }
}
