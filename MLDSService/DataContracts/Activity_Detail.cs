using System.Runtime.Serialization;
using MLDSData;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Activity_Detail
    {
        [DataMember]
        public string name
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
        public string phone
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
        public string createTIme
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
        public string address
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
        public Activity_Detail_Participator[] participators
        {
            get;
            set;
        }
    }
}
