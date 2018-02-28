namespace SecureAuth.Admin.Sdk.Models
{
    public class Workflow
    {
        public DeviceRecognitionMethod DeviceRecognitionMethod { get; set; }
        public BrowserProfileSetting BrowserProfileSetting { get; set; }
        public MobileProfileSetting MobileProfileSetting { get; set; }
        public ProfileSetting ProfileSetting { get; set; }
        public LoginScreen LoginScreen { get; set; }
        public SessionTimeout SessionTimeout { get; set; }
        public TokenPersistence TokenPersistence { get; set; }
        public Redirect Redirect { get; set; }
        public TerminationPoint TerminationPoint { get; set; }
        public CustomIdentityConsumer CustomIdentityConsumer { get; set; }
        public FbaWebService FbaWebService { get; set; }
    }
}
