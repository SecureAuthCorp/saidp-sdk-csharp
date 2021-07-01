using SecureAuth.Sdk.Requests;
using SecureAuth.Sdk.Responses;

namespace SecureAuth.Sdk
{
    public interface IBehavioralBiometricsService
    {
        BiometricsJavascriptLinkResponse GetBehavioralBioJavascriptLink();
        BaseResponse SendBehavioralBio(SendBehavioralBioRequest request);
        BaseResponse ResetBehavioralBio(ResetBehavioralBioRequest request);
    }
}
