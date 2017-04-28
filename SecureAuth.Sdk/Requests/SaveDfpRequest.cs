using System.Runtime.Serialization;
using SecureAuth.Sdk.Models;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class SaveDfpRequest : BaseRequest
    {
        [DataMember(Name = "fingerprint_id", EmitDefaultValue = false)]
        public string FingerprintId { get; set; }

        [DataMember(Name = "host_address", EmitDefaultValue = false)]
        public string HostAddress { get; set; }

        [DataMember(Name = "fingerprint", EmitDefaultValue = false)]
        public Fingerprint Fingerprint { get; set; }

        public SaveDfpRequest() { }

        public SaveDfpRequest(string fpJson)
        {
            this.Fingerprint = JsonSerializer.Deserialize<ValidateDfpRequest>(fpJson).Fingerprint;
        }
    }
}
