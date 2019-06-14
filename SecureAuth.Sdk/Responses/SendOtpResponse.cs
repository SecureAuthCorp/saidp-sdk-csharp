using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class SendOtpResponse : BaseResponse
    {
        [DataMember(Name = "user_id", EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(Name = "otp", EmitDefaultValue = false)]
        public string OneTimePasscode { get; set; }
    }
}