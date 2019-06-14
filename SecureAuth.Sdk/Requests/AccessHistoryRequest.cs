using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class AccessHistoryRequest : BaseRequest
    {
        [DataMember(Name = "ip_address", EmitDefaultValue = false)]
        public string IpAddress { get; set; }

        public AccessHistoryRequest()
        {
        }

        public AccessHistoryRequest(string userId, string ipAddress)
            : base(userId, "")
        {
            this.IpAddress = ipAddress;
        }
<<<<<<< HEAD
=======

        public AccessHistoryRequest(string userId, string ipAddress, string domain = "")
            : base(userId, "", domain)
        {
            this.IpAddress = ipAddress;
        }
>>>>>>> 767840d... updates for .net core and language helper function
    }
}
