using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class App_Login
    {
        [DataMember]
        public string clinentID
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
    }
}
