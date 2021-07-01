using SecureAuth.Sdk.Requests;
using SecureAuth.Sdk.Responses;
using System;

namespace SecureAuth.Sdk
{
    public class BehavioralBiometricsService : IBehavioralBiometricsService
    {
        private readonly ApiClient _apiClient;
        private string apiVersion = "v2";

        protected internal BehavioralBiometricsService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        #region Public Methods

        /// <summary>
        /// Get Biometrics Javascript src
        /// </summary>
        /// <returns>BiometricsJavascriptLinkResponse</returns>
        public BiometricsJavascriptLinkResponse GetBehavioralBioJavascriptLink()
        {
            return this._apiClient.Get<BiometricsJavascriptLinkResponse>("/api/" + apiVersion + "/behavebio/js");
        }

        /// <summary>
        /// Send Biometrics
        /// </summary>
        /// <param name="request">ValidateBehaveBioRequest</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse SendBehavioralBio(SendBehavioralBioRequest request)
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
            if (null == request.BehaviorProfile)
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint", "Fingerprint cannot be empty.");
            }

            return this._apiClient.Post<BaseResponse>("/api/" + apiVersion + "/dfp/behavebio", request);
        }

        /// <summary>
        /// Reset Biometrics
        /// </summary>
        /// <param name="request">ResetBehavioralBio</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ResetBehavioralBio(ResetBehavioralBioRequest request)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("ValidateDfpRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.DeviceType))
            {
                throw new ArgumentNullException("ValidateDfpRequest.HostAddress", "Host Address cannot be empty.");
            }
 
            if (string.IsNullOrWhiteSpace(request.FieldName))
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint.UserAgent", "User-Agent cannot be empty.");
            }


            if (string.IsNullOrWhiteSpace(request.FieldType))
            {
                throw new ArgumentNullException("ValidateDfpRequest.Fingerprint.UserAgent", "User-Agent cannot be empty.");
            }

            return this._apiClient.Put<BaseResponse>("/api/" + apiVersion + "/dfp/behavebio", request);
        }
        #endregion
    }
}
