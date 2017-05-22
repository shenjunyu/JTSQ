using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class App_Activity
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string theme
        {
            get;
            set;
        }
        [DataMember]
        public string activityContent
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
        public string phone
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
        public int supportNum
        {
            get;
            set;
        }
        [DataMember]
        public int participateNum
        {
            get;
            set;
        }
        [DataMember]
        public bool isSupport
        {
            get;
            set;
        }
        [DataMember]
        public string address
        {
            get;
            set;
        }
        [DataMember]
        public bool isParticipate
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
        public string activityTime
        {
            get;
            set;
        }
        [DataMember]
        public App_Activity_Image[] images
        {
            get;
            set;
        }
        [DataMember]
        public App_Activity_Participator[] participators
        {
            get;
            set;
        }
    }
}
