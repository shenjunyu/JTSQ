using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class CommonMapPoint
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string x
        {
            get;
            set;
        }
        [DataMember]
        public string y
        {
            get;
            set;
        }
        [DataMember]
        public bool success
        {
            get;
            set;
        }
        [DataMember]
        public string message

        {
            get;
            set;
        }
    }
}
