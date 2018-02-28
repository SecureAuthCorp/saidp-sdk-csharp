using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SecureAuth.Admin.Sdk.Models
{
    public class SyslogSetting
    {
        public string Server { get; set; }
        public int? Port { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.SyslogRfcSpec? RfcSpec { get; set; }
        public int? PrivateEnterpriseNumber { get; set; }
    }
}
