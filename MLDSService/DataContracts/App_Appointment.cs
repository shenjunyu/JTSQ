using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class App_Appointment
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string businessType
        {
            get;
            set;
        }
        [DataMember]
        public string serviceType
        {
            get;
            set;
        }
        [DataMember]
        public string createTime
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
        [DataMember]
        public string remark
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
        public string nickName
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
        public string signature
        {
            get;
            set;
        }
        [DataMember]
        public App_Appointment_Answer[] answers
        {
            get;
            set;
        }
    }
}
