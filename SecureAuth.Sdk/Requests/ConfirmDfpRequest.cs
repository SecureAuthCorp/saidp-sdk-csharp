using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ConfirmDfpRequest : BaseRequest
    {
        [DataMember(Name = "fingerprint_id", EmitDefaultValue = false)]
        public string FingerprintId { get; set; }
    }
}