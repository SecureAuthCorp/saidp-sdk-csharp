using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class BaseRequest
    {
        [DataMember(Name = "user_id", EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        public BaseRequest()
        {
        }

        public BaseRequest(string userId, string type)
        {
            this.UserId = userId;
            this.Type = type;
        }
    }
}