namespace SecureAuth.Admin.Sdk.Models
{
    public class PostAuthCookie
    {
        public string PreAuthenticationCookie { get; set; }
        public string PostAuthenticationCookie { get; set; }
        public bool? IsPersistent { get; set; }
        public bool? CleanUpAuthCookie { get; set; }
    }
}
