using MLDSData;
using MLDSService.DataContracts;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MLDSService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IPopulation”。
    [ServiceContract]
    public interface IPopulation
    {
        #region 基础人口
        /*-----------------列表查看----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getBasicPopulationList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_BasicPopulation[]> getBasicPopulationList(string districtID, int offset, int limit, string order, string search, string sort);

        /*-----------------新增基础人口----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "addBasicPopulation?"+
            "districtID={districtID}&name={name}&IDCard={IDCard}&sex={sex}&nation={nation}&" +
            "plot={plot}&houseNum={houseNum}&bookletNum={bookletNum}&relationship={relationship}&" +
            "censusRegister={censusRegister}&populationType={populationType}&marriageStatus={marriageStatus}&" +
            "politicsStatus={politicsStatus}&educationDegree={educationDegree}&phone={phone}&" +
            "workPlace={workPlace}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addBasicPopulation(string districtID, string name, string IDCard,
            string sex, string nation, string plot, string houseNum, string bookletNum, string relationship,
            string censusRegister, string populationType, string marriageStatus, string politicsStatus,
            string educationDegree, string phone, string workPlace);

        /*-----------------编辑基础人口----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "editBasicPopulation?" +
            "id={id}&districtID={districtID}&name={name}&IDCard={IDCard}&sex={sex}&nation={nation}&" +
            "plot={plot}&houseNum={houseNum}&bookletNum={bookletNum}&relationship={relationship}&" +
            "censusRegister={censusRegister}&populationType={populationType}&marriageStatus={marriageStatus}&" +
            "politicsStatus={politicsStatus}&educationDegree={educationDegree}&phone={phone}&" +
            "workPlace={workPlace}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput editBasicPopulation(string id,string districtID, string name, string IDCard,
            string sex, string nation, string plot, string houseNum, string bookletNum, string relationship,
            string censusRegister, string populationType, string marriageStatus, string politicsStatus,
            string educationDegree, string phone, string workPlace);

        /*-----------------删除基础人口----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteBasicPopulation?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteBasicPopulation(string id);

        /*-----------------批量删除基础人口----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteMultiBasicPopulation?idStr={idStr}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteMultiBasicPopulation(string idStr);

        /*------------根据身份证获取个人信息--------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getSinglePopulationByIDCard?IDCard={IDCard}&districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<POP_Basic> getSinglePopulationByIDCard(string IDCard, string districtID);

        /*------------根据id获取个人信息--------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getSinglePopulationByID?id={id}&districtID={districtID}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutputT<List_BasicPopulation[]> getSinglePopulationByID(string id,string districtID);
        #endregion

        #region 家庭档案
        /*-----------------列表查看----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getFamilyList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Family[]> getFamilyList(string districtID, int offset, int limit, string order, string search, string sort);

        /*------------查看家庭人员-------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getFamilyMember?bookletNum={bookletNum}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_FamilyMember[]> getFamilyMember(string bookletNum);
        #endregion

        #region 党员管理
        /*-----------------列表查看----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getPartyMemberList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_PartyMember[]> getPartyMemberList(string districtID, int offset, int limit, string order, string search, string sort);

        /*-----------------新增党员--------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "addPartyMember?districtID={districtID}&populationID={populationID}&joinTime={joinTime}&department={department}&portrait={portrait}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addPartyMember(string districtID, string populationID, string joinTime, string department, string portrait);
        #endregion

        #region 民兵管理
        /*-----------------列表查看----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getMilitaryList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Military[]> getMilitaryList(string districtID, int offset, int limit, string order, string search, string sort);

        #endregion

        #region 工作人员
        /*-----------------列表查看----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getLeaderList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Leader[]> getLeaderList(string districtID, int offset, int limit, string order, string search, string sort);

        #endregion

        #region 残疾人
        /*-----------------列表查看----------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getDisabled?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_Disable[]> getDisabled(string districtID, int offset, int limit, string order, string search, string sort);

        /*-----------------新增残疾人--------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "addDisabled?name={name}&sex={sex}&IDCard={IDCard}&disableNum={disableNum}&disablelevel={disablelevel}&relieffunds={relieffunds}&guardian={guardian}&explain={explain}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addDisabled(string name, string sex, string IDCard, string disableNum, string disablelevel, string relieffunds, string guardian, string explain);

        /*-----------------编辑残疾人--------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "editDisabled?id={id}&name={name}&sex={sex}&IDCard={IDCard}&disableNum={disableNum}&disablelevel={disablelevel}&relieffunds={relieffunds}&guardian={guardian}&explain={explain}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput editDisabled(string id, string name, string sex, string IDCard, string disableNum, string disablelevel, string relieffunds, string guardian, string explain);
        /*-----------------删除残疾人--------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteDisabled?id={id}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteDisabled(string id);
        /*-----------------批量删除残疾人--------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "deleteMultiDisabled?idStr={idStr}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput deleteMultiDisabled(string idStr);
        #endregion
    }
}
