using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class IpReputationThreatDataSetting
    {
        public bool? Enabled { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? ExtremeRiskAction { get; set; }
        public string ExtremeRiskRedirect { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? HighRiskAction { get; set; }
        public string HighRiskRedirect { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? MediumRiskAction { get; set; }
        public string MediumRiskRedirect { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? LowRiskAction { get; set; }
        public string LowRiskRedirect { get; set; }
        public string IpWhitelist { get; set; }
        public bool? RequireUsernameBeforeAdaptiveAuth { get; set; }
        public bool? HasValidLicense { get; set; }
    }
}
