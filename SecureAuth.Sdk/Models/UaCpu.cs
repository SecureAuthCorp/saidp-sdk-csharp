using System.Runtime.Serialization;

namespace SecureAuth.Sdk.Models
{
    [DataContract(Name = "uaCPU")]
    public class UaCpu
    {
        [DataMember(Name = "architecture", EmitDefaultValue = false)]
        public string Architecture { get; set; }
    }
}
