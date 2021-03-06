﻿using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class CommonOutputT<T>
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
        public T data
        {
            get;
            set;
        }
    }
}
