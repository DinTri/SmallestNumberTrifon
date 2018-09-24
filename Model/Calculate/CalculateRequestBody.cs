using System.Runtime.Serialization;

namespace SmallestNumberTrifon.Model.Calculate
{
    [DataContract]
    public class CalculateRequestBody
    {
        //[DataMember]
        //public int Id { get; set; }
        [DataMember]
        public int Limit { get; set; }
    }
}
