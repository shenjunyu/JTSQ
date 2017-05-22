using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class App_PhotoTake
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string photoContent
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
        public bool isSupport
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
        public App_PhotoTake_Image[] images
        {
            get;
            set;
        }
        [DataMember]
        public App_PhotoTake_Answer[] answers
        {
            get;
            set;
        }
        [DataMember]
        public App_PhotoTake_Comment[] comments
        {
            get;
            set;
        }
    }
}
