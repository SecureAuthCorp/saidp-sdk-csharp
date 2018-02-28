using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class HelpDeskOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        public HelpDeskOtpRequest()
        {
            this.Type = "help_desk";
        }

        public HelpDeskOtpRequest(string userId, string factorId)
            : base(userId, "help_desk")
        {
            this.FactorId = factorId;
        }

        public HelpDeskOtpRequest(string userId, string factorId, string domain = "")
            : base(userId, "help_desk", domain)
        {
            this.FactorId = factorId;
        }
    }
}