using System.Runtime.Serialization;

namespace SecureAuth.Sdk.Models
{
    [DataContract(Name = "uaDevice")]
    public class UaDevice
    {
        [DataMember(Name = "model", EmitDefaultValue = false)]
        public string Model { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "vendor", EmitDefaultValue = false)]
        public string Vendor { get; set; }
    }
}
