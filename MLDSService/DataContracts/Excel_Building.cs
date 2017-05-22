using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Excel_Building
    {
        [DataMember]
        public string districtID
        {
            get;
            set;
        }
        [DataMember]
        public string plot
        {
            get;
            set;
        }
        [DataMember]
        public string houseNum
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
        [DataMember]
        public string structure
        {
            get;
            set;
        }
        [DataMember]
        public string floor
        {
            get;
            set;
        }
        [DataMember]
        public string roomNum
        {
            get;
            set;
        }
    }
}
