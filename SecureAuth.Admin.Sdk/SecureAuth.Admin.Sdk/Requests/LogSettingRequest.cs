namespace SecureAuth.Admin.Sdk
{
    public class LogSettingRequest : BaseRequest
    {
        public Models.LogSetting LogSetting { get; set; }

        public LogSettingRequest()
        {
            LogSetting = new Models.LogSetting();
        }
    }
}
