using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class AdHocSmsLinkOtpRequest : BaseRequest
    {
        public AdHocSmsLinkOtpRequest()
        {
            this.Type = "sms_link";
        }

        public AdHocSmsLinkOtpRequest(string userId, string phoneNumber)
            : base(userId, "sms_link")
        {
            Token = phoneNumber;
        }

        public AdHocSmsLinkOtpRequest(string userId, string phoneNumber, string domain = "")
            : base(userId, "sms_link", domain)
        {
            Token = phoneNumber;
        }

        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "evaluate_number")]
        public bool EvaluateNumber { get; set; }
    }
}
