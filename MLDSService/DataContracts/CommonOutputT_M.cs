using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class CommonOutputT_M<T1,T2>
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
        public T1 data1
        {
            get;
            set;
        }
        [DataMember]
        public T2 data2
        {
            get;
            set;
        }
    }
}
