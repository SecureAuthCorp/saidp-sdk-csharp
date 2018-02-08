using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class WsFedSamlAssertion
    {
        public string WsFedReplyTo_SamlTargetUrl { get; set; }
        public string SamlConsumerUrl { get; set; }
        public string Issuer { get; set; }
        public string SamlRecipient { get; set; }
        public string SamlAudience { get; set; }
        public string SpStartUrl { get; set; }
        public string WsFedVersion { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthWsFedSamlSigningAlgorithm? WsFedSigningAlgorithm { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthWsFedSamlSigningAlgorithm? SamlSigningAlgorithm { get; set; }
        public int? SamlOffsetMinutes { get; set; }
        public int? SamlValidHours { get; set; }
        public bool? AppendHttpsToSamlTargetUrl { get; set; }
        public bool? GenerateUniqueAssertionId { get; set; }
        public bool? SignSamlAssertion { get; set; }
        public bool? SignSamlMessage { get; set; }
        public bool? EncryptSamlAssertion { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthSamlEncryptionMethod? SamlDataEncryptionMethod { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthSamlEncryptionMethod? SamlKeyEncryptionMethod { get; set; }
        public string EncryptionCertificate { get; set; }
        public string AcsSamlRequestCertificate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthAuthenticationMethod? AuthenticationMethod { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthConfirmationMethod? ConfirmationMethod { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PostAuthSamlAuthenticationContextClass? AuthenticationContextClass { get; set; }
        public bool? IncludeSamlConditions { get; set; }
        public bool? SamlResponseInResponseTo { get; set; }
        public bool? SubjectConfirmationDataNotBefore { get; set; }
        public string SigningCertSerialNumber { get; set; }
    }
}
