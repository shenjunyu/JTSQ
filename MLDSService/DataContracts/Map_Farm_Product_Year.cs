using System.Runtime.Serialization;
using MLDSData;
namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_Farm_Product_Year
    {
        [DataMember]
        public string year
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
