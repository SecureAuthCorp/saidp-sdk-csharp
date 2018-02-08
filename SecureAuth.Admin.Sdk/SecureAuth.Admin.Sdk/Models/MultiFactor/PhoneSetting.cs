using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class PhoneSetting
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorPhoneField? Field1 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorPhoneField? Field2 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorPhoneField? Field3 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorPhoneField? Field4 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorPhoneSmsSelect? PhoneSmsSelected { get; set; }
        public bool? IsVisible { get; set; }
        public int? DefaultCountryCode { get; set; }
        public string Mask { get; set; }
    }
}
