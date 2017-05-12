using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class AdHocOtpRequest : BaseRequest
    {
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string Token { get; set; }

        [DataMember(Name = "evaluate_number", EmitDefaultValue = false)]
        public string EvaluateNumber { get; set; }

        public AdHocOtpRequest() { }

        public AdHocOtpRequest(string userId, string type, string token, bool evaluateNumber)
        {
            this.UserId = userId;
            this.Token = token;
            this.Type = type;
            this.EvaluateNumber = evaluateNumber.ToString();
        }
    }
}
