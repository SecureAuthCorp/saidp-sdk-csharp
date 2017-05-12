using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SecureAuth.Sdk
{
    [DataContract(Name = "numberProfileResult")]
    public class NumberProfileResult
    {
        [DataMember(Name = "providerRequestId", EmitDefaultValue = false)]
        public string ProviderRequestId { get; set; }

        [DataMember(Name = "internationalFormat", EmitDefaultValue = false)]
        public string InternationalFormat { get; set; }

        [DataMember(Name = "nationalFormat", EmitDefaultValue = false)]
        public string NationalFormat { get; set; }

        [DataMember(Name = "countryPrefix", EmitDefaultValue = false)]
        public string CountryPrefix { get; set; }

        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string CountryCode { get; set; }

        [DataMember(Name = "countryCodeISO3", EmitDefaultValue = false)]
        public string CountryCodeISO3 { get; set; }

        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        [DataMember(Name = "portedStatus", EmitDefaultValue = false)]
        public string PortedStatus { get; set; }

        [DataMember(Name = "validNumber", EmitDefaultValue = false)]
        public string ValidNumber { get; set; }

        [DataMember(Name = "reachable", EmitDefaultValue = false)]
        public string Reachable { get; set; }

        [DataMember(Name = "roamingInfo", EmitDefaultValue = false)]
        public string RoamingInfo { get; set; }

        [DataMember(Name = "currentCarrier", EmitDefaultValue = false)]
        public CurrentCarrier CurrentCarrier { get; set; }

        [DataMember(Name = "originalCarrier", EmitDefaultValue = false)]
        public OriginalCarrier OriginalCarrier { get; set; }

        [DataMember(Name = "ipInfo", EmitDefaultValue = false)]
        public string IpInfo { get; set; }

        [DataMember(Name = "ipWarning", EmitDefaultValue = false)]
        public string IpWarning { get; set; }
    }

    [DataContract(Name = "currentCarrier")]
    public class CurrentCarrier
    {
        [DataMember(Name = "carrierCode", EmitDefaultValue = false)]
        public string CarrierCode { get; set; }

        [DataMember(Name = "carrier", EmitDefaultValue = false)]
        public string Carrier { get; set; }

        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string CountryCode { get; set; }

        [DataMember(Name = "networkType", EmitDefaultValue = false)]
        public string NetworkType { get; set; }

        [DataMember(Name = "carrierStatus", EmitDefaultValue = false)]
        public CarrierStatus CarrierStatus { get; set; }
    }

    [DataContract(Name = "originalCarrier")]
    public class OriginalCarrier
    {
        [DataMember(Name = "carrierCode", EmitDefaultValue = false)]
        public string CarrierCode { get; set; }

        [DataMember(Name = "carrier", EmitDefaultValue = false)]
        public string Carrier { get; set; }

        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string CountryCode { get; set; }

        [DataMember(Name = "networkType", EmitDefaultValue = false)]
        public string NetworkType { get; set; }

        [DataMember(Name = "carrierStatus", EmitDefaultValue = false)]
        public CarrierStatus CarrierStatus { get; set; }
    }

    [DataContract(Name = "carrierStatus")]
    public class CarrierStatus
    {
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public IList<string> Reason {get;set;}
    }
}
