using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Farm_Product_Value
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string year
        {
            get;
            set;
        }
        [DataMember]
        public string production
        {
            get;
            set;
        }
        [DataMember]
        public string value
        {
            get;
            set;
        }
    }
}
