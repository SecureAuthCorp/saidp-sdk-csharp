using System.Runtime.Serialization;

namespace SecureAuth.Sdk.Models
{
    [DataContract(Name = "touchSupport")]
    public class TouchSupport
    {
        [DataMember(Name = "maxTouchPoints", EmitDefaultValue = false)]
        public int MaxTouchPoints { get; set; }

        [DataMember(Name = "touchEvent", EmitDefaultValue = false)]
        public bool TouchEvent { get; set; }

        [DataMember(Name = "touchStart", EmitDefaultValue = false)]
        public bool TouchStart { get; set; }
    }
}
