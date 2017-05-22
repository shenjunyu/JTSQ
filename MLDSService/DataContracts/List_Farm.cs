using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Farm
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string contractor
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
        public string district
        {
            get;
            set;
        }
        [DataMember]
        public List_Farm_Product[] products
        {
            get;
            set;
        }
    }
}
