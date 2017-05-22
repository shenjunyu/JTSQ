using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_PartyMember
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
        public string sex
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
        public int age
        {
            get;
            set;
        }
        [DataMember]
        public int partyAge
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
        public string portrait
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
    }
}
