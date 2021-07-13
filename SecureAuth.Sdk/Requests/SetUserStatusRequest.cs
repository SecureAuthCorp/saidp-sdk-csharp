using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class SetUserStatusRequest: BaseRequest
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        public SetUserStatusRequest(string status)
        {
            Status = status;
        }
    }
}
