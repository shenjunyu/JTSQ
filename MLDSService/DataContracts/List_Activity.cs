using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Activity
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
        public string name
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
        public string address
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
        public string createTime
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
        public string status
        {
            get;
            set;
        }
        [DataMember]
        public App_Activity_Image images
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
