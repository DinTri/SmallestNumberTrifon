using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.Serialization;

namespace SmallestNumberTrifon.Model.Calculate
{
    [DataContract]
    public class Calculate
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public BigInteger Result { get; set; }

        [DataMember]
        public TimeSpan Duration { get; set; }
    }
}
