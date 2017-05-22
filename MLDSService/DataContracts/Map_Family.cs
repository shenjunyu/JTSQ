using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_Family
    {
        [DataMember]
        public string district
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
        public string structure
        {
            get;
            set;
        }
        [DataMember]
        public string houseNum
        {
            get;
            set;
        }
        [DataMember]
        public int peopleNum
        {
            get;
            set;
        }
        [DataMember]
        public Map_HouseMember[] houseMembers
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
