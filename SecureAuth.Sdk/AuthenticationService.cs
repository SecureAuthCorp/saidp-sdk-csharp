using System;
using System.Linq;

namespace SecureAuth.Sdk
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApiClient _apiClient;

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
        public BaseResponse ValidateUserId(ValidateUserIdRequest request)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateUserIdRequest.UserId", "User ID cannot be empty.");
            }

            // process request
            return Validate(request);
        }

        /// <summary>
        /// Validate password and user ID provided in the request against SecureAuth
        /// realm's datastore configuration.
        /// </summary>
        /// <param name="request">ValidatePasswordRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ValidatePassword(ValidatePasswordRequest request)
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
            return Validate(request);
        }

        /// <summary>
        /// Validate knowledgebase answer for specified knowledgebase
        /// question.
        /// </summary>
        /// <param name="request">ValidateKbaRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ValidateKba(ValidateKbaRequest request)
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
            return Validate(request);
        }

        /// <summary>
        /// Validate a SecureAuth soft token.
        /// </summary>
        /// <param name="request">ValidateOathRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ValidateOath(ValidateOathRequest request)
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
            return Validate(request);
        }

        /// <summary>
        /// Validate static PIN and user ID provided in the request against SecureAuth
        /// realm's datastore configuration.
        /// </summary>
        /// <param name="request">ValidatePasswordRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ValidatePin(ValidatePinRequest request)
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
            return Validate(request);
        }
        #endregion

        #region Send OTP Methods
        /// <summary>
        /// Send a one time passcode to the email address associated
        /// with the email factor ID.
        /// </summary>
        /// <param name="request">EmailOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendEmailOtp(EmailOtpRequest request)
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
            return SendOtp(request);
        }

        /// <summary>
        /// Send a one time passcode to the Help Desk associated
        /// with the factor ID.
        /// </summary>
        /// <param name="request">HelpDeskOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendHelpDeskOtp(HelpDeskOtpRequest request)
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
            return SendOtp(request);
        }

        /// <summary>
        /// Send a one time passcode to the phone number associated
        /// with the phone factor ID.
        /// </summary>
        /// <param name="request">PhonecallOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendPhonecallOtp(PhonecallOtpRequest request)
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
            return SendOtp(request);
        }

        /// <summary>
        /// Send a one time passcode to the push enabled device associated
        /// with the push factor ID.
        /// </summary>
        /// <param name="request">PushOtpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendPushOtp(PushOtpRequest request)
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
            Guid temp;
            if (!Guid.TryParseExact(request.FactorId, "N", out temp))
            {
                throw new ArgumentException("Invalid FactorId format. Must be a GUID.", "PushOtpRequest.FactorId");
            }

            // process request
            return SendOtp(request);
        }
        
        /// <summary>
        /// Send a one time passcode SMS message to the phone number 
        /// associated with the phone factor ID.
        /// </summary>
        /// <param name="request">SmstpRequest</param>
        /// <returns>SendOtpResponse</returns>
        public SendOtpResponse SendSmsOtp(SmsOtpRequest request)
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
            return SendOtp(request);
        }
        #endregion

        #region Push Accept Methods
        /// <summary>
        /// Send a two-way push accept message to an enabled device associated
        /// with the push factor ID.
        /// </summary>
        /// <param name="request">PushAcceptRequest</param>
        /// <returns>SendOtpResponse</returns>
        public PushAcceptResponse SendPushAccept(PushAcceptRequest request)
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
            Guid temp;
            if (!Guid.TryParseExact(request.FactorId, "N", out temp))
            {
                throw new ArgumentException("Invalid FactorId format. Must be a GUID.", "PushAcceptRequest.FactorId");
            }

            // process request
            return this._apiClient.Post<PushAcceptResponse>("/api/v1/auth", request);
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

            return this._apiClient.Get<BaseResponse>(string.Format("/api/v1/auth/{0}", referenceId));
        }
        #endregion

        #endregion

        #region Private Methods
        private BaseResponse Validate(BaseRequest request)
        {
            return this._apiClient.Post<BaseResponse>("/api/v1/auth", request);
        }

        private SendOtpResponse SendOtp(BaseRequest request)
        {
            return this._apiClient.Post<SendOtpResponse>("/api/v1/auth", request);
        }
        #endregion
    }
}
