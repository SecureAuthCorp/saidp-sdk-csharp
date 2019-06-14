using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class GroupAssociateResponse : BaseResponse
    {
        [DataMember(Name = "failures")]
        public Dictionary<string, List<string>> Failures { get; set; }
    }
}
