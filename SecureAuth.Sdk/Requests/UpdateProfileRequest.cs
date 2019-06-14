using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class UpdateUserProfileRequest : BaseRequest
    {
        [DataMember(Name = "properties")]
        public IDictionary<string, string> Properties { get; set; }

        [DataMember(Name = "knowledgeBase")]
        public IDictionary<string, KbProperty> KnowledgeBase { get; set; }

        public UpdateUserProfileRequest()
        {
            Properties = new Dictionary<string, string>();
            KnowledgeBase = new Dictionary<string, KbProperty>();
        }
    }
}
