using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class GetUserProfileResponse : BaseResponse
    {
        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        [DataMember(Name = "properties")]
        public IDictionary<string, UserProfileProperty> Properties { get; set; }

        [DataMember(Name = "knowledgeBase")]
        public IDictionary<string, KbProperty> KnowledgeBase { get; set; }

        [DataMember(Name = "groups")]
        public IList<string> Groups { get; set; }

        [DataMember(Name = "accessHistories")]
        public IList<AccessHistory> AccessHistories { get; set; }

        public override bool IsSuccess()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "found"));
        }
    }
}
