﻿using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class IpRiskRequest : BaseRequest
    {
        [DataMember(Name = "ip_address", EmitDefaultValue = false)]
        public string IpAddress { get; set; }

        public IpRiskRequest()
        {
            this.Type = "risk";
        }

        public IpRiskRequest(string userId, string ipAddress)
            : base(userId, "risk")
        {
            this.IpAddress = ipAddress;
        }
<<<<<<< HEAD
=======

        public IpRiskRequest(string userId, string ipAddress, string domain = "")
            : base(userId, "risk", domain)
        {
            this.IpAddress = ipAddress;
        }
>>>>>>> 767840d... updates for .net core and language helper function
    }
}
