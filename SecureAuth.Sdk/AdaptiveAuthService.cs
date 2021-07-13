using SecureAuth.Sdk.Models;
using System;

namespace SecureAuth.Sdk
{
    public class AdaptiveAuthService : IAdaptiveAuthService
    {
        private readonly ApiClient _apiClient;

        protected internal AdaptiveAuthService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        /// <summary>
        /// Runs analyze engine over request parameters to determine
        /// risk and suggested action.
        /// </summary>
        /// <param name="request">Adaptive Auth Request object.</param>
        /// <returns>AdaptiveAuthResponse</returns>
        public AdaptiveAuthResponse RunAdaptiveAuth(AdaptiveAuthRequest request, bool errorOnAccountStatus = false)
        {
            
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("AdaptiveAuthRequest.UserId", "User ID cannot be empty.");
            }

            string apiVersion = errorOnAccountStatus ? ApiVersion.V1.Value : ApiVersion.V2.Value;

            return this._apiClient.Post<AdaptiveAuthResponse>("/api/" + apiVersion + "/adaptauth", request);
        }
    }
}