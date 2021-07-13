using System.Runtime.Serialization;

namespace SecureAuth.Sdk.Models
{
    [DataContract(Name = "biometricType")]
    public class BiometricType
    {
        [DataMember(Name = "push_accept_details", EmitDefaultValue = false)]
        public PushAcceptDetails PushAcceptDetails { get; set; }
    }
}
