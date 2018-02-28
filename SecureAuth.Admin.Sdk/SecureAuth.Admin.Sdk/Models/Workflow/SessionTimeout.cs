using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SecureAuth.Admin.Sdk.Models
{
    public class SessionTimeout
    {
        public string SessionStateName { get; set; }
        public int? IdleTimeoutLength { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DisplayTimeoutMessage? DisplayTimeoutMessage { get; set; }
    }
}