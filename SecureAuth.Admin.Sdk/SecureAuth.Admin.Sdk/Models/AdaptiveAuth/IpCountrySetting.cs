using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models
{
    public class IpCountrySetting
    {
        public bool? Enabled { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthIpCountryRestrictionType? RestrictionType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthInListAction? InListAction { get; set; }
        public List<string> IpCountryList { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.AdaptiveAuthAction? FailureAction { get; set; }
        public string FailureActionRedirect { get; set; }
        public bool? RequireUsernameBeforeAdaptive { get; set; }
    }
}
