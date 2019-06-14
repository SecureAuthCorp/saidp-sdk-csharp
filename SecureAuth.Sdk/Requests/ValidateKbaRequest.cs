using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ValidateKbaRequest : BaseRequest
    {
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string Token { get; set; }

        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        public ValidateKbaRequest()
        {
            this.Type = "kba";
        }

        public ValidateKbaRequest(string userId, string token, string factorId)
            : base(userId, "kba")
        {
            this.Token = token;
            this.FactorId = factorId;
        }
<<<<<<< HEAD
=======

        public ValidateKbaRequest(string userId, string token, string factorId, string domain = "")
            : base(userId, "kba", domain)
        {
            this.Token = token;
            this.FactorId = factorId;
        }
>>>>>>> 767840d... updates for .net core and language helper function
    }
}