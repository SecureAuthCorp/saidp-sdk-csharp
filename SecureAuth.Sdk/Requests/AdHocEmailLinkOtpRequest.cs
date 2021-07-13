using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class AdHocEmailLinkOtpRequest : BaseRequest
    {
        public AdHocEmailLinkOtpRequest()
        {
            this.Type = "email_link";
        }

        public AdHocEmailLinkOtpRequest(string userId, string emailAddress)
            : base(userId, "email_link")
        {
            Token = emailAddress;
        }

        public AdHocEmailLinkOtpRequest(string userId, string emailAddress, string domain = "")
            : base(userId, "email_link", domain)
        {
            Token = emailAddress;
        }

        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
}
