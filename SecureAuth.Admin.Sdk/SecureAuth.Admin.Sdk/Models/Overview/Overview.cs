using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class Overview
    {
        public string RealmName { get; set; }
        public string RealmDescription { get; set; }
        public string CompanyLogoFile { get; set; }
        public string ApplicationLogoFile { get; set; }
        public string DocumentTitle { get; set; }
        public string PageHeader { get; set; }
        public string Theme { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.UsernameDisplayField? UsernameDisplay { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.UsernameLocation? UsernameLocation { get; set; }
        public string ForgotUsernameUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ForgotUsernameUrlLocation? ForgotUsernamePageLocation { get; set; }
        public string ForgotPasswordUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.ForgotPasswordUrlLocation? ForgotPasswordPageLocation { get; set; }
        public string RestartLoginUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.RestartLoginUrlLocation? RestartLoginPageLocation { get; set; }
        public string CopyrightInformation { get; set; }
        public string EulaUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.DisclaimerLocation? DisclaimerPageLocation { get; set; }
        public Smtp Smtp { get; set; }
        public Email Email { get; set; }
    }
}
