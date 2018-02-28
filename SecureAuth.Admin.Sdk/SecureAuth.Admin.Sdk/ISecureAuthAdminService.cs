namespace SecureAuth.Admin.Sdk
{
    public interface ISecureAuthAdminService
    {
        Configuration Configuration { get; set; }
        string AppId { get; set; }
        string AppKey { get; set; }
        string SecureAuthUrl { get; set; }
        IRealmService Realm { get; }        
    }
}
