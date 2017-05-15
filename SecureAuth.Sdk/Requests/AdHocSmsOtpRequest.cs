using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class AdHocSmsOtpRequest : BaseRequest
    {
        public AdHocSmsOtpRequest()
        {
            this.Type = "sms";
        }

        public AdHocSmsOtpRequest(string userId, string phoneNumber)
            : base(userId, "sms")
        {
            Token = phoneNumber;
        }

        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "evaluate_number")]
        public bool EvaluateNumber { get; set; }
    }
}
