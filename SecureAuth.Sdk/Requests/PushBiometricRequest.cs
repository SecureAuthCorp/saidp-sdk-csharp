using System.Runtime.Serialization;
using SecureAuth.Sdk.Models;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class PushBiometricRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        [DataMember(Name = "biometricType")]
        public BiometricType BiometricType { get; set; }

        public PushBiometricRequest()
        {
            this.Type = "push_accept_biometric";
        }

        public PushBiometricRequest(string userId, string factorId, BiometricType biometricType)
            : base(userId, "push_accept_biometric")
        {
            this.FactorId = factorId;
            this.BiometricType = biometricType;
        }

        public PushBiometricRequest(string userId, string factorId, BiometricType biometricType, string domain = "")
            : base(userId, "push_accept_biometric", domain)
        {
            this.FactorId = factorId;
            this.BiometricType = biometricType;
        }
    }
}