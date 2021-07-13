using SecureAuth.Sdk.Responses;
using System;

namespace SecureAuth.Sdk
{
    public class DeviceFingerprintService : IDeviceFingerprintService
    {
        private readonly ApiClient _apiClient;
        private string apiVersion = "v2";

        protected internal DeviceFingerprintService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        #region Public Methods

        /// <summary>
        /// Returns the source for the DFP javascript
        /// </summary>
        /// <returns>DfpJavascriptLinkResponse</returns>
        public DfpJavascriptLinkResponse GetDfpJavascriptLink()
        {
            return this._apiClient.Get<DfpJavascriptLinkResponse>("/api/" + apiVersion + "/dfp/js");
        }

        /// <summary>
        /// Validates the provided Fingerprint
        /// </summary>
        /// <param name="request">ValidateDfpRequest</param>
        /// <returns>DfpResponse</returns>
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
            if (string.IsNullOrWhiteSpace(request.Fingerprint.Fingerprint.UaString))
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint.UserAgent", "User-Agent cannot be empty.");
            }

            return this._apiClient.Post<DfpResponse>("/api/" + apiVersion + "/dfp/validate", request);
        }

        /// <summary>
        /// Confirms a Fingerprint is valid and saves it to the user profile.
        /// Requires a preceding ValidateDFP to generate the FingerprintId if it is a new device.
        /// </summary>
        /// <param name="request">ConfirmDfpRequest</param>
        /// <returns>DfpResponse</returns>
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

            return this._apiClient.Post<DfpResponse>("/api/" + apiVersion + "/dfp/confirm", request);
        }

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

            return this._apiClient.Post<DfpResponse>("/api/" + apiVersion + "/dfp/score", request);
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

            return this._apiClient.Post<DfpResponse>("/api/" + apiVersion + "/dfp/save", request);
        }
        #endregion
    }
}
