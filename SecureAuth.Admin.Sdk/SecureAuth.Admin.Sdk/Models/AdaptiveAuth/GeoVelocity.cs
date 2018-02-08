using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class GeoVelocitySetting
    {
        public bool? Enabled { get; set; }
        public int? VelocityLimit { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? FailureAction { get; set; }
        public string FailureActionRedirect { get; set; }
    }
}
