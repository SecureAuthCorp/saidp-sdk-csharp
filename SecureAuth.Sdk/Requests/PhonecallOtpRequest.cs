using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class PhonecallOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }


        [DataMember(Name = "evaluate_number", EmitDefaultValue = false)]
        public string EvaluateNumber { get; set; }

        public PhonecallOtpRequest()
        {
            this.Type = "call";
        }

        public PhonecallOtpRequest(string userId, string factorId)
            : base(userId, "call")
        {
            this.FactorId = factorId;            
        }

        public PhonecallOtpRequest(string userId, string factorId, bool evaluateNumber)
            : base(userId, "call")
        {
            this.FactorId = factorId;
            this.EvaluateNumber = evaluateNumber.ToString();
        }

        public PhonecallOtpRequest(string userId, string factorId, bool evaluateNumber, string domain = "")
            : base(userId, "call", domain)
        {
            this.FactorId = factorId;
            this.EvaluateNumber = evaluateNumber.ToString();
        }
    }
}