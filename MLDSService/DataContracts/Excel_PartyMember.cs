using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Excel_PartyMember
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
    }
}
