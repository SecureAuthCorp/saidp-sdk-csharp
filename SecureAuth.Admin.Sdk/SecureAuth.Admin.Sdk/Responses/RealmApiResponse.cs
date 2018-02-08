using System.Net;


namespace SecureAuth.Admin.Sdk
{
    public class RealmApiResponse : BaseResponse
    {
        public Models.ApiSetting ApiSetting { get; set; }

        public override bool IsSucess()
        {
            return ((this.StatusCode == HttpStatusCode.OK));
        }
    }
}
