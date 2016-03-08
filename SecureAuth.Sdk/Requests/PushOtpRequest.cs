using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class PushOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        public PushOtpRequest()
        {
            this.Type = "push";
        }

        public PushOtpRequest(string userId, string factorId)
            : base(userId, "push")
        {
            this.FactorId = factorId;
        }
    }
}