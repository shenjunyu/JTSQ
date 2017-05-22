using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Excel_RuralInsurance
    {

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
        public string phone
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
        public string year
        {
            get;
            set;
        }
    }
}
