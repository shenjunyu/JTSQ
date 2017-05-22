using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_FarmLand
    {
        [DataMember]
        public string name
        {
            get;
            set;
        }
        [DataMember]
        public string IDCard
        {
            get;
            set;
        }
        [DataMember]
        public string phone
        {
            get;
            set;
        }
        [DataMember]
        public string farmLandID
        {
            get;
            set;
        }
        [DataMember]
        public string product
        {
            get;
            set;
        }
        [DataMember]
        public string farmArea
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
        [DataMember]
        public Map_District_Area[] area
        {
            get;
            set;
        }
    }
}
