namespace SecureAuth.Sdk
{
    public interface INumberProfileService
    {
        NumberProfileResponse EvaluatePhoneNumber(string userId, string phoneNumber);
        NumberProfileResponse EvaluatePhoneNumber(NumberProfileRequest request);
        BaseResponse UpdateOriginalCarrier(string userId, string phoneNumber, CurrentCarrier carrier);
        BaseResponse UpdateOriginalCarrier(NumberProfileRequest request);
    }
}
