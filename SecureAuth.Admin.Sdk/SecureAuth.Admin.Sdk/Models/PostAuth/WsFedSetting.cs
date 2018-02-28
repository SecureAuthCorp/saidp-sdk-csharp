using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models
{
    public class WsFedSetting : RedirectBase
    {
        public UserIdMapping UserIdMapping { get; set; }
        public WsFedSamlAssertion Assertion { get; set; }
        public List<SamlWsFedAttribute> Attributes { get; set; }
        public WsTrustEndpointConfiguration EndpointConfiguration { get; set; }
        public WsTrustRequestBlocking RequestBlocking { get; set; }
    }
}
