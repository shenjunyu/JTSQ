using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Farm_Product
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
        public double area
        {
            get;
            set;
        }
        [DataMember]
        public string location
        {
            get;
            set;
        }
        [DataMember]
        public string expert
        {
            get;
            set;
        }
        [DataMember]
        public List_Farm_Product_Value[] values
        {
            get;
            set;
        }
    }
}
