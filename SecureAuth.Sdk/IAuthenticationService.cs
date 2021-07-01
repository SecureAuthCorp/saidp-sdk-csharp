using System.Net;

namespace SecureAuth.Sdk
{
    public interface IAuthenticationService
    {
        BaseResponse ValidateUserId(ValidateUserIdRequest request);
        BaseResponse ValidatePassword(ValidatePasswordRequest request);
        BaseResponse ValidateKba(ValidateKbaRequest request);
        BaseResponse ValidateOath(ValidateOathRequest request);
        BaseResponse ValidatePin(ValidatePinRequest request);
        BaseResponse ValidateOtp(ValidateOtpRequest request);
        SendOtpResponse SendEmailOtp(EmailOtpRequest request);
        SendOtpResponse SendHelpDeskOtp(HelpDeskOtpRequest request);
        SendOtpResponse SendPhonecallOtp(PhonecallOtpRequest request);
        SendOtpResponse SendPushOtp(PushOtpRequest request);
        SendOtpResponse SendSmsOtp(SmsOtpRequest request);
        PushAcceptResponse SendPushAccept(PushAcceptRequest request);
        PushBiometricResponse SendPushBiometric(PushBiometricRequest request);
        BaseResponse GetPushAcceptStatus(string referenceId);

        BaseResponse GetLinkStatus(string referenceId);
        BaseResponse GetPushAcceptStatusStateful(string referenceId, string ingressCookie);
        SendOtpResponse SendAdHocSmsOtp(AdHocSmsOtpRequest request);
        SendOtpResponse SendAdHocPhonecallOtp(AdHocPhonecallOtpRequest request);
        SendOtpResponse SendAdHocEmailOtp(AdHocEmailOtpRequest request);
        SmsLinkResponse SendSmsLink(SmsLinkOtpRequest request);
        EmailLinkResponse SendEmailLinkOtp(EmailLinkOtpRequest request);
        PushAcceptSymbolResponse SendPushAcceptSymbol(PushAcceptSymbolRequest request);
    }
}
