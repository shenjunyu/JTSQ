using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class App_BusinessType
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string businessName
        {
            get;
            set;
        }
        [DataMember]
        public App_ServiceType[] service
        {
            get;
            set;
        }
    }
}
