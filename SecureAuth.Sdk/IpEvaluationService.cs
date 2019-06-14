using System;

namespace SecureAuth.Sdk
{
<<<<<<< HEAD
    public class IpEvaluationService
=======
    public class IpEvaluationService : IIpEvaluationService
>>>>>>> 767840d... updates for .net core and language helper function
    {
        private readonly ApiClient _apiClient;

        protected internal IpEvaluationService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        /// <summary>
        /// Retrieves risk and geolocation information for
        /// the IP address provided in the request.
        /// </summary>
        /// <param name="request">IpRiskRequest</param>
        /// <returns>IpRiskResponse</returns>
        public IpRiskResponse GetIpRisk(IpRiskRequest request)
        {
            // sanitize request
            if (string.IsNullOrEmpty(request.IpAddress))
            {
                throw new ArgumentNullException("IpRiskRequest.IpAddress", "IP Address cannot be empty.");
            }

            return this._apiClient.Post<IpRiskResponse>("/api/v1/ipeval", request);
        }
    }
}