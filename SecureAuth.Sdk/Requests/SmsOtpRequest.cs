using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class SmsOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        public SmsOtpRequest()
        {
            this.Type = "sms";
        }

        public SmsOtpRequest(string userId, string factorId)
            : base(userId, "sms")
        {
            this.FactorId = factorId;
        }
    }
}