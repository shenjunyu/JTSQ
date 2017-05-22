using System.Runtime.Serialization;

namespace MLDSService.DataContracts.Analysis
{
    [DataContract]
    public class getPeopleCaring_10
    {
        [DataMember]
        public string[] date
        {
            get;
            set;
        }
        [DataMember]
        public int[] zhixun
        {
            get;
            set;
        }
        [DataMember]
        public int[] qiuzhu
        {
            get;
            set;
        }
        [DataMember]
        public int[] zoufang
        {
            get;
            set;
        }
        [DataMember]
        public int[] tiaojie
        {
            get;
            set;
        }
        [DataMember]
        public int[] toushu
        {
            get;
            set;
        }
        [DataMember]
        public int[] maodun
        {
            get;
            set;
        }
        [DataMember]
        public int[] jiufen
        {
            get;
            set;
        }
        [DataMember]
        public int[] qita
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
