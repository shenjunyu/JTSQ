using System.Runtime.Serialization;
namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_User
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string name
        {
            get;
            set;
        }
        [DataMember]
        public string userName
        {
            get;
            set;
        }
        [DataMember]
        public string role
        {
            get;
            set;
        }
        [DataMember]
        public string status
        {
            get;
            set;
        }
        [DataMember]
        public string portrait
        {
            get;
            set;
        }
        [DataMember]
        public string lastTime
        {
            get;
            set;
        }
        [DataMember]
        public string district
        {
            get;
            set;
        }
        [DataMember]//权限模块
        public string authority
        {
            get;
            set;
        }
    }
}
