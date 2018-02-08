using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class SamlWsFedAttribute
    {
        public int? AttributeNumber { get; set; }
        public string Name { get; set; }
        public string NameSpace { get; set; }
        public string Format { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthUserIdMappingType? Value { get; set; }
        public string GroupFilterExpression { get; set; }
    }
}
