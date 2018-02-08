using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models
{
    public class SamlSetting : RedirectBase
    {
        public UserIdMapping UserIdMapping { get; set; }
        public WsFedSamlAssertion Assertion { get; set; }
        public List<SamlWsFedAttribute> Attributes { get; set; }
        public List<ExtendedSamlAttribute> ExtendedSamlAttributes { get; set; }
    }
}
