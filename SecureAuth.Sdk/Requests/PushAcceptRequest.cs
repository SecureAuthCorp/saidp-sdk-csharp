using System.Runtime.Serialization;
using SecureAuth.Sdk.Models;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class PushAcceptRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        [DataMember(Name = "push_accept_details", EmitDefaultValue = false)]
        public PushAcceptDetails PushAcceptDetails { get; set; }

        public PushAcceptRequest()
        {
            this.Type = "push_accept";
        }

        public PushAcceptRequest(string userId, string factorId)
            : base(userId, "push_accept")
        {
            this.FactorId = factorId;
        }
<<<<<<< HEAD
=======

        public PushAcceptRequest(string userId, string factorId, string domain = "")
            : base(userId, "push_accept", domain)
        {
            this.FactorId = factorId;
        }
>>>>>>> 767840d... updates for .net core and language helper function
    }
}