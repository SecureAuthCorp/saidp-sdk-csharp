namespace SecureAuth.Sdk
{
    public interface IAdaptiveAuthService
    {
        AdaptiveAuthResponse RunAdaptiveAuth(AdaptiveAuthRequest request);
    }
}
