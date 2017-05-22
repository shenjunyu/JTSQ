using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_BasicPopulation
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
        public string phone
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
        public string nation
        {
            get;
            set;
        }
        [DataMember]
        public string marriageStatus
        {
            get;
            set;
        }
        [DataMember]
        public string politicsStatus
        {
            get;
            set;
        }
        [DataMember]
        public string censusRegister
        {
            get;
            set;
        }
        [DataMember]
        public string bookletNum
        {
            get;
            set;
        }
        [DataMember]
        public string populationType
        {
            get;
            set;
        }
        [DataMember]
        public string workPlace
        {
            get;
            set;
        }
        [DataMember]
        public string educationDegree
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
        public string address
        {
            get;
            set;
        }
    }
}
