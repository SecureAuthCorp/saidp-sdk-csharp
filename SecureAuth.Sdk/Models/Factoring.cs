using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract(Name = "factoring")]
    public class Factoring
    {
        [DataMember(Name = "latitude", EmitDefaultValue = false)]
        public double? Latitude { get; set; }

        [DataMember(Name = "longitude", EmitDefaultValue = false)]
        public double? Longitude { get; set; }

        [DataMember(Name = "threatType", EmitDefaultValue = false)]
        public int? ThreatType { get; set; }

        [DataMember(Name = "threatCategory", EmitDefaultValue = false)]
        public int? ThreatCategory { get; set; }
    }
}