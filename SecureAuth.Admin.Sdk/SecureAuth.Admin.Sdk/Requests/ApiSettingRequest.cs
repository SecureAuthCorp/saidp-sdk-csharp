namespace SecureAuth.Admin.Sdk
{
    public class ApiSettingRequest : BaseRequest
    {
        public Models.ApiSetting ApiSetting { get; set; }

        public ApiSettingRequest()
        {
            ApiSetting = new Models.ApiSetting();
        }
    }
}
