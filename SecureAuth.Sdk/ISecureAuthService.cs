namespace SecureAuth.Sdk
{
    public interface ISecureAuthService
    {
        Configuration Configuration { get; set; }
        string AppId { get; set; }
        string AppKey { get; set; }
        string SecureAuthRealmUrl { get; set; }
        IUserService User { get; }
        IAuthenticationService Authenticate { get; }
        IIpEvaluationService EvaluateIp { get; }
        IDeviceFingerprintService DeviceFingerprint { get; }
        IAccessHistoryService AccessHistory { get; }
        IAdaptiveAuthService AdaptiveAuth { get; }
        IGroupService GroupService { get; }
    }
}
