using System.Runtime.Serialization;
using MLDSData;
namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_Farm_Image
    {
        [DataMember]
        public string id
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
    }
}
