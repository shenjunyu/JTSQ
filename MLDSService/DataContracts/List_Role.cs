using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Role
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string roleName
        {
            get;
            set;
        }
        [DataMember]
        public string users
        {
            get;
            set;
        }
    }
}
