using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class App_ServiceType
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string serviceName
        {
            get;
            set;
        }
    }
}
