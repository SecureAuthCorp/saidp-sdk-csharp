using SecureAuth.Sdk.Responses;
using System;

namespace SecureAuth.Sdk
{
<<<<<<< HEAD
    public class DeviceFingerprintService
=======
    public class DeviceFingerprintService : IDeviceFingerprintService
>>>>>>> 767840d... updates for .net core and language helper function
    {
        private readonly ApiClient _apiClient;

        protected internal DeviceFingerprintService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        #region Public Methods

<<<<<<< HEAD
=======
        /// <summary>
        /// Returns the source for the DFP javascript
        /// </summary>
        /// <returns>DfpJavascriptLinkResponse</returns>
>>>>>>> 767840d... updates for .net core and language helper function
        public DfpJavascriptLinkResponse GetDfpJavascriptLink()
        {
            return this._apiClient.Get<DfpJavascriptLinkResponse>("/api/v1/dfp/js");
        }

<<<<<<< HEAD
=======
        /// <summary>
        /// Validates the provided Fingerprint
        /// </summary>
        /// <param name="request">ValidateDfpRequest</param>
        /// <returns>DfpResponse</returns>
>>>>>>> 767840d... updates for .net core and language helper function
        public DfpResponse ValidateDfp(ValidateDfpRequest request)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateDfpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.HostAddress))
            {
                throw new ArgumentNullException("ValidateDfpRequest.HostAddress", "Host Address cannot be empty.");
            }
            if (null == request.Fingerprint)
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint", "Fingerprint cannot be empty.");
            }
<<<<<<< HEAD
            if (string.IsNullOrEmpty(request.Fingerprint.UserAgent))
=======
            if (string.IsNullOrWhiteSpace(request.Fingerprint.Fingerprint.UaString))
>>>>>>> 767840d... updates for .net core and language helper function
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint.UserAgent", "User-Agent cannot be empty.");
            }

            return this._apiClient.Post<DfpResponse>("/api/v1/dfp/validate", request);
        }

<<<<<<< HEAD
=======
        /// <summary>
        /// Confirms a Fingerprint is valid and saves it to the user profile.
        /// Requires a preceding ValidateDFP to generate the FingerprintId if it is a new device.
        /// </summary>
        /// <param name="request">ConfirmDfpRequest</param>
        /// <returns>DfpResponse</returns>
>>>>>>> 767840d... updates for .net core and language helper function
        public DfpResponse ConfirmDfp(ConfirmDfpRequest request)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateDfpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.FingerprintId))
            {
                throw new ArgumentNullException("ValidateDfpRequest.FingerprintId", "Fingerprint ID cannot be empty.");
            }

            return this._apiClient.Post<DfpResponse>("/api/v1/dfp/confirm", request);
        }

<<<<<<< HEAD
=======
        /// <summary>
        /// Scores a Fingerprint against existing fingerprints on the user's profile.
        /// </summary>
        /// <param name="request">ScoreDfpRequest</param>
        /// <returns>DfpResponse</returns>
        public DfpResponse ScoreDfp(ScoreDfpRequest request)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateDfpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.HostAddress))
            {
                throw new ArgumentNullException("ValidateDfpRequest.HostAddress", "Host Address cannot be empty.");
            }
            if (null == request.Fingerprint)
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint", "Fingerprint cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(request.Fingerprint.UaString))
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint.UserAgent", "User-Agent cannot be empty.");
            }

            return this._apiClient.Post<DfpResponse>("/api/v1/dfp/score", request);
        }

        /// <summary>
        /// Saves a Fingerprint to the user's profile.
        /// </summary>
        /// <param name="request">SaveDfpRequest</param>
        /// <returns>DfpResponse</returns>
        public DfpResponse SaveDfp(SaveDfpRequest request)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateDfpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.HostAddress))
            {
                throw new ArgumentNullException("ValidateDfpRequest.HostAddress", "Host Address cannot be empty.");
            }
            if (null == request.Fingerprint)
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint", "Fingerprint cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(request.Fingerprint.UaString))
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint.UserAgent", "User-Agent cannot be empty.");
            }

            return this._apiClient.Post<DfpResponse>("/api/v1/dfp/save", request);
        }
>>>>>>> 767840d... updates for .net core and language helper function
        #endregion
    }
}
