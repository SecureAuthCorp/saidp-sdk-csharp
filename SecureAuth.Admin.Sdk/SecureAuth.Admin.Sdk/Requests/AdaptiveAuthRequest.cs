namespace SecureAuth.Admin.Sdk
{
    public class AdaptiveAuthRequest : BaseRequest
    {
        public Models.AdaptiveAuthentication AdaptiveAuth { get; set; }

        public AdaptiveAuthRequest()
        {
            AdaptiveAuth = new Models.AdaptiveAuthentication();
        }
    }
}
