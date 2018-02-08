namespace SecureAuth.Admin.Sdk
{
    public class AdaptiveAuthRequestV2 : BaseRequest
    {
        public Models.v2.AdaptiveAuthentication AdaptiveAuth { get; set; }

        public AdaptiveAuthRequestV2()
        {
            AdaptiveAuth = new Models.v2.AdaptiveAuthentication();
        }
    }
}
