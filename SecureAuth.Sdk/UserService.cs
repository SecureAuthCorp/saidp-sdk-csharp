using System;

namespace SecureAuth.Sdk
{
    public class UserService
    {
        private readonly ApiClient _apiClient;

        protected internal UserService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        /// <summary>
        /// Retrieve all multi-factor options available for the
        /// given User ID and which have been configured in SecureAuth.
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <returns>GetFactorResponse</returns>
        public GetFactorsResponse GetFactors(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            return this._apiClient.Get<GetFactorsResponse>(string.Format("/api/v1/users/{0}/factors", userId));
        }
    }
}