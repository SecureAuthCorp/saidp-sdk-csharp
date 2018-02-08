using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class PushNotification
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorPushNotificationRequestType? RequestType { get; set; }
        public int? LoginRequestTimeout { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultifactorPushNotificationAcceptMethod? AcceptMethod { get; set; }
        public string CompanyName { get; set; }
        public string ApplicationName { get; set; }
        public int? MaxDeviceCount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorPushNotificationExceedMaxCountAction? ExceedingMaxCountAction { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorPushNotificationReplaceOrderBy? ReplaceOrderBy { get; set; }
    }
}
