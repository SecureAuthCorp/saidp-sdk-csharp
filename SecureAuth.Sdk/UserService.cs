using System;

namespace SecureAuth.Sdk
{
    public class UserService : IUserService
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

        /// <summary>
        /// Retrieve user profile data for the 
        /// given User ID
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <returns>GetUserProfileResponse</returns>
        public GetUserProfileResponse GetUserProfile(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            return this._apiClient.Get<GetUserProfileResponse>(string.Format("/api/v1/users/{0}", userId));
        }

        /// <summary>
        /// Update an existing user's profile for the
        /// given User ID
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The update profile request</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateUserProfile(string userId, UpdateUserProfileRequest request)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            return this._apiClient.Post<BaseResponse>(string.Format("/api/v1/users/{0}", userId), request);
        }

        /// <summary>
        /// Create user account with profile data and password
        /// </summary>
        /// <param name="request">Create user request</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse CreateUser(CreateUserRequest request)
        {
            return this._apiClient.Post<BaseResponse>("/api/v1/users", request);
        }

        /// <summary>
        /// Self-service change password when both current
        /// and new passwords are known
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The change password request</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ChangePassword(string userId, ChangePasswordRequest request)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            return this._apiClient.Post<BaseResponse>(string.Format("/api/v1/users/{0}/changepwd", userId), request);
        }

        /// <summary>
        /// Administrative reset password when only the 
        /// new password is known
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The reset password request</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse ResetPassword(string userId, ResetPasswordRequest request)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            return this._apiClient.Post<BaseResponse>(string.Format("/api/v1/users/{0}/resetpwd", userId), request);
        }

        /// <summary>
        /// Associate a user and group. This implies LDAP has
        /// been configured as the SecureAuth realm's datastore
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="groupName">The LDAP group name.</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse AddGroupToUser(string userId, string groupName)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException("groupName", "Group name cannot be empty.");
            }

            return this._apiClient.Post<BaseResponse>(string.Format("/api/v1/users/{0}/groups/{1}", userId, Uri.EscapeDataString(groupName)));
        }

        /// <summary>
        /// Associate a user with multiple groups. This implies
        /// LDAP has been configured as the SecureAuth realm's 
        /// datastore
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The LDAP group name.</param>
        /// <returns>BaseResponse</returns>
        public GroupAssociateResponse AddGroupsToUser(string userId, GroupAssociateRequest request)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

            return this._apiClient.Post<GroupAssociateResponse>(string.Format("/api/v1/users/{0}/groups", userId), request);
        }

        /// <summary>
        /// Gets the current throttle count of a user for 2FA throttling.
        /// </summary>
        /// <param name="userId">The unique user ID</param>
        /// <returns>ThrottleResponse</returns>
        public ThrottleResponse GetThrottleCount(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId", "User ID cannot be empty.");
            }

            return this._apiClient.Get<ThrottleResponse>(string.Format("/api/v1/users/{0}/throttle", userId));
        }

        /// <summary>
        /// Resets the current throttle count of a user for 2FA throttling.
        /// </summary>
        /// <param name="userId">The unique user ID</param>
        /// <returns>ThrottleResponse</returns>
        public ThrottleResponse ResetThrottleCount(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId", "User ID cannot be empty.");
            }

            return this._apiClient.Put<ThrottleResponse>(string.Format("/api/v1/users/{0}/throttle", userId));
        }
    }
}