using System;
using SecureAuth.Admin.Sdk.Models;

namespace SecureAuth.Admin.Sdk
{
    public class VersionService : IVersionService
    {
        private readonly ApiClient _apiClient;

        protected internal VersionService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }


        /// <summary>
        /// Returns the SecureAuth appliance version information         
        /// </summary>
        /// <returns>VersionResponse</returns>
        public VersionResponse GetVersion()
        {
            string endpoint = "/api/v1/version"; ;

            return this._apiClient.Post<VersionResponse>(endpoint);
        }

    }
 }
