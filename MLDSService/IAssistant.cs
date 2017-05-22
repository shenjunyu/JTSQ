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
    public interface IAssistant
    {
        #region 通讯录
        /*-------------列表查看------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getAddressList?districtID={districtID}&offset={offset}&limit={limit}&order={order}&search={search}&sort={sort}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<List_AddressList[]> getAddressList(string districtID, int offset, int limit, string order, string search, string sort);
        #endregion

        #region 日程管理
        /*-------------查看日程------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getCalendar?districtID={districtID}&userID={userID}&time={time}", ResponseFormat = WebMessageFormat.Json)]
        PageRows<ASS_Calendar[]> getCalendar(string districtID, string userID, string time);
        /*-------------新增日程------------*/
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "addCalendar?districtID={districtID}&newEvent={newEvent}&userID={userID}&time={time}", ResponseFormat = WebMessageFormat.Json)]
        CommonOutput addCalendar(string districtID, string newEvent, string userID, string time);
        #endregion
    }
}
