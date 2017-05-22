using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Family
    {
        [DataMember]
        public string id
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
        public string bookletType
        {
            get;
            set;
        }
        [DataMember]
        public string houseHolder
        {
            get;
            set;
        }
        [DataMember]
        public string houseHolderIDCard
        {
            get;
            set;
        }
        [DataMember]
        public string houseHolderPhone
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
        [DataMember]
        public string district
        {
            get;
            set;
        }
    }
}
