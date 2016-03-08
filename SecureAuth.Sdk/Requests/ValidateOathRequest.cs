using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ValidateOathRequest : BaseRequest
    {
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string Token { get; set; }

        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        public ValidateOathRequest()
        {
            this.Type = "oath";
        }

        public ValidateOathRequest(string userId, string token, string factorId)
            : base(userId, "oath")
        {
            this.Token = token;
            this.FactorId = factorId;
        }
    }
}