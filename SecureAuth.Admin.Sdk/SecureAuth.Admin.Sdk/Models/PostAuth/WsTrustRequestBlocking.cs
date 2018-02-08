using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models
{
    public class WsTrustRequestBlocking
    {
        public bool? UseAdaptiveAuthForIpBlocking { get; set; }
        public bool? EnableRequestBlocking { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.WsTrustRequestBlockingConditionLogic? ConditionLogic { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.WsTrustBlockingRule? IpAddressBlockingRule { get; set; }
        public List<string> IpAddresses { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.WsTrustBlockingRule? ApplicationBlockingRule { get; set; }
        public List<string> Applications { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.WsTrustBlockingRule? UserAgentBlockingRules { get; set; }
        public List<string> UserAgents { get; set; }
    }
}
