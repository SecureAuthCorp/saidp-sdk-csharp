using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web.Configuration;

namespace SecureAuth.Admin.Sdk.Models
{
    public class LogSetting
    {
        public string LogInstanceId { get; set; }
        public bool? EnableAuditSyslog { get; set; }
        public bool? EnableAuditEventLog { get; set; }
        public bool? EnableAuditTextLog { get; set; }
        public bool? EnableAuditDatabaseLog { get; set; }
        public bool? EnableAuditExtendedOtpLog { get; set; }
        public bool? EnableDebugSyslog { get; set; }
        public bool? EnableDebugEventLog { get; set; }
        public bool? EnableDebugTextLog { get; set; }
        public bool? EnableErrorSyslog { get; set; }
        public bool? EnableErrorEventLog { get; set; }
        public bool? EnableErrorTextLog { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomErrorsMode? CustomErrorMode { get; set; }
        public string CustomErrorRedirect { get; set; }
        public SyslogSetting SyslogSetting { get; set; }
        public string LogDatabaseConnectionString { get; set; }
    }
}
