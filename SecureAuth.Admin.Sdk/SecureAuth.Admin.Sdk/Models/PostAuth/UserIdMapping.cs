using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class UserIdMapping
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthUserIdMappingType? Mapping { get; set; }
        public string NameIdFormat { get; set; }
        public bool? EncodeToBase64 { get; set; }
    }
}
