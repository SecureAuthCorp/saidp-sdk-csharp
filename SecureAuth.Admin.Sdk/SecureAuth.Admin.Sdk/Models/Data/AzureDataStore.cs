namespace SecureAuth.Admin.Sdk.Models
{
    public class AzureMembershipDataStore : DataStoreBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TenantDomain { get; set; }
        public string ClientId { get; set; }
        public string AllowedGroups { get; set; }
        public string DeniedGroups { get; set; }
    }

    public class AzureProfileDataStore : DataStoreBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string TenantDomain { get; set; }
        public string ClientId { get; set; }
        public string AppKey { get; set; }
    }
}
