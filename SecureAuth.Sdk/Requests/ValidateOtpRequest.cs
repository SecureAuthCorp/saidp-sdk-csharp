using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ValidateOtpRequest : BaseRequest
    {
        [DataMember(Name = "otp", EmitDefaultValue = false)]
        public string Otp { get; set; }

        public ValidateOtpRequest() { }
        public ValidateOtpRequest(string userId, string otp)
        {
            this.UserId = userId;
            this.Otp = otp;
        }
    }
}
