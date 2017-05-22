using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_InitiativeCheck
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string userName
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
        public string createTime
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
        public List_InitiativeCheck_Image[] images
        {
            get;
            set;
        }
    }
}
