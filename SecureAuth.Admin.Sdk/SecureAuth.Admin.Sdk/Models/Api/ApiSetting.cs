using System.Runtime.Serialization;

namespace SecureAuth.Admin.Sdk.Models
{
    public class ApiSetting
    {
        public bool? EnableApi { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationKey { get; set; }
        public bool? EnableAuthenticationApi { get; set; }
        public bool? EnableIdentityManagementUserProperties { get; set; }
        public bool? EnableIdentityManagementAdminInitiatedPasswordReset { get; set; }
        public bool? EnableIdentityManagementUserSelfServicePasswordChange { get; set; }
        public bool? EnableIdentityManagementUserGroupAssociation { get; set; }
        public bool? EnableSecureAuthCredentialProviderApi { get; set; }
        public bool? EnableLoginForWindowsApi { get; set; }
    }
}

