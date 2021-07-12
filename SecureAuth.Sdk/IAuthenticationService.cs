using System.Net;

namespace SecureAuth.Sdk
{
    public interface IAuthenticationService
    {
        BaseResponse ValidateUserId(ValidateUserIdRequest request, bool errorOnAccountStatus = false);
        BaseResponse ValidatePassword(ValidatePasswordRequest request, bool errorOnAccountStatus = false);
        BaseResponse ValidateKba(ValidateKbaRequest request, bool errorOnAccountStatus = false);
        BaseResponse ValidateOath(ValidateOathRequest request, bool errorOnAccountStatus = false);
        BaseResponse ValidatePin(ValidatePinRequest request, bool errorOnAccountStatus = false);
        BaseResponse ValidateOtp(ValidateOtpRequest request, bool errorOnAccountStatus = false);
        SendOtpResponse SendEmailOtp(EmailOtpRequest request, bool errorOnAccountStatus = false);
        SendOtpResponse SendHelpDeskOtp(HelpDeskOtpRequest request, bool errorOnAccountStatus = false);
        SendOtpResponse SendPhonecallOtp(PhonecallOtpRequest request, bool errorOnAccountStatus = false);
        SendOtpResponse SendPushOtp(PushOtpRequest request, bool errorOnAccountStatus = false);
        SendOtpResponse SendSmsOtp(SmsOtpRequest request, bool errorOnAccountStatus = false);
        PushAcceptResponse SendPushAccept(PushAcceptRequest request, bool errorOnAccountStatus = false);
        PushBiometricResponse SendPushBiometric(PushBiometricRequest request, bool errorOnAccountStatus = false);
        BaseResponse GetPushAcceptStatus(string referenceId);

        BaseResponse GetLinkStatus(string referenceId);
        BaseResponse GetPushAcceptStatusStateful(string referenceId, string ingressCookie);
        SendOtpResponse SendAdHocSmsOtp(AdHocSmsOtpRequest request, bool errorOnAccountStatus = false);
        SendOtpResponse SendAdHocPhonecallOtp(AdHocPhonecallOtpRequest request, bool errorOnAccountStatus = false);
        SendOtpResponse SendAdHocEmailOtp(AdHocEmailOtpRequest request, bool errorOnAccountStatus = false);
        SmsLinkResponse SendSmsLink(SmsLinkOtpRequest request, bool errorOnAccountStatus = false);
        EmailLinkResponse SendEmailLinkOtp(EmailLinkOtpRequest request, bool errorOnAccountStatus = false);
        PushAcceptSymbolResponse SendPushAcceptSymbol(PushAcceptSymbolRequest request, bool errorOnAccountStatus = false);
        SmsLinkResponse SendAdHocSmsLinkOtp(AdHocSmsLinkOtpRequest request, bool errorOnAccountStatus = false);
        EmailLinkResponse SendAdHocEmailLinkOtp(AdHocEmailLinkOtpRequest request, bool errorOnAccountStatus = false);

        BaseResponse GetLinkStatusStateful(string referenceId, string ingressCookie);
    }
}
