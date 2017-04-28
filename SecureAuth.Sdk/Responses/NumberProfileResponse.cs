using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class NumberProfileResponse : BaseResponse
    {
        [DataMember(Name = "numberProfileResult", EmitDefaultValue = false)]
        public NumberProfileResult NumberProfileResult { get; set; }

        public override bool IsSucess()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "verified"));
        }
    }
}
