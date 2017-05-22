using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Excel_Population
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
        public string districtID
        {
            get;
            set;
        }
        [DataMember]
        public string plot
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
        public string structure
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
        public string relationship
        {
            get;
            set;
        }
    }
}
