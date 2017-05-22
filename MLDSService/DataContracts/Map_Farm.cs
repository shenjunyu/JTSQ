using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_Farm
    {
        [DataMember]
        public string name
        {
            get;
            set;
        }
        [DataMember]
        public string description
        {
            get;
            set;
        }
        [DataMember]
        public Map_District_Area[] area
        {
            get;
            set;
        }
        [DataMember]
        public string contractorName
        {
            get;
            set;
        }
        [DataMember]
        public string contractorInform
        {
            get;
            set;
        }
        [DataMember]
        public string contractorIDCard
        {
            get;
            set;
        }
        [DataMember]
        public string contractorPortrait
        {
            get;
            set;
        }
        [DataMember]
        public string contractorPhone
        {
            get;
            set;
        }
        [DataMember]
        public Map_Farm_Product[] products
        {
            get;
            set;
        }
        [DataMember]
        public Map_Farm_Image[] images
        {
            get;
            set;
        }
    }
}
