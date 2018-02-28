using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models
{
    public class AdaptiveAuthentication : AdaptiveAuthBase
    {
        public IpCountrySetting IpCountrySetting { get; set; }
        public AdaptiveAuthUserGroupSetting UserGroupSetting { get; set; }
        public IpReputationThreatDataSetting IpReputationThreatData { get; set; }
        public GeoVelocitySetting GeoVelocity { get; set; }
        public UserRiskSetting UserRisk { get; set; }
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<Enums.AdaptiveAuthAnalyzeEngineStateType> AnalyzeOrder { get; set; }
    }
}
