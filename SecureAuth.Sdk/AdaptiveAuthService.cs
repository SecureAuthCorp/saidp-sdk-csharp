using System;

namespace SecureAuth.Sdk
{
<<<<<<< HEAD
    public class AdaptiveAuthService
=======
    public class AdaptiveAuthService : IAdaptiveAuthService
>>>>>>> 767840d... updates for .net core and language helper function
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
        public AdaptiveAuthResponse RunAdaptiveAuth(AdaptiveAuthRequest request)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("AdaptiveAuthRequest.UserId", "User ID cannot be empty.");
            }

            return this._apiClient.Post<AdaptiveAuthResponse>("/api/v1/adaptauth", request);
        }
    }
}