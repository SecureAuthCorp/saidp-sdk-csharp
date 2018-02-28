using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SecureAuth.Admin.Sdk.Models
{
    public class MobileProfileSetting
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DFPMobileMode? FpMode { get; set; }
        public string CookieNamePrefix { get; set; }
        public int? CookieExpireLength { get; set; }
        public bool? MatchFpIdInCookie { get; set; }
        public bool? SkipIpMatch { get; set; }
        public int? AuthenticationThreshold { get; set; }
        public int? UpdateThreshold { get; set; }
    }
}