using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class WsTrustEndpoint
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthWsTrustEndpoint? Id { get; set; }
        public bool? Enabled { get; set; }
        public string EndpointPath { get; set; }
        public string AuthenticationType { get; set; }
        public string SecurityMode { get; set; }
        public string Type { get; set; }
    }
}
