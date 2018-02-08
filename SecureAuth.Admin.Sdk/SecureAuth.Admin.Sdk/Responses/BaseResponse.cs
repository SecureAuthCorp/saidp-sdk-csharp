using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Admin.Sdk
{
    [DataContract]
    public class BaseResponse
    {
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

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