using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract(Name = "geoloc")]
    public class GeoLocation
    {
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        [DataMember(Name = "country_code", EmitDefaultValue = false)]
        public string CountryCode { get; set; }
        
        [DataMember(Name = "region", EmitDefaultValue = false)]
        public string Region { get; set; }

        [DataMember(Name = "region_code", EmitDefaultValue = false)]
        public string RegionCode { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "latitude", EmitDefaultValue = false)]
        public double? Latitude { get; set; }

        [DataMember(Name = "longitude", EmitDefaultValue = false)]
        public double? Longitude { get; set; }

        [DataMember(Name = "internet_service_provider", EmitDefaultValue = false)]
        public string InternetServiceProvider { get; set; }

        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public string Organization { get; set; }
    }
}