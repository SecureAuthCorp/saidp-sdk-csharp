using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract(Name = "factor_description")]
    public class FactorDescription
    {
        [DataMember(Name = "geoContinent", EmitDefaultValue = false)]
        public string GeoContinent { get; set; }

        [DataMember(Name = "geoCountry", EmitDefaultValue = false)]
        public string GeoCountry { get; set; }

        [DataMember(Name = "geoCountryCode", EmitDefaultValue = false)]
        public string GeoCountryCode { get; set; }

        [DataMember(Name = "geoCountryCF", EmitDefaultValue = false)]
        public string GeoCountryCF { get; set; }

        [DataMember(Name = "geoRegion", EmitDefaultValue = false)]
        public string GeoRegion { get; set; }

        [DataMember(Name = "geoState", EmitDefaultValue = false)]
        public string GeoState { get; set; }

        [DataMember(Name = "geoStateCode", EmitDefaultValue = false)]
        public string GeoStateCode { get; set; }

        [DataMember(Name = "geoStateCF", EmitDefaultValue = false)]
        public string GeoStateCF { get; set; }

        [DataMember(Name = "geoCity", EmitDefaultValue = false)]
        public string GeoCity { get; set; }

        [DataMember(Name = "geoCityCF", EmitDefaultValue = false)]
        public string GeoCityCF { get; set; }

        [DataMember(Name = "geoPostalCode", EmitDefaultValue = false)]
        public string GeoPostalCode { get; set; }

        [DataMember(Name = "geoAreaCode", EmitDefaultValue = false)]
        public string GeoAreaCode { get; set; }

        [DataMember(Name = "geoTimeZone", EmitDefaultValue = false)]
        public string GeoTimeZone { get; set; }

        [DataMember(Name = "geoLatitude", EmitDefaultValue = false)]
        public string GeoLatitude { get; set; }

        [DataMember(Name = "geoLongitude", EmitDefaultValue = false)]
        public string GeoLongitude { get; set; }

        [DataMember(Name = "dma", EmitDefaultValue = false)]
        public string Dma { get; set; }

        [DataMember(Name = "msa", EmitDefaultValue = false)]
        public string Msa { get; set; }

        [DataMember(Name = "connectionType", EmitDefaultValue = false)]
        public string ConnectionType { get; set; }

        [DataMember(Name = "lineSpeed", EmitDefaultValue = false)]
        public string LineSpeed { get; set; }

        [DataMember(Name = "ipRoutingType", EmitDefaultValue = false)]
        public string IpRoutingType { get; set; }

        [DataMember(Name = "geoAsn", EmitDefaultValue = false)]
        public string GeoAsn { get; set; }

        [DataMember(Name = "sld", EmitDefaultValue = false)]
        public string Sld { get; set; }

        [DataMember(Name = "tld", EmitDefaultValue = false)]
        public string Tld { get; set; }

        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public string Organization { get; set; }

        [DataMember(Name = "carrier", EmitDefaultValue = false)]
        public string Carrier { get; set; }

        [DataMember(Name = "anonymizer_status", EmitDefaultValue = false)]
        public string AnonymizerStatus { get; set; }

        [DataMember(Name = "proxyLevel", EmitDefaultValue = false)]
        public string ProxyLevel { get; set; }

        [DataMember(Name = "proxyType", EmitDefaultValue = false)]
        public string ProxyType { get; set; }

        [DataMember(Name = "proxyLastDetected", EmitDefaultValue = false)]
        public string ProxyLastDetected { get; set; }

        [DataMember(Name = "hostingFacility", EmitDefaultValue = false)]
        public string HostingFacility { get; set; }

        [DataMember(Name = "threatType", EmitDefaultValue = false)]
        public string ThreatType { get; set; }

        [DataMember(Name = "threatCategory", EmitDefaultValue = false)]
        public string ThreatCategory { get; set; }
    }
}
