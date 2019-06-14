﻿using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class PushOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        public PushOtpRequest()
        {
            this.Type = "push";
        }

        public PushOtpRequest(string userId, string factorId)
            : base(userId, "push")
        {
            this.FactorId = factorId;
        }
<<<<<<< HEAD
=======

        public PushOtpRequest(string userId, string factorId, string domain = "")
            : base(userId, "push", domain)
        {
            this.FactorId = factorId;
        }
>>>>>>> 767840d... updates for .net core and language helper function
    }
}