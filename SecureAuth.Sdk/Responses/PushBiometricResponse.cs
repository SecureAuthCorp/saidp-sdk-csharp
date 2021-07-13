using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class PushBiometricResponse : BaseResponse
    {
        [DataMember(Name = "user_id", EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(Name = "reference_id", EmitDefaultValue = false)]
        public string ReferenceId { get; set; }
    }
}