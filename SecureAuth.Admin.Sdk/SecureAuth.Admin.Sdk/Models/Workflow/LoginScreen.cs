using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class LoginScreen
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DefaultWorkflow? DefaultWorkflow { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.KioskOption? PublicPrivateMode { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DefaultKiosk? PublicPrivateDefault { get; set; }
        public bool? RememberPublicPrivateUserSelection { get; set; }
        public bool? ShowUserIdTextbox { get; set; }
        public bool? ShowInlinePasswordChange { get; set; }
        public PasswordThrottle PasswordThrottle { get; set; }
    }
}