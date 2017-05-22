using System.Runtime.Serialization;

namespace MLDSService.DataContracts
{
    [DataContract]
    public class Map_District_Area
    {

        [DataMember]
        public double x
        {
            get;
            set;
        }
        [DataMember]
        public double y
        {
            get;
            set;
        }
    }
}
