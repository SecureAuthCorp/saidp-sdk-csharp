using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class UserRiskSetting
    {
        public bool? Enabled { get; set; }
        public int? HighRiskFrom { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? HighRiskAction { get; set; }
        public string HighRiskRedirect { get; set; }
        public int? MediumRiskFrom { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? MediumRiskAction { get; set; }
        public string MediumRiskRedirect { get; set; }
        public int? LowRiskFrom { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? LowRiskAction { get; set; }
        public string LowRiskRedirect { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? NoScoreAction { get; set; }
        public string NoScoreRedirect { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthUserRiskProfileField? ProfileField { get; set; }
    }
}
