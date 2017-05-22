using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_PopulationSearchByParty
    {
        [DataMember]
        public string id
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
        public string IDCard
        {
            get;
            set;
        }
        [DataMember]
        public string portrait
        {
            get;
            set;
        }
        [DataMember]
        public string joinTime
        {
            get;
            set;
        }
        [DataMember]
        public string department
        {
            get;
            set;
        }
        [DataMember]
        public string partyAge
        {
            get;
            set;
        }
        [DataMember]
        public double x
        {
            get;
            set;
        }
        [DataMember]
        public double y
        {
            get;
            set;
        }
    }
}
