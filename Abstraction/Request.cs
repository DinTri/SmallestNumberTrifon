using System.Runtime.Serialization;

namespace SmallestNumberTrifon.Abstraction
{
    [DataContract]
    public abstract class Request<T> : DTO<T> where T:class
    {
       
    }
}
