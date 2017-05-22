using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Product
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string type
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
        public string imageURL
        {
            get;
            set;
        }
        [DataMember]
        public string pin
        {
            get;
            set;
        }
        [DataMember]
        public string description
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
    }
}
