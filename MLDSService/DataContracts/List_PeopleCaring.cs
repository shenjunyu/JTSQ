using System.Runtime.Serialization;
using MLDSData;
namespace MLDSService.DataContracts
{
    [DataContract]
    public class List_PeopleCaring
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
        public string type
        {
            get;
            set;
        }
        [DataMember]
        public string details
        {
            get;
            set;
        }
        [DataMember]
        public string createTime
        {
            get;
            set;
        }
        [DataMember]
        public string districtID
        {
            get;
            set;
        }
    }
}
