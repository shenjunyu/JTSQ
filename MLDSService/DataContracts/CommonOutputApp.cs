using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class CommonOutputApp
    {
        [DataMember]
        public int IsOk
        {
            get;
            set;
        }
        [DataMember]
        public string Msg
        {
            get;
            set;
        }
    }
}
