using System.Runtime.Serialization;
using SmallestNumberTrifon.Abstraction;

namespace SmallestNumberTrifon.Model.Settings
{
    [DataContract]
    public class SettingsRequest : Request<SettingsRequestBody>
    {
        public override SettingsRequestBody MessageBody { get; set; }
    }
}
