namespace SecureAuth.Admin.Sdk
{
    public class PostAuthRequest : BaseRequest
    {
        public Models.PostAuthentication PostAuth { get; set; }

        public PostAuthRequest()
        {
            PostAuth = new Models.PostAuthentication();
        }
    }
}
