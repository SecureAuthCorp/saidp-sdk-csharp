using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class UserStatusResponse : BaseResponse
    {
        [DataMember(Name = "user_id", EmitDefaultValue = false)]
        public string UserId { get; set; }


        public bool NotFound()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "not_found"));
        }

        public bool InvalidGroup()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "invalid_group"));
        }

        public bool Disabled()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "disabled"));
        }

        public bool Lockout()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "lock_out"));
        }

        public bool PasswordExpired()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "password_expired"));
        }

        public bool ChangePassword()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "change_password"));
        }

        public bool AccountExpired()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "account_expired"));
        }
    }
}