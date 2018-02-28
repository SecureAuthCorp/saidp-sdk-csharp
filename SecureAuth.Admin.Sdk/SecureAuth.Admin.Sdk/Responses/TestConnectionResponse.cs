using System.Net;
using System.Collections.Generic;

namespace SecureAuth.Admin.Sdk
{
    public class TestConnectionResponse : BaseResponse
    {
        public bool Result { get; set; }

        public override bool IsSucess()
        {
            return ((this.StatusCode == HttpStatusCode.OK));
        }
    }
}
