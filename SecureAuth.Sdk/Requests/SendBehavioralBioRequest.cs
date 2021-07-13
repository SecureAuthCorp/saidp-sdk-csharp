using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk.Requests
{
    public class SendBehavioralBioRequest : BaseRequest
    {
        
        [DataMember(Name = "userAgent", EmitDefaultValue = false)]
        public string UserAgent { get; set; }

        [DataMember(Name = "hostAddress", EmitDefaultValue = false)]
        public string HostAddress { get; set; }

        [DataMember(Name = "domain", EmitDefaultValue = false)]
        public string Domain { get; set; }

        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(Name = "fingerprint", EmitDefaultValue = false)]
        public string BehaviorProfile { get; set; }

        public SendBehavioralBioRequest()
        {
        }

        public SendBehavioralBioRequest(string bbJson)
        {
            this.BehaviorProfile = JsonSerializer.Deserialize<SendBehavioralBioRequest>(bbJson).BehaviorProfile;
        }
    }


}
