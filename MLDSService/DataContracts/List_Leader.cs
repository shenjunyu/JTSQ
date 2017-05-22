using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Leader
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
        public int age
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
    }
}
