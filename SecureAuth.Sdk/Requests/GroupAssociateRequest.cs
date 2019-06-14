using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class GroupAssociateRequest : BaseRequest
    {
        [DataMember(Name = "groupNames", EmitDefaultValue = false)]
        public List<string> GroupNames { get; set; }

        [DataMember(Name = "userIds", EmitDefaultValue = false)]
        public List<string> UserIds { get; set; }

        public GroupAssociateRequest()
        {
            GroupNames = new List<string>();
            UserIds = new List<string>();
        }
    }
}
