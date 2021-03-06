﻿using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class App_Information
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }
        [DataMember]
        public string title
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
        public string peek
        {
            get;
            set;
        }
        [DataMember]
        public string author
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
        public string mainText
        {
            get;
            set;
        }
        [DataMember]
        public string cover
        {
            get;
            set;
        }
    }
}
