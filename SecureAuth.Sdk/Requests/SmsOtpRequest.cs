<<<<<<< HEAD
﻿using System.Runtime.Serialization;
=======
﻿    using System.Runtime.Serialization;
>>>>>>> 767840d... updates for .net core and language helper function

namespace SecureAuth.Sdk
{
    [DataContract]
    public class SmsOtpRequest : BaseRequest
    {
        [DataMember(Name = "factor_id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

<<<<<<< HEAD
=======
        [DataMember(Name = "evaluate_number", EmitDefaultValue = false)]
        public string EvaluateNumber { get; set; }

>>>>>>> 767840d... updates for .net core and language helper function
        public SmsOtpRequest()
        {
            this.Type = "sms";
        }

        public SmsOtpRequest(string userId, string factorId)
            : base(userId, "sms")
        {
<<<<<<< HEAD
            this.FactorId = factorId;
=======
            this.FactorId = factorId;            
        }

        public SmsOtpRequest(string userId, string factorId, bool evaluateNumber)
            : base(userId, "sms")
        {
            this.FactorId = factorId;
            this.EvaluateNumber = evaluateNumber.ToString();
        }

        public SmsOtpRequest(string userId, string factorId, bool evaluateNumber, string domain = "")
            : base(userId, "sms", domain)
        {
            this.FactorId = factorId;
            this.EvaluateNumber = evaluateNumber.ToString();
>>>>>>> 767840d... updates for .net core and language helper function
        }
    }
}