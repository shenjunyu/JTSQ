using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_HouseMember
    {
        [DataMember]
        public string bookletNum
        {
            get;
            set;
        }
        [DataMember]
        public string floor
        {
            get;
            set;
        }
        [DataMember]
        public string roomNum
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
        public int peopleNum
        {
            get;
            set;
        }
        [DataMember]
        public List_FamilyMember[] familyMembers
        {
            get;
            set;
        }
        [DataMember]
        public Map_HouseMember_FarmLand[] farmLand
        {
            get;
            set;
        }
    }
}
