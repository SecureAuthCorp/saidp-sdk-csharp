using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ThrottleResponse : BaseResponse
    {
        [DataMember(Name = "count", EmitDefaultValue = false)]
        public int? Count { get; set; }
    }
}
