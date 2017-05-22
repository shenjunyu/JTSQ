using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_InitiativeCheck_Image
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string imageURL
        {
            get;
            set;
        }
    }
}
