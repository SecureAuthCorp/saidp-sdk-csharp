namespace SecureAuth.Sdk
{
    public interface IAccessHistoryService
    {
        BaseResponse CreateAccessHistory(AccessHistoryRequest request);
    }
}
