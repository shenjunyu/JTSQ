using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class LoginAccess
    {
        [DataMember]
        public bool success
        {
            get;
            set;
        }
        [DataMember]
        public string message
        {
            get;
            set;
        }
        [DataMember]
        public string userID
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
        public int districtLevel
        {
            get;
            set;
        }
    }
}
