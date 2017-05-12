using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract(Name = "ip_evaluation")]
    public class IpEvaluation
    {
        [DataMember(Name = "method", EmitDefaultValue = false)]
        public string Method { get; set; }
        
        [DataMember(Name = "ip", EmitDefaultValue = false)]
        public string Ip { get; set; }
        
        [DataMember(Name = "risk_factor", EmitDefaultValue = false)]
        public int? RiskFactor { get; set; }
        
        [DataMember(Name = "risk_color", EmitDefaultValue = false)]
        public string RiskColor { get; set; }
        
        [DataMember(Name = "risk_desc", EmitDefaultValue = false)]
        public string RiskDesc { get; set; }

        [DataMember(Name = "geoloc", EmitDefaultValue = false)]
        public GeoLocation GeoLocation { get; set; }

        [DataMember(Name = "factoring", EmitDefaultValue = false)]
        public Factoring Factoring { get; set; }

        [DataMember(Name = "factor_description", EmitDefaultValue = false)]
        public FactorDescription FactorDesctiption { get; set; }
    }
}