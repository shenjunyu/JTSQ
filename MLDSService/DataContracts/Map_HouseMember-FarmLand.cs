using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_HouseMember_FarmLand
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string address
        {
            get;
            set;
        }
    }
}
