using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SmallestNumberTrifon.Model.Settings
{
    [DataContract]
    public class Settings
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Limit { get; set; }
    }
}
