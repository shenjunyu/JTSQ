using System.Runtime.Serialization;
using MLDSData;
namespace MLDSService.DataContracts
{
    [DataContract]
    public class PhotoTake_Detail_Image
    {
        [DataMember]
        public string name
        {
            get;
            set;
        }
        [DataMember]
        public string nickName
        {
            get;
            set;
        }
        [DataMember]
        public string photoTakeContent
        {
            get;
            set;
        }
        [DataMember]
        public string phone
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
        public int supportNum
        {
            get;
            set;
        }
        [DataMember]
        public DYNC_PhotoTake_Image[] image
        {
            get;
            set;
        }
    }
}
