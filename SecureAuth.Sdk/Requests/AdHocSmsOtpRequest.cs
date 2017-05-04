using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk.Requests
{
    public class AdHocSmsOtpRequest : BaseRequest
    {
        public AdHocSmsOtpRequest()
        {
            this.Type = "sms";
        }

        public AdHocSmsOtpRequest(string userId, string factorId)
            : base(userId, "sms")
        {
        }

        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "evaluate_number")]
        public bool EvaluateNumber { get; set; }
    }
}
