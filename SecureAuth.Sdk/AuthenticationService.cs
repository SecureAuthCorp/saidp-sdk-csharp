using SecureAuth.Sdk.Models;
using System;
using System.Linq;
using System.Net;

namespace SecureAuth.Sdk
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApiClient _apiClient;
        private string apiVersion = "v2";

        protected internal AuthenticationService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        #region Public Methods

        #region Validation Methods
        /// <summary>
        /// Validate user ID provided in the request against SecureAuth
        /// realm's datastore configuration.
        /// </summary>
        /// <param name="request">ValidateUserIdRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ValidateUserId(ValidateUserIdRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateUserIdRequest.UserId", "User ID cannot be empty.");
            }

            // process request
            return Validate(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Validate password and user ID provided in the request against SecureAuth
        /// realm's datastore configuration.
        /// </summary>
        /// <param name="request">ValidatePasswordRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ValidatePassword(ValidatePasswordRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateUserIdRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.Token))
            {
                throw new ArgumentNullException("ValidateUserIdRequest.Token", "Token cannot be empty.");
            }

            // process request
            return Validate(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Validate knowledgebase answer for specified knowledgebase
        /// question.
        /// </summary>
        /// <param name="request">ValidateKbaRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ValidateKba(ValidateKbaRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateKbaRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.Token))
            {
                throw new ArgumentNullException("ValidateKbaRequest.Token", "Token cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("ValidateKbaRequest.FactorId", "FactorId cannot be empty.");
            }

            // process request
            return Validate(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Validate a SecureAuth soft token.
        /// </summary>
        /// <param name="request">ValidateOathRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ValidateOath(ValidateOathRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateOathRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.Token))
            {
                throw new ArgumentNullException("ValidateOathRequest.Token", "Token cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("ValidateOathRequest.FactorId", "FactorId cannot be empty.");
            }

            // process request
            return Validate(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Validate static PIN and user ID provided in the request against SecureAuth
        /// realm's datastore configuration.
        /// </summary>
        /// <param name="request">ValidatePasswordRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ValidatePin(ValidatePinRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidatePinRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.Token))
            {
                throw new ArgumentNullException("ValidatePinRequest.Token", "Token cannot be empty.");
            }

            // process request
            return Validate(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Validate the user entered OTP agains the OTP sent using the SendOTP API.
        /// Requires configuration to enable OTP saving to user profile in IdP.
        /// </summary>
        /// <param name="request">ValidateOtpRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ValidateOtp(ValidateOtpRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateOtpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.Otp))
            {
                throw new ArgumentNullException("ValidateOtpRequest.Otp", "OTP cannot be empty.");
            }

            string apiVersion = errorOnAccountStatus ? ApiVersion.V1.Value : ApiVersion.V2.Value;
            //process request
            return this._apiClient.Post<BaseResponse>("/api/" + apiVersion + "/otp/validate", request);
        }
        #endregion

        #region Send OTP Methods

        /// <summary>
        /// Send a one time passcode to the email address associated
        /// with the email factor ID.
        /// </summary>
        /// <param name="request">EmailOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendEmailOtp(EmailOtpRequest request, bool errorOnAccountStatus = false)
        {
            string[] validFactorIds = { "Email1", "Email2", "Email3", "Email4" };

            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("EmailOtpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("EmailOtpRequest.FactorId", "FactorId cannot be empty.");
            }
            if (!validFactorIds.Contains(request.FactorId))
            {
                throw new ArgumentException("Invalid FactorId.", "EmailOtpRequest.FactorId");
            }

            // process request
            return SendOtp(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Send a one time passcode to the Help Desk associated
        /// with the factor ID.
        /// </summary>
        /// <param name="request">HelpDeskOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendHelpDeskOtp(HelpDeskOtpRequest request, bool errorOnAccountStatus = false)
        {
            string[] validFactorIds = { "HelpDesk1", "HelpDesk2" };

            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("HelpDeskOtpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("HelpDeskOtpRequest.FactorId", "FactorId cannot be empty.");
            }
            if (!validFactorIds.Contains(request.FactorId))
            {
                throw new ArgumentException("Invalid FactorId.", "HelpDeskOtpRequest.FactorId");
            }

            // process request
            return SendOtp(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Send a one time passcode to the phone number associated
        /// with the phone factor ID.
        /// </summary>
        /// <param name="request">PhonecallOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendPhonecallOtp(PhonecallOtpRequest request, bool errorOnAccountStatus = false)
        {
            string[] validFactorIds = { "Phone1", "Phone2", "Phone3", "Phone4" };

            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("PhonecallOtpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("PhonecallOtpRequest.FactorId", "FactorId cannot be empty.");
            }
            if (!validFactorIds.Contains(request.FactorId))
            {
                throw new ArgumentException("Invalid FactorId.", "PhonecallOtpRequest.FactorId");
            }

            // process request
            return SendOtp(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Send a one time passcode to the push enabled device associated
        /// with the push factor ID.
        /// </summary>
        /// <param name="request">PushOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendPushOtp(PushOtpRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("PushOtpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("PushOtpRequest.FactorId", "FactorId cannot be empty.");
            }

            // process request
            return SendOtp(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Send a one time passcode SMS message to the phone number 
        /// associated with the phone factor ID.
        /// </summary>
        /// <param name="request">SmsOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendSmsOtp(SmsOtpRequest request, bool errorOnAccountStatus = false)
        {
            string[] validFactorIds = { "Phone1", "Phone2", "Phone3", "Phone4" };

            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("PhonecallOtpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("PhonecallOtpRequest.FactorId", "FactorId cannot be empty.");
            }
            if (!validFactorIds.Contains(request.FactorId))
            {
                throw new ArgumentException("Invalid FactorId.", "PhonecallOtpRequest.FactorId");
            }

            // process request
            return SendOtp(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Send one time passcode SMS message to the specified phone number.
        /// </summary>
        /// <param name="request">AdHocSmsOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendAdHocSmsOtp(AdHocSmsOtpRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("AdHocSmsOtpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.Token))
            {
                throw new ArgumentNullException("AdHocSmsOtpRequest.Token", "Token cannot be empty");
            }
            // process request
            return SendOtp(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Send one time passcode to the specified phone number via voice call.
        /// </summary>
        /// <param name="request">AdHocPhonecallOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendAdHocPhonecallOtp(AdHocPhonecallOtpRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("AdHocPhonecallOtpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.Token))
            {
                throw new ArgumentNullException("AdHocPhonecallOtpRequest.Token", "Token cannot be empty");
            }
            // process request
            return SendOtp(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        /// <summary>
        /// Send one time passcode email message to the specified email address.
        /// </summary>
        /// <param name="request">AdHocEmailOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendAdHocEmailOtp(AdHocEmailOtpRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("AdHocEmailOtpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.Token))
            {
                throw new ArgumentNullException("AdHocEmailOtpRequest.Token", "Token cannot be empty");
            }
            // process request
            return SendOtp(request, errorOnAccountStatus ? ApiVersion.V1 : ApiVersion.V2);
        }

        public SmsLinkResponse SendSmsLink(SmsLinkOtpRequest request, bool errorOnAccountStatus = false)
        {
            string[] validFactorIds = { "Phone1", "Phone2", "Phone3", "Phone4" };

            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("SendSmsLink.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("SendSmsLink.FactorId", "FactorId cannot be empty.");
            }
            if (!validFactorIds.Contains(request.FactorId))
            {
                throw new ArgumentException("Invalid FactorId.", "SendSmsLink.FactorId");
            }

            string apiVersion = errorOnAccountStatus ? ApiVersion.V1.Value : ApiVersion.V2.Value;

            // process request
            return this._apiClient.Post<SmsLinkResponse>("/api/" + apiVersion + "/auth", request);
        }


        public EmailLinkResponse SendEmailLinkOtp(EmailLinkOtpRequest request, bool errorOnAccountStatus = false)
        {
            string[] validFactorIds = { "Email1", "Email2", "Email3", "Email4" };

            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("EmailOtpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("EmailOtpRequest.FactorId", "FactorId cannot be empty.");
            }
            if (!validFactorIds.Contains(request.FactorId))
            {
                throw new ArgumentException("Invalid FactorId.", "EmailOtpRequest.FactorId");
            }

            string apiVersion = errorOnAccountStatus ? ApiVersion.V1.Value : ApiVersion.V2.Value;

            // process request
            return this._apiClient.Post<EmailLinkResponse>("/api/" + apiVersion + "/auth", request);
        }

        #endregion

        #region Push Accept Methods
        /// <summary>
        /// Send a two-way push accept message to an enabled device associated
        /// with the push factor ID.
        /// </summary>
        /// <param name="request">PushAcceptRequest</param>
        /// <returns>SendOtpResponse</returns>
        public PushAcceptResponse SendPushAccept(PushAcceptRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("PushAcceptRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("PushAcceptRequest.FactorId", "FactorId cannot be empty.");
            }


            string apiVersion = errorOnAccountStatus ? ApiVersion.V1.Value : ApiVersion.V2.Value;

            // process request
            return this._apiClient.Post<PushAcceptResponse>("/api/" + apiVersion + "/auth", request);
        }

        public PushBiometricResponse SendPushBiometric(PushBiometricRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("PushBiometricRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("PushBiometricRequest.FactorId", "FactorId cannot be empty.");
            }
            if (request.BiometricType == null)
            {
                throw new ArgumentNullException("PushBiometricRequest.FactorId", "BiometricType cannot be empty.");
            }

            string apiVersion = errorOnAccountStatus ? ApiVersion.V1.Value : ApiVersion.V2.Value;

            // process request
            return this._apiClient.Post<PushBiometricResponse>("/api/" + apiVersion + "/auth", request);
        }

        public PushAcceptSymbolResponse SendPushAcceptSymbol(PushAcceptSymbolRequest request, bool errorOnAccountStatus = false)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("PushAcceptSymbolRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FactorId))
            {
                throw new ArgumentNullException("PushAcceptSymbolRequest.FactorId", "FactorId cannot be empty.");
            }

            string apiVersion = errorOnAccountStatus ? ApiVersion.V1.Value : ApiVersion.V2.Value;

            // process request
            return this._apiClient.Post<PushAcceptSymbolResponse>("/api/" + apiVersion + "/auth", request);
        }

        /// <summary>
        /// Poll the resposne status
        /// </summary>
        /// <param name="referenceId">The push-accept request reference ID.</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse GetPushAcceptStatus(string referenceId)
        {
            if (string.IsNullOrEmpty(referenceId))
            {
                throw new ArgumentNullException("referenceId", "Reference ID cannot be empty.");
            }

            return this._apiClient.Get<BaseResponse>(string.Format("/api/" + apiVersion + "/auth/{0}", referenceId));
        }

        public BaseResponse GetPushAcceptStatusStateful(string referenceId, string ingressCookie)
        {
            if (string.IsNullOrEmpty(referenceId))
            {
                throw new ArgumentNullException("referenceId", "Reference ID cannot be empty.");
            }

            return this._apiClient.GetStateful<BaseResponse>(string.Format("/api/" + apiVersion + "/auth/{0}", referenceId), ingressCookie);
        }

        public BaseResponse GetLinkStatus(string referenceId)
        {
            if (string.IsNullOrEmpty(referenceId))
            {
                throw new ArgumentNullException("referenceId", "Reference ID cannot be empty.");
            }

            return this._apiClient.Get<BaseResponse>(string.Format("/api/" + apiVersion + "/auth/link/{0}", referenceId));
        }

        #endregion

        #endregion

        #region Private Methods
        private BaseResponse Validate(BaseRequest request, ApiVersion apiVersion)
        {
            return this._apiClient.Post<BaseResponse>("/api/" + apiVersion.Value + "/auth", request);
        }

        private SendOtpResponse SendOtp(BaseRequest request, ApiVersion apiVersion)
        {
            return this._apiClient.Post<SendOtpResponse>("/api/" + apiVersion.Value + "/auth", request);
        }
        #endregion
    }
}
