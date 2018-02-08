using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SecureAuth.Admin.Sdk.Models
{
    public class ProfileField
    {
        public string PropertyName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ProfileFieldSource? Source { get; set; }
        public string Field { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ProfileFieldDataFormat? DataFormat { get; set; }
        public bool? IsWritable { get; set; }
        public bool? DeleteField { get; set; }

        public bool ShouldSerializeDeleteField()
        {
            return false;
        }
    }
}
