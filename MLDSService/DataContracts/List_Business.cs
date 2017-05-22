using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Business
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string business
        {
            get;
            set;
        }
        [DataMember]
        public string service
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
        public string createTime
        {
            get;
            set;
        }
        [DataMember]
        public string processTime
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
        public string remark
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
