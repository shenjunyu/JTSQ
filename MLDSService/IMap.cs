using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MLDSData;
using MLDSService.DataContracts;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDynamic”。
    [ServiceContract]
    public interface IMap
    {
        #region 通用方法
        /*-----------------获取区域中心----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getDistrictCenter?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonMapPoint getDistrictCenter(string districtID);

        /*-----------------获取标注----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getplane?type={type}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_Marker[]> getplane(string type);

        /*-----------------获取区域范围----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getDistrict?districtID={districtID}&zoom={zoom}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_District[]> getDistrict(string districtID, int zoom);
        #endregion

        #region 人口地图
        /*-----------------获取大块人口数据----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getMapPopulationBlock?districtID={districtID}&centerX={centerX}&centerY={centerY}&zoomLevel={zoomLevel}&explorX={explorX}&explorY={explorY}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_ZoomNum[]> getMapPopulationBlock(string districtID, double centerX, double centerY, int zoomLevel, int explorX, int explorY);

        /*-----------------获取大块人口数据----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getMapFamily?districtID={districtID}&centerX={centerX}&centerY={centerY}&zoomLevel={zoomLevel}&explorX={explorX}&explorY={explorY}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_Family[]> getMapFamily(string districtID, double centerX, double centerY, int zoomLevel, int explorX, int explorY);

        /*-----------党员分布查看---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getPartyMember?type={type}&districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_PopulationSearchByParty[]> getPartyMember(int type, string districtID);

        /*-----------老年人分布查看---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getElderly?type={type}&districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_PopulationSearchBygetElderly[]> getElderly(int type, string districtID);


        /*-----------------搜索党员----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "mapSearchPartyPopulation?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_PopulationSearchByParty[]> mapSearchPartyPopulation(string districtID);

        /*-----------------搜索工作人员----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "mapSearchLeaderPopulation?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_PopulationSearchByLeader[]> mapSearchLeaderPopulation(string districtID);


        /*-----------残疾人分布查看---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getMapDisabled?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_PopulationSearchBygetDisabled[]> getMapDisabled(string districtID);

        /*-----------和谐家庭分布查看---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getMapHarmoniousFamily?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_Family[]> getMapHarmoniousFamily(string districtID);
        #endregion

        #region 农业地图
        /*-----------作物分布查看---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getProductArea?type={type}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_Product_Area[]> getProductArea(int type);

        /*-----------获取农场---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "mapGetFarm?districtID={districtID}&type={type}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_Farm[]> mapGetFarm(string districtID, string type);

        /*-----------农技人员---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "mapGetExpert?districtID={districtID}&type={type}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_Expert[]> mapGetExpert(string districtID, string type);

        /*-----------农田---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "mapGetFarmLand?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_FarmLand[]> mapGetFarmLand(string districtID);

        /*-----------农田---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "mapFindFarmLand?farmLandID={farmLandID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_FarmLand> mapFindFarmLand(string farmLandID);
        #endregion

        #region 搜索
        /*-----------------搜索人口----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "mapSearchPopulation?districtID={districtID}&offset={offset}&search={search}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Map_PopulationSearch[]> mapSearchPopulation(string districtID, int offset, string search);

        #endregion


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "fitBuilding", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput fitBuilding();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "fitAddress", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput fitAddress();
    }
}
