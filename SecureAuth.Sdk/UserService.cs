using System;
using System.Collections.Generic;

namespace SecureAuth.Sdk
{
    public class UserService : IUserService
    {
        private readonly ApiClient _apiClient;
        private string apiVersion = "v1";

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
        public GetFactorsResponse GetFactors(string userId, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/factors", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}/factors", domain, userId);
            }

            return this._apiClient.Get<GetFactorsResponse>(endpoint);
        }

        public GetFactorsResponse GetUserFactorsQueryString(string userId, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            string parameters = "?username="+ userId;
            string endpoint;

          
            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/factors{0}", parameters);
            }
            else
            {
                parameters = parameters + "&domain=" + domain;
                endpoint = string.Format("/api/" + apiVersion + "/users/factors{0}", parameters);
            }

            return this._apiClient.Get<GetFactorsResponse>(endpoint);
        }

        /// <summary>
        /// Retrieve user profile data for the 
        /// given User ID
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <returns>GetUserProfileResponse</returns>
        public GetUserProfileResponse GetUserProfile(string userId, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}", domain, userId);
            }

            return this._apiClient.Get<GetUserProfileResponse>(endpoint);
        }

        /// <summary>
        /// Update an existing user's profile for the
        /// given User ID
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The update profile request</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateUserProfile(string userId, UpdateUserProfileRequest request, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}", domain, userId);
            }            

            return this._apiClient.Post<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Create user account with profile data and password
        /// </summary>
        /// <param name="request">Create user request</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse CreateUser(CreateUserRequest request)
        {
            return this._apiClient.Post<BaseResponse>("/api/" + apiVersion + "/users", request);
        }

        /// <summary>
        /// Self-service change password when both current
        /// and new passwords are known
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The change password request</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ChangePassword(string userId, ChangePasswordRequest request, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}", domain, userId);
            }

            return this._apiClient.Post<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Administrative reset password when only the 
        /// new password is known
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The reset password request</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ResetPassword(string userId, ResetPasswordRequest request, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/resetpwd", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}/resetpwd", domain, userId);
            }

            return this._apiClient.Post<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Associate a user and group. This implies LDAP has
        /// been configured as the SecureAuth realm's datastore
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="groupName">The LDAP group name.</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse AddUserToGroup(string userId, string groupName, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException("groupName", "Group name cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/groups/{1}", userId, Uri.EscapeDataString(groupName));
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}/groups/{2}", domain, userId, Uri.EscapeDataString(groupName));
            }

            return this._apiClient.Post<BaseResponse>(endpoint);
        }

        /// <summary>
        /// Associate a user with multiple groups. This implies
        /// LDAP has been configured as the SecureAuth realm's 
        /// datastore
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The LDAP group name.</param>
        /// <returns>BaseResponse</returns>
        public GroupAssociateResponse AddGroupsToUser(string userId, GroupAssociateRequest request, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/groups", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}/groups", domain, userId);
            }

            return this._apiClient.Post<GroupAssociateResponse>(endpoint, request);
        }

        public GroupAssociateResponse AddGroupsToUserQueryString(string userId, GroupAssociateRequest request, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            string endpoint;
            string param = "?username=" + userId;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/groups{0}", param);
            }
            else
            {
                param = param + "&domain=" + domain;
                endpoint = string.Format("/api/" + apiVersion + "/users/groups{0}", param);
            }

            return this._apiClient.Post<GroupAssociateResponse>(endpoint, request);
        }

        public BaseResponse AddUserToGroupQueryString(string groupName, string userId, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException("groupName", "Group name cannot be empty.");
            }

            string endpoint;
            string param = "?username=" + userId;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/groups/{0}/{1}", Uri.EscapeDataString(groupName), param);
            }
            else
            {
                param = param + "&domain=" + domain;
                endpoint = string.Format("/api/" + apiVersion + "/users/groups/{0}/{1}", Uri.EscapeDataString(groupName), domain, userId);
            }

            return this._apiClient.Post<BaseResponse>(endpoint);
        }

        /// <summary>
        /// Gets the current throttle count of a user for 2FA throttling.
        /// </summary>
        /// <param name="userId">The unique user ID</param>
        /// <returns>ThrottleResponse</returns>
        public ThrottleResponse GetThrottleCount(string userId, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/throttle", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}/throttle", domain, userId);
            }

            return this._apiClient.Get<ThrottleResponse>(endpoint);
        }

        /// <summary>
        /// Resets the current throttle count of a user for 2FA throttling.
        /// </summary>
        /// <param name="userId">The unique user ID</param>
        /// <returns>ThrottleResponse</returns>
        public ThrottleResponse ResetThrottleCount(string userId, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/throttle", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}/throttle", domain, userId);
            }

            return this._apiClient.Put<ThrottleResponse>(endpoint);
        }

        /// <summary>
        /// Gets the current throttle count of a user for OTP throttling.
        /// </summary>
        /// <param name="userId">The unique user ID</param>
        /// <returns>ThrottleResponse</returns>
        public ThrottleResponse GetOTPThrottleCount(string userId, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/otpvalidatethrottle", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}/otpvalidatethrottle", domain, userId);
            }

            return this._apiClient.Get<ThrottleResponse>(endpoint);
        }

        public UserStatusResponse GetUserStatus(string userId, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/status", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}/status", domain, userId);
            }

            return this._apiClient.Get<UserStatusResponse>(endpoint);
        }

        public BaseResponse SetUserStatus(string userId, SetUserStatusRequest request, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/status", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}/status", domain, userId);
            }

            return this._apiClient.Post<BaseResponse>(endpoint, request);
        }

        /// <summary>
        /// Resets the current throttle count of a user for OTP throttling.
        /// </summary>
        /// <param name="userId">The unique user ID</param>
        /// <returns>ThrottleResponse</returns>
        public ThrottleResponse ResetOTPThrottleCount(string userId, string domain = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId", "User ID cannot be empty.");
            }

            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/otpvalidatethrottle", userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/users/{0}/{1}/otpvalidatethrottle", domain, userId);
            }

            return this._apiClient.Put<ThrottleResponse>(endpoint);
        }
    }
}