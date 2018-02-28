using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SecureAuth.Admin.Sdk.Models
{
    public class PasswordThrottle
    {
        public bool? Enabled { get; set; }
        public int? MaxFailedAttempts { get; set; }
        public int? Interval { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.TimeUnit? TimeUnit { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.WorkflowPasswordThrottleAction? Action { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.WorkflowPasswordThrottleStorage? StorageLocation { get; set; }

    }
}
