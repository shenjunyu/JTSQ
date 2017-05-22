using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class App_PhotoTake_Comment
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string clientID
        {
            get;
            set;
        }
        [DataMember]
        public string commentContent
        {
            get;
            set;
        }
        [DataMember]
        public string commentTime
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
    }
}
