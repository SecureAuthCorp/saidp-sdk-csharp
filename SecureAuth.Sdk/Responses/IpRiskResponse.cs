using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class IpRiskResponse : BaseResponse
    {
        [DataMember(Name = "ip_evaluation", EmitDefaultValue = false)]
        public IpEvaluation IpEvaluation { get; set; }

        public override bool IsSuccess()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "verified"));
        }
    }
}