using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models
{
    public class WebServiceMembershipDataStore : DataStoreBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? Failover { get; set; }
        public List<string> MainUrls { get; set; }
    }

    public class WebServiceProfileDataStore : DataStoreBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AllowedUserGroups { get; set; }
        public bool? Failover { get; set; }
        public List<string> MainUrls { get; set; }
    }
}
