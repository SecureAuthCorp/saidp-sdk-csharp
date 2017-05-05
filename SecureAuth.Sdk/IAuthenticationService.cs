namespace SecureAuth.Sdk
{
    public interface IAuthenticationService
    {
        BaseResponse ValidateUserId(ValidateUserIdRequest request);
        BaseResponse ValidatePassword(ValidatePasswordRequest request);
        BaseResponse ValidateKba(ValidateKbaRequest request);
        BaseResponse ValidateOath(ValidateOathRequest request);
        BaseResponse ValidatePin(ValidatePinRequest request);
        SendOtpResponse SendEmailOtp(EmailOtpRequest request);
        SendOtpResponse SendHelpDeskOtp(HelpDeskOtpRequest request);
        SendOtpResponse SendPhonecallOtp(PhonecallOtpRequest request);
        SendOtpResponse SendPushOtp(PushOtpRequest request);
        SendOtpResponse SendSmsOtp(SmsOtpRequest request);
        PushAcceptResponse SendPushAccept(PushAcceptRequest request);
        BaseResponse GetPushAcceptStatus(string referenceId);
        SendOtpResponse SendAdHocSmsOtp(AdHocSmsOtpRequest request);
        SendOtpResponse SendAdHocPhonecallOtp(AdHocPhonecallOtpRequest request);
        SendOtpResponse SendAdHocEmailOtp(AdHocEmailOtpRequest request);
    }
}
