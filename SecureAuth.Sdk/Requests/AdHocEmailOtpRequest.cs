using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class AdHocEmailOtpRequest : BaseRequest
    {
        public AdHocEmailOtpRequest()
        {
            this.Type = "email";
        }

        public AdHocEmailOtpRequest(string userId, string emailAddress)
            : base(userId, "email")
        {
            Token = emailAddress;
        }

        public AdHocEmailOtpRequest(string userId, string emailAddress, string domain = "")
            : base(userId, "email", domain)
        {
            Token = emailAddress;
        }

        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
}
