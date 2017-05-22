using System.Runtime.Serialization;

namespace MLDSService.DataContracts.Analysis
{
    [DataContract]
    public class BUS_Information_10
    {
        [DataMember]
        public string[] date
        {
            get;
            set;
        }
        [DataMember]
        public int[] zongshu
        {
            get;
            set;
        }
        [DataMember]
        public int[] sum   //sum?
        {
            get;
            set;
        }
    }
}
