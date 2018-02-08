using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models
{
    public class MultiFactor
    {
        public PhoneSetting PhoneSetting { get; set; }
        public PhoneBlocking PhoneBlocking { get; set; }
        public EmailSetting EmailSetting { get; set; }
        public KnowledgeBasedSetting KnowledgeBasedSetting { get; set; }
        public HelpDeskSettings HelpDeskSettings { get; set; }
        public PinSetting PinSetting { get; set; }
        public Oath Oath { get; set; }
        public PushNotification PushNotification { get; set; }
        public YubiKeySettings YubiKeySetting { get; set; }
        public MultiFactorSetting MultiFactorSetting { get; set; }
        [JsonProperty (ItemConverterType = typeof(StringEnumConverter))]
        public List<Enums.MultiFactorRegistrationMethod> RegistrationMethodOrder { get; set; }
    }
}
