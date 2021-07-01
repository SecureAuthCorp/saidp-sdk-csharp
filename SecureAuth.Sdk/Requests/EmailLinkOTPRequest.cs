using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class EmailLinkOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        public EmailLinkOtpRequest()
        {
            this.Type = "email_link";
        }

        public EmailLinkOtpRequest(string userId, string factorId)
            : base(userId, "email_link")
        {
            this.FactorId = factorId;
        }

        public EmailLinkOtpRequest(string userId, string factorId, string domain = "")
            : base(userId, "email_link", domain)
        {
            this.FactorId = factorId;
        }
    }
}