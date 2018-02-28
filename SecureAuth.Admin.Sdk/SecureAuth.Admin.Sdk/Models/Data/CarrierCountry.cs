using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk.Models
{
    public class CarrierCountry
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public List<Carrier> Carriers { get; set; }
    }

    public class Carrier
    {
        public string CarrierName { get; set; }
        public string CarrierCode { get; set; }
    }
}
