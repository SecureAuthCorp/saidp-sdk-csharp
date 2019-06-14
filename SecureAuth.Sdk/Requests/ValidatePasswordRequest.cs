using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ValidatePasswordRequest : BaseRequest
    {
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string Token { get; set; }

        public ValidatePasswordRequest()
        {
            this.Type = "password";
        }

        public ValidatePasswordRequest(string userId, string token)
            : base(userId, "password")
        {
            this.Token = token;
        }
<<<<<<< HEAD
=======

        public ValidatePasswordRequest(string userId, string token, string domain = "")
            : base(userId, "password", domain)
        {
            this.Token = token;
        }
>>>>>>> 767840d... updates for .net core and language helper function
    }
}