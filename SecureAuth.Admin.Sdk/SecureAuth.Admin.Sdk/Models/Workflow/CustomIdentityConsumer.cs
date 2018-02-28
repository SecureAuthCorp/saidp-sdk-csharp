using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class CustomIdentityConsumer
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ReceiveToken? ReceiveToken { get; set; }
        public bool? RequireBeginSite { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.BeginSite? BeginSite { get; set; }
        public bool? WindowsSsoUserImpersonation { get; set; }
        public bool? WindowsSsoWindowsAuthentication { get; set; }
        public string YubiKeyProvisionPage { get; set; }
        public string CustomBeginSiteUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ReceiveTokenDataType? ReceiveTokenDataType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.SendTokenDataType? SendTokenDataType { get; set; }
        public bool? UserIdCheck { get; set; }
        public bool? AllowTransparentSso { get; set; }
        public string Delimiter { get; set; }
        public int? GetSharedSecret { get; set; }
        public int? SetSharedSecret { get; set; }
    }
}
