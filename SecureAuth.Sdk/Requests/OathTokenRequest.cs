using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class OathTokenRequest : BaseRequest
    {
        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string Token { get; set; }

        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }        

        public OathTokenRequest(string domain, string userId, string password, string token, string factorId)
            : base(userId, "oath", domain)
        {
            this.Password = password;
            this.Token = token;
            this.FactorId = factorId;
        }
    }
}