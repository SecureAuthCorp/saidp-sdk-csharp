using System.Net;
using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk
{
    public class PhoneCarrierResponse : BaseResponse
    {
        public List<Models.CarrierCountry> CarrierCountries { get; set; }

        public override bool IsSucess()
        {
            return ((this.StatusCode == HttpStatusCode.OK));
        }
    }
}
