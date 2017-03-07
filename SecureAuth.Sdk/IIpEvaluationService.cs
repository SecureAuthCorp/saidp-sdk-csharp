namespace SecureAuth.Sdk
{
    public interface IIpEvaluationService
    {
        IpRiskResponse GetIpRisk(IpRiskRequest request);
    }
}
