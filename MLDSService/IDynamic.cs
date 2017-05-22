using System.ServiceModel;
using System.ServiceModel.Web;
using MLDSData;
using MLDSService.DataContracts;
using MLDSService.DataContracts.Analysis;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDynamic”。
    [ServiceContract]
    public interface IDynamic
    {

        #region WEB
        #region 信息公告
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
        CommonOutputT<DYNC_Information> getSingleInformation(string id);
        /*--------------删除信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteInformation?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteInformation(string id);
        /*--------------批量删除信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteMultiInformation?idStr={idStr}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteMultiInformation(string idStr);
        #endregion

        #region 业务预约
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAppointmentList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Appointment[]> getAppointmentList(string districtID, int offset, int limit, string order, string search, string sort);

        /*-------------获取预约详情------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAppointmentDetail?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Appointment_Detail_Answer[]> getAppointmentDetail(string id);

        /*--------------处理预约----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "processAppointment?id={id}&userID={userID}&answerContent={answerContent}&type={type}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput processAppointment(string id, string userID, string answerContent, int type);
        #endregion

        #region 随手拍
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getPhotoTakeList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_PhotoTake[]> getPhotoTakeList(string districtID, int offset, int limit, string order, string search, string sort);

        /*-------------获取随手拍详情------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getPhotoTakeDetail?id={id}", ResponseFormat = WebMessageFormat.Json)]
        PhotoTake_Detail getPhotoTakeDetail(string id);

        /*--------------处理随手拍----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "processPhotoTake?photoTakeID={photoTakeID}&type={type}&answerContent={answerContent}&userID={userID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput processPhotoTake(string photoTakeID, string type, string answerContent, string userID);

        /*--------------随手拍举报处理----------------*/

        /*--------------删除随手拍----------------*/

        /*--------------批量删除随手拍----------------*/

        /*-------------删除随手拍评论------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deletePhotoTakeComment?commentID={commentID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deletePhotoTakeComment(string commentID);

        #endregion

        #region 建议处理
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getSuggestionList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Suggestion[]> getSuggestionList(string districtID, int offset, int limit, string order, string search, string sort);

        /*--------------查看建议详情----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getSuggestionDetail?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Suggestion_Detail> getSuggestionDetail(string id);

        /*--------------建议处理----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "processSuggestion?id={id}&userID={userID}&type={type}&answerContent={answerContent}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput processSuggestion(string id, string userID, int type, string answerContent);

        /*-------------镇级列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getSuggestionList_Z?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Suggestion[]> getSuggestionList_Z(string districtID, int offset, int limit, string order, string search, string sort);

        #endregion

        #region 软件反馈
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getFeedbackList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Feedback[]> getFeedbackList(string districtID, int offset, int limit, string order, string search, string sort);

        #endregion

        #region 活动管理
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getActivityList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Activity[]> getActivityList(string districtID, int offset, int limit, string order, string search, string sort);
       
        /*-------------获取活动详情------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getActivityDetail?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<Activity_Detail> getActivityDetail(string id);
        #endregion

        #region 社情民意
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getPeopleCaring?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_PeopleCaring[]> getPeopleCaring(string districtID, int offset, int limit, string order, string search, string sort);

        /*--------------新增信息-----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "addPeopleCaring?type={type}&details={details}&userID={userID}&districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addPeopleCaring(string type, string details, string userID, string districtID);

        /*--------------编辑信息-----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "editPeopleCaring?id={id}&type={type}&details={details}&userID={userID}&districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput editPeopleCaring(string id, string type, string details, string userID, string districtID);
        /*-------------删除社情民意信息---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deletePeopleCaring?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deletePeopleCaring(string id);
        /*-------------批量删除社情民意信息-----*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteMultiPeopleCaring?idStr={idStr}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteMultiPeopleCaring(string idStr);
        #endregion

        #region 主动巡检
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInitiativeCheckList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_InitiativeCheck[]> getInitiativeCheckList(string districtID, int offset, int limit, string order, string search, string sort);

        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "saveInitiativeCheckImage?initiativeCheckID={initiativeCheckID}&imageURL={imageURL}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput saveInitiativeCheckImage(string initiativeCheckID, string imageURL);

        /*-------------新增主动巡检------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "addInitiativeCheck?districtID={districtID}&initiativeCheckID={initiativeCheckID}&remark={remark}&userID={userID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addInitiativeCheck(string districtID, string initiativeCheckID, string remark, string userID);

        #endregion
        #endregion

        #region APP
        #region 系统
        /*-------------App登陆------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appLogin?name={name}&IDCard={IDCard}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputAppT<App_Login> appLogin(string name, string IDCard);

        /*-------------获取个人信息------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appGetClientInformation?clientID={clientID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputAppT<App_ClientInformation> appGetClientInformation(string clientID);

        /*-------------修改昵称------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "modifyNickName?clientID={clientID}&nickName={nickName}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp modifyNickName(string clientID, string nickName);

        /*-------------修改签名------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "modifySignature?clientID={clientID}&signature={signature}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp modifySignature(string clientID, string signature);

        /*-------------保存头像------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "savePortrait?clientID={clientID}&ImageUrl={ImageUrl}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp savePortrait(string clientID, string ImageUrl);
        #endregion

        #region 信息公告
        /*-------------获取信息公告---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appGetInformation?type={type}&offset={offset}&limit={limit}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputAppT<App_Information[]> appGetInformation(string type, int offset, int limit);
        #endregion

        #region 业务预约
        /*-------------预约业务----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appAddAppointment?clientID={clientID}&districtID={districtID}&serviceType={serviceType}&remark={remark}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appAddAppointment(string clientID, string districtID, string serviceType, string remark);

        /*-------------获取我的业务列表---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appGetAppointment?clientID={clientID}&offset={offset}&limit={limit}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputAppT<App_Appointment[]> appGetAppointment(string clientID, int offset, int limit);

        /*-------------获取业务类型列表---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appGetServiceType?", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputAppT<App_BusinessType[]> appGetServiceType();
        #endregion

        #region 随手拍
        /*-------------添加随手拍---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appAddPhotoTake?clientID={clientID}&photoContent={photoContent}&districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<string> appAddPhotoTake(string clientID, string photoContent, string districtID);

        /*---------------存储随手拍图片-------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appPhoto2PhotoTake?photoTakeID={photoTakeID}&imageURL={imageURL}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput appPhoto2PhotoTake(string photoTakeID, string imageURL);

        /*---------------获取随手拍列表-------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appGetPhotoTake?clientID={clientID}&offset={offset}&limit={limit}&isMine={isMine}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputAppT<App_PhotoTake[]> appGetPhotoTake(string clientID, int offset, int limit,int isMine);

        /*----------------获取随手拍详情-------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appGetPhotoDetail?id={id}&clientID={clientID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputAppT<App_PhotoTake> appGetPhotoDetail(string id, string clientID);


        /*----------------手动取消已发送的随手拍---------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appCancelPhotoTake?photoTakeID={photoTakeID}&clientID={clientID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appCancelPhotoTake(string photoTakeID, string clientID);

        /*----------------随手拍点赞/取消点赞---------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appSupportPhotoTake?photoTakeID={photoTakeID}&clientID={clientID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appSupportPhotoTake(string photoTakeID, string clientID);

        /*----------------举报随手拍---------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appInformPhotoTake?photoTakeID={photoTakeID}&clientID={clientID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appInformPhotoTake(string photoTakeID, string clientID);

        /*----------------随手拍评论---------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appCommentPhotoTake?photoTakeID={photoTakeID}&clientID={clientID}&commentContent={commentContent}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appCommentPhotoTake(string photoTakeID, string clientID, string commentContent);

        /*----------------取消评论---------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appCancelCommentPhotoTake?commentID={commentID}&clientID={clientID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appCancelCommentPhotoTake(string commentID, string clientID);
        #endregion

        #region 提建议
        /*----------------提建议---------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appAddSuggestion?districtID={districtID}&clientID={clientID}&suggestContent={suggestContent}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appAddSuggestion(string districtID, string clientID, string suggestContent);

        /*-------------获取我的建议列表---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appGetSuggestion?clientID={clientID}&offset={offset}&limit={limit}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputAppT<App_Suggestion[]> appGetSuggestion(string clientID, int offset, int limit);
        #endregion

        #region 软件反馈
        /*---------------新增反馈------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appAddFeedback?clientID={clientID}&districtID={districtID}&feedbackContent={feedbackContent}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appAddFeedback(string clientID, string districtID, string feedbackContent);
        #endregion

        #region 社区活动
        /*---------------新增活动------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appAddActivity?clientID={clientID}&theme={theme}&activityContent={activityContent}&activityTime={activityTime}&address={address}&phone={phone}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<string> appAddActivity(string clientID, string theme, string activityContent, string activityTime,string address,string phone);

        /*---------------图片图片------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appPhoto2Activity?ActivityID={ActivityID}&imageURL={imageURL}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput appPhoto2Activity(string ActivityID, string imageURL);

        /*-------------查看活动（我的）列表----------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appGetActivity?clientID={clientID}&offset={offset}&limit={limit}&isMine={isMine}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputAppT<App_Activity[]> appGetActivity(string clientID, int offset, int limit,int isMine);

        /*-------------查看活动详情---------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appGetActivityDetail?id={id}&clientID={clientID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputAppT<App_Activity> appGetActivityDetail(string id, string clientID);

        /*-------------取消发起的活动---------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appCancelActivity?activityID={activityID}&clientID={clientID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appCancelActivity(string activityID, string clientID);

        /*-------------参与（取消参与）活动--------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appParticipateActivity?activityID={activityID}&clientID={clientID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appParticipateActivity(string activityID, string clientID);

        /*-------------点赞（取消点赞）活动--------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "appSupportActivity?activityID={activityID}&clientID={clientID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputApp appSupportActivity(string activityID, string clientID);

        #endregion
        #endregion


        #region 统计

        #region 信息公告
        /*---------十日内信息公告发布统计---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInformationAnalysis_10?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<DYNC_Information_10> getInformationAnalysis_10(string districtID);
        #endregion

        #region 随手拍
        /*---------十日内随手拍统计---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getPhotoTake_10?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<DYNC_PhotoTake_10> getPhotoTake_10(string districtID);
        #endregion

        #region 建议处理
        /*---------十日内建议处理统计---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getSuggestion_10?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<DYNC_Suggestion_10> getSuggestion_10(string districtID);

        #endregion

        #region  社区活动
        /*---------十日内社区活动数目统计---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getActivityList_10", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<getActivityList_10> getActivityList_10();
        #endregion

        #region 主动巡检
        /*---------十日内主动巡检统计---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getInitiativeCheck_10?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<getInitiativeCheck_10> getInitiativeCheck_10(string districtID);
        #endregion

        #region 社情民意
        /*---------十日内社情民意统计---------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getPeopleCaring_10?districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<getPeopleCaring_10> getPeopleCaring_10(string districtID);
        #endregion

#endregion
    }
}
