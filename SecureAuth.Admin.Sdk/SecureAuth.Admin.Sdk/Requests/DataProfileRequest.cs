namespace SecureAuth.Admin.Sdk
{
    public class DataProfileRequest : BaseRequest
    {
        public Models.Profile Profile { get; set; }

        public DataProfileRequest()
        {
            Profile = new Models.Profile();
        }
    }
}
