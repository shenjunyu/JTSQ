using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MLDSService
{
    [DataContract]
    public class PageRows<T>
    {
        [DataMember]
        public int total
        {
            get;
            set;
        }

        [DataMember]
        public T rows
        {
            get;
            set;
        }

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



    }
}

