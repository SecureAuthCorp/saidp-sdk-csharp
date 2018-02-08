using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SecureAuth.Admin.Sdk.Models
{
    public class SqlMembershipDataStore : DataStoreBase
    {
        public string ConnectionString { get; set; }
        public bool? UseCyberArkVault { get; set; }
        public CyberArkVault CyberArkVault { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.SqlMembershipPasswordFormat? PasswordFormat { get; set; }
        public string AllowedGroups { get; set; }
        public string DeniedGroups { get; set; }
        public int? MaxInvalidPasswordAttempts { get; set; }
        public string SprocGetUser { get; set; }
        public string SprocGetPassword { get; set; }
        public string SprocResetPassword { get; set; }
        public string SprocCreateUser { get; set; }
    }

    public class SqlProfileDataStore : DataStoreBase
    {
        public string SprocGetUserProfile { get; set; }
        public string SprocUpdateProfile { get; set; }
        public string AllowedGroups { get; set; }
        public string ConnectionString { get; set; }
        public bool? UseCyberArkVault { get; set; }
        public CyberArkVault CyberArkVault { get; set; }
    }
}
