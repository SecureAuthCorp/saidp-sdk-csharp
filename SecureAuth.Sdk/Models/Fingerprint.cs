using System.Runtime.Serialization;

namespace SecureAuth.Sdk.Models
{
    [DataContract(Name = "fingerprint")]
    public class Fingerprint
    {
        [DataMember(Name = "fonts", EmitDefaultValue = false)]
        public string Fonts { get; set; }

        [DataMember(Name = "plugins", EmitDefaultValue = false)]
        public string Plugins { get; set; }

        [DataMember(Name = "timezone", EmitDefaultValue = false)]
        public string TimeZone { get; set; }

        [DataMember(Name = "video", EmitDefaultValue = false)]
        public string Video { get; set; }

        [DataMember(Name = "local_storage", EmitDefaultValue = false)]
        public bool LocalStorage { get; set; }

        [DataMember(Name = "session_storage", EmitDefaultValue = false)]
        public bool SessionStorage { get; set; }

        [DataMember(Name = "ie_user_data", EmitDefaultValue = false)]
        public bool IeUserDate { get; set; }

        [DataMember(Name = "accept", EmitDefaultValue = false)]
        public string Accept { get; set; }

        [DataMember(Name = "accept_charset", EmitDefaultValue = false)]
        public string AcceptCharSet { get; set; }

        [DataMember(Name = "accept_encoding", EmitDefaultValue = false)]
        public string AcceptEncoding { get; set; }

        [DataMember(Name = "accept_language", EmitDefaultValue = false)]
        public string AcceptLanguage { get; set; }

        [DataMember(Name = "user_agent", EmitDefaultValue = false)]
        public string UserAgent { get; set; }

        [DataMember(Name = "cookie_enabled", EmitDefaultValue = false)]
        public bool CookieEnabled { get; set; }
    }
}