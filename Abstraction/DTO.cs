using System.Runtime.Serialization;

namespace SmallestNumberTrifon.Abstraction
{
    [DataContract]
    public abstract class DTO<T> where T : class
    {
        [DataMember]
        public abstract T MessageBody { get; set; }
    }
}
