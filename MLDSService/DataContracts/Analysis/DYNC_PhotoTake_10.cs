using System.Runtime.Serialization;

namespace MLDSService.DataContracts.Analysis
{
    [DataContract]
    public class DYNC_PhotoTake_10
    {
        [DataMember]
        public string[] date
        {
            get;
            set;
        }
        [DataMember]
        public int[] yichuli
        {
            get;
            set;
        }
        [DataMember]
        public int[] weichuli
        {
            get;
            set;
        }
        [DataMember]
        public int[] yijujue
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
