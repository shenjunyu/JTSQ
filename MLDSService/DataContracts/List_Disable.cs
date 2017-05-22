using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_Disable
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string name    
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
        public string sex
        {
            get;
            set;
        }
        [DataMember]
        public string address
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
        public string guardian  //监护人
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
        [DataMember]
        public string district
        {
            get;
            set;
        }
    }
}
