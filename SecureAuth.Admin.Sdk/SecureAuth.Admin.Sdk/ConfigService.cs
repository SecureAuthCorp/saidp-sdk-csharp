using System;
using SecureAuth.Admin.Sdk.Models;

namespace SecureAuth.Admin.Sdk
{
    public class ConfigService : IConfigService
    {
        private readonly ApiClient _apiClient;

        protected internal ConfigService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }


        /// <summary>
        /// Encrypt the web.config file used by the Admin API         
        /// </summary>
        /// <returns>VersionResponse</returns>
        public BaseResponse EncryptConfig()
        {
            string endpoint = "/api/v2/config/encrypt"; ;

            return this._apiClient.Patch<BaseResponse>(endpoint);
        }

        /// <summary>
        /// Decrypt the web.config file used by the Admin API         
        /// </summary>
        /// <returns>VersionResponse</returns>
        public BaseResponse DecryptConfig()
        {
            string endpoint = "/api/v2/config/decrypt"; ;

            return this._apiClient.Patch<BaseResponse>(endpoint);
        }

    }
 }
