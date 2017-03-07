using SecureAuth.Sdk.Responses;
using System;

namespace SecureAuth.Sdk
{
    public class DeviceFingerprintService : IDeviceFingerprintService
    {
        private readonly ApiClient _apiClient;

        protected internal DeviceFingerprintService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        #region Public Methods

        public DfpJavascriptLinkResponse GetDfpJavascriptLink()
        {
            return this._apiClient.Get<DfpJavascriptLinkResponse>("/api/v1/dfp/js");
        }

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
            if (string.IsNullOrEmpty(request.Fingerprint.UserAgent))
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint.UserAgent", "User-Agent cannot be empty.");
            }

            return this._apiClient.Post<DfpResponse>("/api/v1/dfp/validate", request);
        }

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

        #endregion
    }
}
