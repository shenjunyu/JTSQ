using System.Runtime.Serialization;
using MLDSData;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class PhotoTake_Detail
    {
        [DataMember]
        public bool success
        {
            get;
            set;
        }
        [DataMember]
        public string message
        {
            get;
            set;
        }
        [DataMember]
        public PhotoTake_Detail_Image Data
        {
            get;
            set;
        }
        [DataMember]
        public PhotoTake_Detail_Answer[] Answer
        {
            get;
            set;
        }
        [DataMember]
        public PhotoTake_Detail_Comment[] Comment
        {
            get;
            set;
        }
    }
}
