using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Excel_Disabled
    {

        [DataMember]
        public string name
        {
            get;
            set;
        }
        [DataMember]
        public string sex
        {
            get;
            set;
        }
        [DataMember]
        public string IDCard
        {
            get;
            set;
        }
        [DataMember]
        public string disableNum
        {
            get;
            set;
        }
        [DataMember]
        public string disablelevel
        {
             get;
             set;
             }
        [DataMember]
        public string relieffunds
        {
            get;
            set;
        }
        [DataMember]
        public string guardian
        {
            get;
            set;
        }

        [DataMember]
        public string explain
        {
            get;
            set;
        }
    }
}
