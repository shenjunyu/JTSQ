using System.Runtime.Serialization;

namespace MLDSService.DataContracts.Analysis
{
    [DataContract]
    public class DYNC_Suggestion_10
    {
        [DataMember]
        public string[] date
        {
            get;
            set;
        }
        [DataMember]
        public int[] tongguo
        {
            get;
            set;
        }
        [DataMember]
        public int[] weitongguo
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
