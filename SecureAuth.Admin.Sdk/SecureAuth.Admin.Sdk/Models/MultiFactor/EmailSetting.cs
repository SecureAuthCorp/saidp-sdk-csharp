using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class EmailSetting
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorEmailField? Field1 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorEmailField? Field2 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorEmailField? Field3 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorEmailField? Field4 { get; set; }
    }
}
