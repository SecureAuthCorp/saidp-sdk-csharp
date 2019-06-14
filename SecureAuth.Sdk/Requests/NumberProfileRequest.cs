using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class NumberProfileRequest : BaseRequest
    {
        [DataMember(Name ="phone_number", EmitDefaultValue = false)]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "ported_status", EmitDefaultValue = false)]
        public string PortedStatus { get; set; }

        [DataMember(Name = "carrierInfo", EmitDefaultValue = false)]
        public CarrierInfo CarrierInfo { get; set; }

        public NumberProfileRequest()
        {
        }
        public NumberProfileRequest(string userId, string phoneNumber)
        {
            this.UserId = userId;
            this.PhoneNumber = phoneNumber;
        }
       
    }

    [DataContract(Name ="carrierInfo")]
    public class CarrierInfo
    {
        [DataMember(Name = "carrierCode", EmitDefaultValue = false)]
        public string CarrierCode { get; set; }

        [DataMember(Name = "carrier", EmitDefaultValue = false)]
        public string Carrier { get; set; }

        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string CountryCode { get; set; }

        [DataMember(Name = "networkType", EmitDefaultValue = false)]
        public string NetworkType { get; set; }
    }
}
