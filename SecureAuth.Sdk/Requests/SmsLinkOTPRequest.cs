using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class SmsLinkOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        [DataMember(Name = "evaluate_number", EmitDefaultValue = false)]
        public string EvaluateNumber { get; set; }

        public SmsLinkOtpRequest()
        {
            this.Type = "sms_link";
        }

        public SmsLinkOtpRequest(string userId, string factorId)
            : base(userId, "sms_link")
        {
            this.FactorId = factorId;
        }

        public SmsLinkOtpRequest(string userId, string factorId, bool evaluateNumber)
            : base(userId, "sms_link")
        {
            this.FactorId = factorId;
            this.EvaluateNumber = evaluateNumber.ToString();
        }

        public SmsLinkOtpRequest(string userId, string factorId, bool evaluateNumber, string domain = "")
            : base(userId, "sms_link", domain)
        {
            this.FactorId = factorId;
            this.EvaluateNumber = evaluateNumber.ToString();
        }
    }
}