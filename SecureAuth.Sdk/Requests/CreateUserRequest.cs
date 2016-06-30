using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class CreateUserRequest : BaseRequest
    {
        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "properties")]
        public IDictionary<string, string> Properties { get; set; }

        [DataMember(Name = "knowledgeBase")]
        public IDictionary<string, KbProperty> KnowledgeBase { get; set; }

        public CreateUserRequest()
        {
            Properties = new Dictionary<string, string>();
            KnowledgeBase = new Dictionary<string, KbProperty>();
        }
    }
}
