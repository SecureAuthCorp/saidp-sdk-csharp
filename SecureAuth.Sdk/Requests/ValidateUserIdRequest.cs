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

        public ValidateUserIdRequest(string userId, string domain = "") : base(userId, "user_id", domain)
        {
        }
    }
}