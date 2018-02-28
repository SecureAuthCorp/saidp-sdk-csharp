namespace SecureAuth.Admin.Sdk.Models
{
    public class Redirect
    {
        public string InvalidatePersistentTokenRedirect { get; set; }
        public string TokenMissingRedirect { get; set; }
        public string ProfileMissingRedirect { get; set; }
        public string MobileRedirect { get; set; }
        public string MobileIdentifiers { get; set; }
    }
}