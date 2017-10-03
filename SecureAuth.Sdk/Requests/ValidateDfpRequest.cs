using System.Runtime.Serialization;
using SecureAuth.Sdk.Models;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class ValidateDfpRequest : BaseRequest
    {
        [DataMember(Name = "fingerprint_id", EmitDefaultValue = false)]
        public string FingerprintId { get; set; }

        [DataMember(Name = "host_address", EmitDefaultValue = false)]
        public string HostAddress { get; set; }

        [DataMember(Name = "fingerprint", EmitDefaultValue = false)]
        public FingerprintWrapper Fingerprint { get; set; }

        public ValidateDfpRequest()
        {
        }

        public ValidateDfpRequest(string fpJson)
        {
            this.Fingerprint = JsonSerializer.Deserialize<ValidateDfpRequest>(fpJson).Fingerprint;
        }
    }
}