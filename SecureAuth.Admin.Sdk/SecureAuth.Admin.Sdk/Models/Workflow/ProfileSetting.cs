using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class ProfileSetting
    {
        public int? FpExpirationLength { get; set; }
        public int? FpExpirationSinceLastAccess { get; set; }
        public bool? AllowOnlyOneFpCookiePerBrowser { get; set; }
        public int? TotalFpMaxCount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DFPAllowToReplaceWhenExceedMaxAccount? WhenExceedingMaxCount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DFPOrderBy? ReplaceInOrderBy { get; set; }
        public int? FpAccessRecordsMaxCount { get; set; }
    }
}