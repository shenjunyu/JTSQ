using System.Runtime.Serialization;
using MLDSData;
namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_Farm_Product_Year_Value
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
