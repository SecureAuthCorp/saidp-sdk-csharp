using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ValidatePinRequest : BaseRequest
    {
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string Token { get; set; }

        public ValidatePinRequest()
        {
            this.Type = "pin";
        }

        public ValidatePinRequest(string userId, string token)
            : base(userId, "pin")
        {
            this.Token = token;
        }
    }
}