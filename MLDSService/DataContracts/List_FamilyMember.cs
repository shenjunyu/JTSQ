using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_FamilyMember
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
        public string relationship
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
    }
}
