using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class BaseResponse
    {
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        [IgnoreDataMember]
        public string RawJson { get; set; }

        [IgnoreDataMember]
        public string RawRequestJson { get; set; }

        [IgnoreDataMember]
        public HttpStatusCode StatusCode { get; set; }

        public virtual bool IsSucess()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "valid"));
        }
    }
}