using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class MultiFactorSetting
    {
        public bool? InlineInitializeMissingPhone { get; set; }
        public bool? InlineInitializeMissingEmail { get; set; }
        public bool? InlineInitializeMissingKbAnswers { get; set; }
        public bool? InlineInitializeMissingPin { get; set; }
        public bool? EnableAutoSubmitWhenAvailable { get; set; }
        public int? OtpLength { get; set; }
        public bool? EnableThrottling { get; set; }
        public int? ThrottleMaxFailedAttempts { get; set; }
        public int? ThrottleInterval { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.TimeUnit? ThrottleTimeUnit { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorThrottleAction? ThrottleAction { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorThrottleStorage? ThrottleStorageLocation { get; set; }
        public int? OtpValidateThrottleMaxFailedAttempts { get; set; }
        public int? OtpValidateThrottleInterval { get; set; }
        public Enums.TimeUnit? OtpValidateThrottleTimeUnit { get; set; }
    }
}
