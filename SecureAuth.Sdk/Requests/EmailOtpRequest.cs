using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class EmailOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        public EmailOtpRequest()
        {
            this.Type = "email";
        }

        public EmailOtpRequest(string userId, string factorId)
            : base(userId, "email")
        {
            this.FactorId = factorId;
        }
    }
}