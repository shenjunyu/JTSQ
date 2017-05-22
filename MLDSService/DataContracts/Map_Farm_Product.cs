using System.Runtime.Serialization;
using MLDSData;
namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_Farm_Product
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string productName
        {
            get;
            set;
        }
        [DataMember]
        public string area
        {
            get;
            set;
        }
        [DataMember]
        public string expertName
        {
            get;
            set;
        }
        [DataMember]
        public string expertPortrait
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
        public Map_Farm_Product_Year_Value[] values
        {
            get;
            set;
        }
    }
}
