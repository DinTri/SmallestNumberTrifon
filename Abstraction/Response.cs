using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmallestNumberTrifon.Abstraction
{
    [DataContract]
    public abstract class Response<T> : DTO<T> where T:class
    {
        #region Properties

        [DataMember]
        public List<int> StatusCodes { get; set; }
        
        #endregion Properties
    }
}
