using MLDSData;
using MLDSService.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ISystem”。
    [ServiceContract]
    public interface ISystem
    {
        #region 系统模块
        /*--------------------登录------------------*/
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "accountLogin", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        LoginAccess accountLogin(string userName, string password, string district);

        /*--------------------验证登录信息------------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "accountCheck?userID={userID}&authorityID={authorityID}&districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<System_UserInformation> accountCheck(string userID, string authorityID, string districtID);

        #endregion

        #region 用户管理
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getUser?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_User[]> getUser(string districtID, int offset, int limit, string order, string search, string sort);
        #endregion

        #region 角色管理
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "queryRole?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Role[]> queryRole(string districtID, int offset, int limit, string order, string search, string sort);
        #endregion

        #region 登陆日志
        /*--------------------列表查看------------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getLoginNote?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<SYS_LoginNote[]> getLoginNote(string districtID, int offset, int limit, string order, string search, string sort);
        #endregion


        #region 首页功能
        /*---------------镇级首页政通知-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getIndex_Z?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT_M<List_Index_InternalInformation[], List_Index_Meeting[]> getIndex_Z(string districtID);

        /*---------------村级首页政通知-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getIndex?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT_M<List_Index_InternalInformation[], List_Index_Meeting[]> getIndex(string districtID);
       
        /*---------------镇级首页详情-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInternalInformationDetail?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<string> getInternalInformationDetail(string id);

        /*---------------镇级首页详情-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getMeetingDetail?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<string> getMeetingDetail(string id);
        #endregion
    }
}
