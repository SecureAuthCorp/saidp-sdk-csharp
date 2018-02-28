using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class BaseRequest
    {
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        [DataMember(Name = "user_id", EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        public BaseRequest()
        {
        }

        public BaseRequest(string userId, string type, string domain = "")
        {
            this.UserId = userId;
            this.Type = type;
            this.Domain = string.IsNullOrEmpty(Domain) ? string.Empty : Domain;
        }
    }
}