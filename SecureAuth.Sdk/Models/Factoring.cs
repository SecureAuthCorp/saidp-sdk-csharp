using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract(Name = "factoring")]
    public class Factoring
    {
<<<<<<< HEAD
        [DataMember(Name = "country_risk_factor", EmitDefaultValue = false)]
        public double? CountryRiskFactor { get; set; }
        
        [DataMember(Name = "region_risk_factor", EmitDefaultValue = false)]
        public double? RegionRiskFactor { get; set; }
        
        [DataMember(Name = "ip_resolve_factor", EmitDefaultValue = false)]
        public double? IpResolveFactor { get; set; }
        
        [DataMember(Name = "asn_record_factor", EmitDefaultValue = false)]
        public double? AsnRecordFactor { get; set; }
        
        [DataMember(Name = "asn_threat_factor", EmitDefaultValue = false)]
        public double? AsnThreatFactor { get; set; }
        
        [DataMember(Name = "bgp_delegation_factor", EmitDefaultValue = false)]
        public double? BgpDelegationFactor { get; set; }
        
        [DataMember(Name = "iana_allocation_factor", EmitDefaultValue = false)]
        public double? IanaAllocationFactor { get; set; }
        
        [DataMember(Name = "ipviking_personal_factor", EmitDefaultValue = false)]
        public double? IpvikingPersonalFactor { get; set; }
        
        [DataMember(Name = "ipviking_category_factor", EmitDefaultValue = false)]
        public double? IpvikingCategoryFactor { get; set; }
        
        [DataMember(Name = "ipviking_geofilter_factor", EmitDefaultValue = false)]
        public double? IpvikingGeofilterFactor { get; set; }
        
        [DataMember(Name = "ipviking_geofilter_rule", EmitDefaultValue = false)]
        public double? IpvikingGeofilterRule { get; set; }
        
        [DataMember(Name = "data_age_factor", EmitDefaultValue = false)]
        public double? DataAgeFactor { get; set; }
        
        [DataMember(Name = "geomatch_distance", EmitDefaultValue = false)]
        public double? GeomatchDistance { get; set; }
        
        [DataMember(Name = "geomatch_factor", EmitDefaultValue = false)]
        public double? GeomatchFactor { get; set; }
        
        [DataMember(Name = "search_volume_factor", EmitDefaultValue = false)]
        public double? SearchVolumeFactor { get; set; }
=======
        [DataMember(Name = "latitude", EmitDefaultValue = false)]
        public double? Latitude { get; set; }

        [DataMember(Name = "longitude", EmitDefaultValue = false)]
        public double? Longitude { get; set; }

        [DataMember(Name = "threatType", EmitDefaultValue = false)]
        public int? ThreatType { get; set; }

        [DataMember(Name = "threatCategory", EmitDefaultValue = false)]
        public int? ThreatCategory { get; set; }
>>>>>>> 767840d... updates for .net core and language helper function
    }
}