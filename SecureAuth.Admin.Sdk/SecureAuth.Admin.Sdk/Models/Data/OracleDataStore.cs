using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SecureAuth.Admin.Sdk.Models
{
    public class OracleMembershipDataStore : DataStoreBase
    {
        public string ConnectionString { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.OracleMembershipPasswordFormat? PasswordFormat { get; set; }
        public string PasswordSalt { get; set; }
        public string AllowedGroups { get; set; }
        public string DeniedGroups { get; set; }
        public string SprocGetUser { get; set; }
        public string SprocGetPassword { get; set; }
        public string SprocUpdateUser { get; set; }
        public string SprocResetPassword { get; set; }
        public string SprocChangePassword { get; set; }
        public string SprocCreateUser { get; set; }
        public string SprocLockUser { get; set; }
        public string SprocUnlockUser { get; set; }
        public bool? UseCyberArkVault { get; set; }
        public CyberArkVault CyberArkVault { get; set; }
    }

    public class OracleProfileDataStore : DataStoreBase
    {
        public string ConnectionString { get; set; }
        public bool? UseCyberArkVault { get; set; }
        public CyberArkVault CyberArkVault { get; set; }
        public string SprocGetProfile { get; set; }
        public string SprocUpdateProfile { get; set; }
    }
}
