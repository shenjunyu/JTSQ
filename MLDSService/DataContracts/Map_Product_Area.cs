using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_Product_Area
    {
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
        public string description
        {
            get;
            set;
        }
        [DataMember]
        public Map_District_Area[] area
        {
            get;
            set;
        }
    }
}
