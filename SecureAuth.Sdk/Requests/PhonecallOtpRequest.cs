using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class PhonecallOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        public PhonecallOtpRequest()
        {
            this.Type = "call";
        }

        public PhonecallOtpRequest(string userId, string factorId)
            : base(userId, "call")
        {
            this.FactorId = factorId;
        }
    }
}