using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class SmsOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        [DataMember(Name = "evaluate_number", EmitDefaultValue = false)]
        public string EvaluateNumber { get; set; }

        public SmsOtpRequest()
        {
            this.Type = "sms";
        }

        public SmsOtpRequest(string userId, string factorId, bool evaluateNumber)
            : base(userId, "sms")
        {
            this.FactorId = factorId;
            this.EvaluateNumber = evaluateNumber.ToString();
        }
    }
}