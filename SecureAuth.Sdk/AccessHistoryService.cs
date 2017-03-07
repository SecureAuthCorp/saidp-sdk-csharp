using System;

namespace SecureAuth.Sdk
{
    public class AccessHistoryService : IAccessHistoryService
    {
        private readonly ApiClient _apiClient;

        protected internal AccessHistoryService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        /// <summary>
        /// Creates an Access History record on the specified
        /// user's profile.
        /// </summary>
        /// <param name="request">AccessHistory Request object.</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse CreateAccessHistory(AccessHistoryRequest request)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("AccessHistoryRequest.UserId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.IpAddress))
            {
                throw new ArgumentNullException("AccessHistoryRequest.IpAddress", "IP Address cannot be empty.");
            }

            return this._apiClient.Post<BaseResponse>("/api/v1/accesshistory", request);
        }
    }
}