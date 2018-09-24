using System.Runtime.Serialization;

namespace SmallestNumberTrifon.Model.Settings
{
    [DataContract]
    public class SettingsRequestBody
    {
        [DataMember]
        public Settings UpperLimit { get; set; }
    }
}
