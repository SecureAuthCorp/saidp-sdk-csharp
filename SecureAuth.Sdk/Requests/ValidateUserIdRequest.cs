using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ValidateUserIdRequest : BaseRequest
    {
        public ValidateUserIdRequest()
        {
            this.Type = "user_id";
        }

        public ValidateUserIdRequest(string userId) : base(userId, "user_id")
        {
        }
<<<<<<< HEAD
=======

        public ValidateUserIdRequest(string userId, string domain = "") : base(userId, "user_id", domain)
        {
        }
>>>>>>> 767840d... updates for .net core and language helper function
    }
}