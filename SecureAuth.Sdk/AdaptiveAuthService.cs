using System;

namespace SecureAuth.Sdk
{
    public class AdaptiveAuthService : IAdaptiveAuthService
    {
        private readonly ApiClient _apiClient;
        private string apiVersion = "v2";

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
        public AdaptiveAuthResponse RunAdaptiveAuth(AdaptiveAuthRequest request)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("AdaptiveAuthRequest.UserId", "User ID cannot be empty.");
            }

            return this._apiClient.Post<AdaptiveAuthResponse>("/api/" + apiVersion + "/adaptauth", request);
        }
    }
}