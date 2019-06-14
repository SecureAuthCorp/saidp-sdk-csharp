using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class AdaptiveAuthRequest : BaseRequest
    {
        [DataMember(Name = "parameters", EmitDefaultValue = false)]
        public Dictionary<string, string> Parameters { get; set; }

        public AdaptiveAuthRequest()
        {
        }

        public AdaptiveAuthRequest(string userId, Dictionary<string, string> parameters)
            : base(userId, "")
        {
            this.Parameters = parameters;
        }
<<<<<<< HEAD
=======

        public AdaptiveAuthRequest(string userId, Dictionary<string, string> parameters, string domain = "")
            : base(userId, "", domain)
        {
            this.Parameters = parameters;
        }
>>>>>>> 767840d... updates for .net core and language helper function
    }
}
