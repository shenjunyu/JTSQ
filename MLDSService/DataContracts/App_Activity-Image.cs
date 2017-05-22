using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class App_Activity_Image
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
