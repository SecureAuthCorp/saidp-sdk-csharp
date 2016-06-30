using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ResetPasswordRequest : BaseRequest
    {
        [DataMember(Name = "password")]
        public string NewPassword { get; set; }
    }
}
