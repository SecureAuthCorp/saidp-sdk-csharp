using System.Runtime.Serialization;
using SecureAuth.Sdk.Models;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class PushAcceptSymbolRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        [DataMember(Name = "push_accept_details", EmitDefaultValue = false)]
        public PushAcceptDetails PushAcceptDetails { get; set; }

        public PushAcceptSymbolRequest()
        {
            this.Type = "push_accept_symbol";
        }

        public PushAcceptSymbolRequest(string userId, string factorId)
            : base(userId, "push_accept_symbol")
        {
            this.FactorId = factorId;
        }

        public PushAcceptSymbolRequest(string userId, string factorId, string domain = "")
            : base(userId, "push_accept_symbol", domain)
        {
            this.FactorId = factorId;
        }
    }
}