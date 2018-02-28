using System;
using SecureAuth.Admin.Sdk.Models;

namespace SecureAuth.Admin.Sdk
{
    public class RealmService : IRealmService
    {
        private readonly ApiClient _apiClient;

        protected internal RealmService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }


        /// <summary>
        /// Retrieve all realm information for the 
        /// given realm Id.
        /// </summary>
        /// <param name="realmId">The Id number of the realm</param>
        /// <returns>RealmResponse</returns>
        public RealmResponse GetRealm(string realmId)
        {
            if (string.IsNullOrEmpty(realmId))
            {
                throw new ArgumentNullException("realmId", "Realm ID cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}", realmId);

            return this._apiClient.Get<RealmResponse>(endpoint);
        }

        /// <summary>
        /// Creates a new realm using Realm 1 as a template         
        /// </summary>
        /// <returns>RealmResponse</returns>
        public RealmResponse CreateRealm()
        {
            string endpoint = "/api/v1/realms"; ;

            return this._apiClient.Post<RealmResponse>(endpoint);
        }

        /// <summary>
        /// Configure the realm's overview settings, including general realm description, 
        /// SMTP server integration, SecureAuth email messaging, and client-side login page information.
        /// </summary>
        /// <param name="UpdateOverview">UpdateOverview object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateOverview(OverviewRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("OverviewRequest", "Request cannot be empty.");
            }

            if (request.Overview == null)
            {
                throw new ArgumentNullException("overview", "Overview cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/overview", request.RealmId);

            return this._apiClient.Patch<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Configure the realm's Membership Directory integration. This is the information with which the end-user
        /// logs into the realm, but may not contain profile information required for authentication or assertion.
        /// </summary>
        /// <param name="DataMembershipRequest">DataMembershipRequest object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateDataMembership(DataMembershipRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("DataMembershipRequest", "Request cannot be empty.");
            }

            if (request.Membership == null)
            {
                throw new ArgumentNullException("Membership", "Membership cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/data/membership", request.RealmId);

            return this._apiClient.Patch<BaseResponse>(endpoint, request);

        }

        /// <summary>
        /// Configure the realm's Profile Provider Directory integration(s). This integration(s) 
        /// includes end-user profile data, which is utilized for authentication and assertion purposes.
        /// </summary>
        /// <param name="DataProfileRequest">DataProfileRequest object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateDataProfile(DataProfileRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("DataProfileRequest", "Request cannot be empty.");
            }

            if (request.Profile == null)
            {
                throw new ArgumentNullException("Profile", "Profile cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/data/profile", request.RealmId);

            return this._apiClient.Patch<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Configure the realm's Global Auxiliary values, which are standard values that are  
        /// asserted from SecureAuth IdP to the SP for each end-user without requiring directory storage.
        /// </summary>
        /// <param name="DataGlobalAuxRequest">DataGlobalAuxRequest object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateDataGlobalAux(DataGlobalAuxRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("DataGlobalAuxRequest", "Request cannot be empty.");
            }

            if (request.Data == null)
            {
                throw new ArgumentNullException("Data", "Data cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/data/globalaux", request.RealmId);

            return this._apiClient.Patch<BaseResponse>(endpoint, request);

        }

        /// <summary>
        /// Configure the realm's workflow settings, including client-side login 
        /// process, device recognition, token preferences, and user redirects.
        /// </summary>
        /// <param name="WorkflowRequest">WorkflowRequest object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateWorkflow(WorkflowRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("WorkflowRequest", "Request cannot be empty.");
            }

            if (request.Workflow == null)
            {
                throw new ArgumentNullException("Workflow", "Workflow cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/workflow", request.RealmId);

            return this._apiClient.Patch<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Enable and configure the realm's adaptive authentication settings, including IP / Country Restriction,
        /// User / Group Restrictions, Geo-Velocity, IP Reputation / Threat Data, and User Risk.
        /// </summary>
        /// <param name="AdaptiveAuthRequest">AdaptiveAuthRequest object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateAdaptiveAuth(AdaptiveAuthRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("AdaptiveAuthRequest", "Request cannot be empty.");
            }

            if (request.AdaptiveAuth == null)
            {
                throw new ArgumentNullException("AdaptiveAuth", "AdaptiveAuth cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/adaptiveauth", request.RealmId);

            return this._apiClient.Patch<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Enable and configure the realm's multi-factor authentication 
        /// methods used by end-users during login. 
        /// </summary>
        /// <param name="MultifactorRequest">MultifactorRequest object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateMultifactor(MultifactorRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("MultifactorRequest", "Request cannot be empty.");
            }

            if (request.MultiFactor == null)
            {
                throw new ArgumentNullException("MultiFactor", "MultiFactor cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/multifactor", request.RealmId);

            return this._apiClient.Patch<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Configure the realm's post authentication settings for 
        /// a SAML assertion or WS-Federation assertion.
        /// </summary>
        /// <param name="PostAuthRequest">PostAuthRequest object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdatePostAuth(PostAuthRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("PostAuthRequest", "Request cannot be empty.");
            }

            if (request.PostAuth == null)
            {
                throw new ArgumentNullException("PostAuth", "PostAuth cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/postauth", request.RealmId);

            return this._apiClient.Patch<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Configure the realm's logs settings, including audit, debug, 
        /// and error log enablement; and Syslog and database configuration.
        /// </summary>
        /// <param name="LogSettingRequest">LogSettingRequest object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateLogSettings(LogSettingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("LogSettingRequest", "Request cannot be empty.");
            }

            if (request.LogSetting == null)
            {
                throw new ArgumentNullException("LogSetting", "LogSetting cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/logsettings", request.RealmId);

            return this._apiClient.Patch<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Enable SecureAuth IdP APIs in the realm, 
        /// including Authentication APIs and Identity Management APIs.
        /// </summary>
        /// <param name="ApiSettingRequest">ApiSettingRequest object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateApi(ApiSettingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("ApiSettingRequest", "Request cannot be empty.");
            }

            if (request.ApiSetting == null)
            {
                throw new ArgumentNullException("ApiSetting", "ApiSetting cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/apisettings", request.RealmId);

            return this._apiClient.Patch<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Generate API Credentials for a given 
        /// given realm Id.
        /// </summary>
        /// <param name="realmId">The Id number of the realm</param>
        /// <returns>RealmApiResponse</returns>
        public RealmApiResponse GenerateApiCredentials(string realmId)
        {
            string endpoint = string.Format("/api/v1/realms/{0}/apigeneratecredentials", realmId);

            return this._apiClient.Post<RealmApiResponse>(endpoint);
        }

        /// <summary>
        /// Retrieves a list of available carrier country, 
        /// codes, and names to block or allow
        /// </summary>
        /// <param name="realmId">The Id number of the realm</param>
        /// <returns>PhoneCarrierResponse</returns>
        public PhoneCarrierResponse GetPhoneCarriers(string realmId)
        {
            if (string.IsNullOrEmpty(realmId))
            {
                throw new ArgumentNullException("realmId", "Realm ID cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/phonecarriers", realmId);

            return this._apiClient.Get<PhoneCarrierResponse>(endpoint);
        }

        /// <summary>
        /// Uploads and updates image path associated with the
        /// logo image that appears on client-side login pages
        /// </summary>
        /// <param name="OverviewRequest">OverviewRequest object with CompanyLogoField populated</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UploadCompanyLogo(OverviewRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("OverviewRequest", "Request cannot be empty.");
            }

            if (request.Overview == null)
            {
                throw new ArgumentNullException("overview", "Overview cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.Overview.CompanyLogoFile))
            {
                throw new ArgumentNullException("CompanyLogoFile", "Company Logo File cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/overview/companylogo", request.RealmId);

            return this._apiClient.Post<BaseResponse>(endpoint, request);


        }

        /// <summary>
        /// Uploads and updates image path associated with the
        /// logo image that appears on the Secure Portal page that is associated to realm
        /// </summary>
        /// <param name="OverviewRequest">OverviewRequest object with ApplicationLogoField populated</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UploadApplicationLogo(OverviewRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("OverviewRequest", "Request cannot be empty.");
            }

            if (request.Overview == null)
            {
                throw new ArgumentNullException("overview", "Overview cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.Overview.ApplicationLogoFile))
            {
                throw new ArgumentNullException("ApplicationLogoFile", "Application Logo File cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/overview/applicationlogo", request.RealmId);

            return this._apiClient.Post<BaseResponse>(endpoint, request);


        }

        /// <summary>
        /// Uploads and updates image path associated with the
        /// logo image that appears on SecureAuth emails
        /// </summary>
        /// <param name="OverviewRequest">OverviewRequest object with Email.LogoFile populated</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UploadEmailLogo(OverviewRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("OverviewRequest", "Request cannot be empty.");
            }

            if (request.Overview == null)
            {
                throw new ArgumentNullException("overview", "Overview cannot be empty.");
            }

            if (request.Overview.Email == null)
            {
                throw new ArgumentNullException("email", "Email cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.RealmId))
            {
                throw new ArgumentNullException("RealmId", "Realm Id cannot be empty.");
            }

            if (string.IsNullOrEmpty(request.Overview.Email.LogoFile))
            {
                throw new ArgumentNullException("EmailLogoFile", "Email Logo File cannot be empty.");
            }

            string endpoint;

            endpoint = string.Format("/api/v1/realms/{0}/overview/emaillogo", request.RealmId);

            return this._apiClient.Post<BaseResponse>(endpoint, request);
        }
    }
 }
