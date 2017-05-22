using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class App_Appointment_Answer
    {
        [DataMember]
        public string id
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
        public string userName
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
