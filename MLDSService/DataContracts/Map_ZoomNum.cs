using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_ZoomNum
    {
        [DataMember]
        public string districtID
        {
            get;
            set;
        }
        [DataMember]
        public string districtName
        {
            get;
            set;
        }
        [DataMember]
        public string attachTo
        {
            get;
            set;
        }
        [DataMember]
        public int districtLevel
        {
            get;
            set;
        }
        [DataMember]
        public double x
        {
            get;
            set;
        }
        [DataMember]
        public double y
        {
            get;
            set;
        }
        [DataMember]
        public int number
        {
            get;
            set;
        }
    }
}
