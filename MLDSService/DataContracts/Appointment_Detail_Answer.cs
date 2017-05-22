using System.Runtime.Serialization;
using MLDSData;
namespace MLDSService.DataContracts
{
    [DataContract]
    public class Appointment_Detail_Answer
    {
        [DataMember]
        public string name
        {
            get;
            set;
        }
        [DataMember]
        public string answerContent
        {
            get;
            set;
        }
        [DataMember]
        public string answerTime
        {
            get;
            set;
        }
    }
}
