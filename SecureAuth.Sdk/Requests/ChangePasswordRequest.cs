using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ChangePasswordRequest : BaseRequest
    {
        [DataMember(Name = "currentPassword")]
        public string CurrentPassword { get; set; }

        [DataMember(Name = "newPassword")]
        public string NewPassword { get; set; }
    }
}
