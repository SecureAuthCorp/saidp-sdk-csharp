using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class LdapMembershipDataStore : DataStoreBase
    {
        public string Server { get; set; }
        public string DistinguishedName { get; set; }
        public string Domain { get; set; }
        public bool? AllowAnonymousLookup { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LdapMembershipConnectionMode? ConnectionMode { get; set; }
        public bool? UseCyberArkVault { get; set; }
        public CyberArkVault CyberArkVault { get; set; }
        public string ServiceAccount { get; set; }
        public string ServiceAccountPassword { get; set; }
        public string SearchAttribute { get; set; }
        public string SearchFilter { get; set; }
        public bool? UseAdvancedAdUserCheck { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LdapMembershipValidateUserType? ValidateUserType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LdapMembershipUserGroupCheckType? UserGroupCheckType { get; set; }
        public string UserGroups { get; set; }
        public bool? IncludeNestedGroups { get; set; }
        public string GroupsField { get; set; }
        public int? MaxInvalidPasswordAttempt { get; set; }
    }

    public class LdapProfileDataStore : DataStoreBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.LdapProfileConnectionProtection? ConnectionMode { get; set; }
        public string ConnectionString { get; set; }
        public string SearchFilter { get; set; }
        public string SearchAttribute { get; set; }
        public bool? UseCyberArkVault { get; set; }
        public CyberArkVault CyberArkVault { get; set; }
        public string UserGroups { get; set; }
        public string ConnectionUsername { get; set; }
        public string ConnectionPassword { get; set; }
        public bool? IncludeNestedGroups { get; set; }
    }
}
