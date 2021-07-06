using SecureAuth.Sdk.Models;

namespace SecureAuth.Sdk
{
    public interface IAdaptiveAuthService
    {
        AdaptiveAuthResponse RunAdaptiveAuth(AdaptiveAuthRequest request, bool errorOnAccountStatus = false);
    }
}
