using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_PopulationSearchByLeader
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
        public string duty
        {
            get;
            set;
        }
        [DataMember]
        public string district
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
