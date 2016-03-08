using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class MultiFactorOption
    {
        [DataMember(Name = "type")]
        public string FactorType { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string FactorId { get; set; }

        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string FactorValue { get; set; }

        [DataMember(Name = "capabilities", EmitDefaultValue = false)]
        public List<string> Capabilities { get; set; }
    }
}
