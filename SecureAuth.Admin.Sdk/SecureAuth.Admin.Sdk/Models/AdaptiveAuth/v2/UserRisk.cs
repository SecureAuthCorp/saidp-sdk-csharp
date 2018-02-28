using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models.v2
{
    public class UserRiskSetting
    {
        public bool? Enabled { get; set; }
        public List<UserRiskProvider> Providers { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? HighRiskAction { get; set; }
        public string HighRiskRedirect { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? MediumRiskAction { get; set; }
        public string MediumRiskRedirect { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? LowRiskAction { get; set; }
        public string LowRiskRedirect { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? NoScoreAction { get; set; }
        public string NoScoreRedirect { get; set; }
    }
}
