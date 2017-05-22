using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_ChildrenInsurance
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string institutionID
        {
            get;
            set;
        }
        [DataMember]
        public string peopleID
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
        public string sex
        {
            get;
            set;
        }
        [DataMember]
        public string accountProperty
        {
            get;
            set;
        }
        [DataMember]
        public string studentNum
        {
            get;
            set;
        }
        [DataMember]
        public string exemptionType
        {
            get;
            set;
        }
        [DataMember]
        public string exemptionID
        {
            get;
            set;
        }
        [DataMember]
        public string contract
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
        public string district
        {
            get;
            set;
        }
        [DataMember]
        public string status
        {
            get;
            set;
        }
    }
}
