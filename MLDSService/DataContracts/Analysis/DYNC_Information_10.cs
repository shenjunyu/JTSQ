using System.Runtime.Serialization;

namespace MLDSService.DataContracts.Analysis
{
    [DataContract]
    public class DYNC_Information_10
    {
        [DataMember]
        public string[] date
        {
            get;
            set;
        }
        [DataMember]
        public int[] tongzhigonggao
        {
            get;
            set;
        }
        [DataMember]
        public int[] bianminfuwu
        {
            get;
            set;
        }
        [DataMember]
        public int[] dangjianyaowen
        {
            get;
            set;
        }
        [DataMember]
        public int[] shequtese
        {
            get;
            set;
        }
        [DataMember]
        public int[] sum
        {
            get;
            set;
        }
    }
}
