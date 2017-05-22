using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MLDSData;
using MLDSService.DataContracts;
using MLDSService.DataContracts.Analysis;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDynamic”。
    [ServiceContract]
    public interface IBusiness
    {

        #region 业务管理
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getBusinessList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Business[]> getBusinessList(string districtID, int offset, int limit, string order, string search, string sort);
        /*
         * 
         * 
         * 
         * 有问题啊
         * 
         * 
         * 
         * 
        /*-------------新增业务------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "addBusiness?IDCard={IDCard}&serviceName={serviceName}"+
            "&remark={remark}&userID={userID}&districtID={districtID}&createTime={createTime}"+
            "&status={status}&processTime={processTime}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addBusiness(string IDCard, string serviceName, string remark, string userID,
            string districtID, string createTime, string status, string processTime);

        /*------------获取业务信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getbusinessName", ResponseFormat = WebMessageFormat.Json)]
        PageRows<BUS_BusinessType[]> getbusinessName();

        /*------------根据业务获取服务信息--------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getserviceNameBybusinessID?id={id}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<BUS_ServiceType[]> getserviceNameBybusinessID(string id);
        /*
         * 
         * 
         * 
         * 有问题啊
         * 
         * 
         * 
         */
        #endregion

        #region 违章建筑
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getIllegalBuildingList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_IllegalBuilding[]> getIllegalBuildingList(string districtID, int offset, int limit, string order, string search, string sort);

        #endregion

        #region 少儿医保
        /*-------------列表查看吕------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getChildrenInsuranceList?year={year}&districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_ChildrenInsurance[]> getChildrenInsuranceList(string year, string districtID, int offset, int limit, string order, string search, string sort);

        /*-------------列表查看郭------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getsubChildrenInsuranceList?year={year}&districtID={districtID}&subdistrictID={subdistrictID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_ChildrenInsurance[]> getsubChildrenInsuranceList(string year, string districtID, string subdistrictID, int offset, int limit, string order, string search, string sort);
        /*-------------新增少儿医保郭---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "addChildrenInsuranceList?year={year}&districtID={districtID}&institutionID={institutionID}&peopleID={peopleID}&name={name}&IDCard={IDCard}&sex={sex}&accountProperty={accountProperty}&studentNum={studentNum}&exemptionType={exemptionType}&exemptionID={exemptionID}&contract={contract}&phone={phone}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addChildrenInsuranceList(string year, string districtID, string institutionID, string peopleID, string name, string IDCard, string sex, string accountProperty, string studentNum, string exemptionType, string exemptionID, string contract, string phone);
        /*-------------编辑少儿医保郭---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "editChildrenInsuranceList?id={id}&year={year}&districtID={districtID}&institutionID={institutionID}&peopleID={peopleID}&name={name}&IDCard={IDCard}&sex={sex}&accountProperty={accountProperty}&studentNum={studentNum}&exemptionType={exemptionType}&exemptionID={exemptionID}&contract={contract}&phone={phone}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput editChildrenInsuranceList(string id, string year, string districtID, string institutionID, string peopleID, string name, string IDCard, string sex, string accountProperty, string studentNum, string exemptionType, string exemptionID, string contract, string phone);
        /*-------------删除少儿医保郭---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteChildrenInsuranceList?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteChildrenInsuranceList(string id);
        /*-------------批量删除少儿医保郭-----*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteMultiChildrenInsuranceList?idStr={idStr}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteMultiChildrenInsuranceList(string idStr);
        #endregion

        #region 农村医疗
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getRuralInsuranceList?year={year}&districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_RuralInsurance[]> getRuralInsuranceList(string year, string districtID, int offset, int limit, string order, string search, string sort);

        /*-------------列表查看------------*/
        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "getRuralInsuranceList?year={year}&districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        //PageRows<List_RuralInsurance[]> getRuralInsuranceList(string year, string districtID, int offset, int limit, string order, string search, string sort);
        /*-------------新增农村医疗---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "addRuralInsuranceList?year={year}&districtID={districtID}&peopleID={peopleID}&name={name}&IDCard={IDCard}&sex={sex}&exemptionType={exemptionType}&exemptionID={exemptionID}&phone={phone}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addRuralInsuranceList(string year, string districtID, string peopleID, string name, string IDCard, string sex, string phone, string exemptionType, string exemptionID);
        /*-------------编辑农村医疗---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "editRuralInsuranceList?id={id}&year={year}&districtID={districtID}&peopleID={peopleID}&name={name}&IDCard={IDCard}&sex={sex}&exemptionType={exemptionType}&exemptionID={exemptionID}&phone={phone}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput editRuralInsuranceList(string id, string year, string districtID, string peopleID, string name, string IDCard, string sex, string phone, string exemptionType, string exemptionID);
        /*-------------删除农村医疗---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteRuralInsuranceList?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteRuralInsuranceList(string id);
        /*-------------批量删除农村医疗-----*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteMultiRuralInsuranceList?idStr={idStr}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteMultiRuralInsuranceList(string idStr);
        #endregion

        #region 政务通知
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInformation?district={district}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<CommonInformation[]> getInformation(string district, int offset, int limit, string order, string search, string sort);

        /*--------------新增信息-----------------*/
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "addInformation", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addInformation(string title, string type, string peek, string imageURL, string htmlContent, string userID, string districtID);

        /*--------------编辑信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "editInformation", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        CommonOutput editInformation(string id, string title, string type, string peek, string imageURL, string htmlContent, string userID, string districtID);

        /*--------------获取单条信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getSingleInformation?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<BUS_InternalInformation> getSingleInformation(string id);
        /*--------------删除信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteInformation?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteInformation(string id);
        /*--------------批量删除信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteMultiInformation?idStr={idStr}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteMultiInformation(string idStr);
        #endregion

        #region 会议管理
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getMeeting?district={district}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<CommonInformation[]> getMeeting(string district, int offset, int limit, string order, string search, string sort);

        /*--------------新增信息-----------------*/
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "addMeeting", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addMeeting(string title, string type, string peek, string imageURL, string htmlContent, string userID, string districtID);

        /*--------------编辑信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "editMeeting", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        CommonOutput editMeeting(string id, string title, string type, string peek, string imageURL, string htmlContent, string userID, string districtID);

        /*--------------获取单条信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getSingleMeeting?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<BUS_Meeting> getSingleMeeting(string id);
        /*--------------删除信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteMeeting?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteMeeting(string id);
        /*--------------批量删除信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteMultiMeeting?idStr={idStr}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteMultiMeeting(string idStr);
        #endregion

        #region 股份分红

        #endregion

        #region 统计管理

        #region 少儿医保
        /*---------本年内少儿医保统计---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getChildrenInsurance_10?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<BUS_ChildrenInsurance_10> getChildrenInsurance_10(string districtID);
        #endregion

        #region 农村医疗
        /*---------本年内农村医疗统计---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getRuralInsurance_10?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<BUS_RuralInsurance_10> getRuralInsurance_10(string districtID);
        #endregion

        #region 政务通知
        /*---------十天内农村医疗统计---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInformation_10?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<BUS_Information_10> getInformation_10(string districtID);
        #endregion

        #region 会议公告
        /*---------十天内农村医疗统计---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getMeeting_10?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<BUS_Meeting_10> getMeeting_10(string districtID);
        #endregion

        #endregion

    }
}
