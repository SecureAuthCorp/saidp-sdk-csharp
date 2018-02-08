namespace SecureAuth.Admin.Sdk
{
    public class UserRiskProviderRequest : BaseRequest
    {
        public Models.v2.UserRiskProvider UserRiskProvider { get; set; }

        public UserRiskProviderRequest()
        {
            UserRiskProvider = new Models.v2.UserRiskProvider();
        }
    }
}
