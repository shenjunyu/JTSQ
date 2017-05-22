using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Excel_FitBuilding
    {
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
        public string x
        {
            get;
            set;
        }
        [DataMember]
        public string y
        {
            get;
            set;
        }
    }
}
