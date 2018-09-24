using System.Runtime.Serialization;
using SmallestNumberTrifon.Abstraction;

namespace SmallestNumberTrifon.Model.Settings
{
    [DataContract]
    public class SettingsResponse : Response<SettingsResponseBody>
    {
        public override SettingsResponseBody MessageBody { get; set; }
    }
}
