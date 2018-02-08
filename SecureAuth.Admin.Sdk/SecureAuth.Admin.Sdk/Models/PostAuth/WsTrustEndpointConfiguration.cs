using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models
{
    public class WsTrustEndpointConfiguration
    {
        public string Host { get; set; }
        public List<WsTrustEndpoint> Endpoints { get; set; }
    }
}
