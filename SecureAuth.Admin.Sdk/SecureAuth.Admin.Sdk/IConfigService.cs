namespace SecureAuth.Admin.Sdk
{
    public interface IConfigService
    {
        BaseResponse EncryptConfig();
        BaseResponse DecryptConfig();
    }
}
