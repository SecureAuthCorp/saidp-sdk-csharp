using System.Runtime.Serialization;

namespace SecureAuth.Sdk.Models
{
    [DataContract]
    public class FingerprintWrapper
    {
        [DataMember(Name = "fingerprint", EmitDefaultValue = false)]
        public Fingerprint Fingerprint { get; set; }
    }
}
