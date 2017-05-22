using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Military
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
        public string leaveTime
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
        public string isActive
        {
            get;
            set;
        }
        [DataMember]
        public string isBasic
        {
            get;
            set;
        }
        [DataMember]
        public string isDisable
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
