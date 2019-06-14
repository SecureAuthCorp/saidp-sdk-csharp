using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class AdHocPhonecallOtpRequest : BaseRequest
    {
        public AdHocPhonecallOtpRequest()
        {
            this.Type = "call";
        }

        public AdHocPhonecallOtpRequest(string userId, string phoneNumber)
            : base(userId, "call")
        {
            Token = phoneNumber;
        }

        public AdHocPhonecallOtpRequest(string userId, string phoneNumber, string domain = "")
            : base(userId, "call", domain)
        {
            Token = phoneNumber;
        }

        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "evaluate_number")]
        public bool EvaluateNumber { get; set; }
    }
}
