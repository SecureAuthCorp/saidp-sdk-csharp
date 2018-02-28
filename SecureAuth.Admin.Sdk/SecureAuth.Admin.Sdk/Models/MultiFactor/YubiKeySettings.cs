using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class YubiKeySettings
    {
        public bool? EnableYubiKeyAuthentication { get; set; }
        public bool? ValidateYubiKey { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorYubiKeyStorage? StorageLocation { get; set; }
    }
}
