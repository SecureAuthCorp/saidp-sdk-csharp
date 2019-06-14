using System;

namespace SecureAuth.Sdk
{
<<<<<<< HEAD
    public class UserService
=======
    public class UserService : IUserService
>>>>>>> 767840d... updates for .net core and language helper function
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
<<<<<<< HEAD
        public GetFactorsResponse GetFactors(string userId)
=======
        public GetFactorsResponse GetFactors(string userId, string domain = "")
>>>>>>> 767840d... updates for .net core and language helper function
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

<<<<<<< HEAD
            return this._apiClient.Get<GetFactorsResponse>(string.Format("/api/v1/users/{0}/factors", userId));
=======
            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/v1/users/{0}/factors", userId);
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}/factors", domain, userId);
            }

            return this._apiClient.Get<GetFactorsResponse>(endpoint);
>>>>>>> 767840d... updates for .net core and language helper function
        }

        /// <summary>
        /// Retrieve user profile data for the 
        /// given User ID
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <returns>GetUserProfileResponse</returns>
<<<<<<< HEAD
        public GetUserProfileResponse GetUserProfile(string userId)
=======
        public GetUserProfileResponse GetUserProfile(string userId, string domain = "")
>>>>>>> 767840d... updates for .net core and language helper function
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

<<<<<<< HEAD
            return this._apiClient.Get<GetUserProfileResponse>(string.Format("/api/v1/users/{0}", userId));
=======
            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/v1/users/{0}", userId);
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}", domain, userId);
            }

            return this._apiClient.Get<GetUserProfileResponse>(endpoint);
>>>>>>> 767840d... updates for .net core and language helper function
        }

        /// <summary>
        /// Update an existing user's profile for the
        /// given User ID
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The update profile request</param>
        /// <returns>BaseResponse</returns>
<<<<<<< HEAD
        public BaseResponse UpdateUserProfile(string userId, UpdateUserProfileRequest request)
=======
        public BaseResponse UpdateUserProfile(string userId, UpdateUserProfileRequest request, string domain = "")
>>>>>>> 767840d... updates for .net core and language helper function
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

<<<<<<< HEAD
            return this._apiClient.Post<BaseResponse>(string.Format("/api/v1/users/{0}", userId), request);
=======
            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/v1/users/{0}", userId);
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}", domain, userId);
            }            

            return this._apiClient.Post<BaseResponse>(endpoint, request);
>>>>>>> 767840d... updates for .net core and language helper function
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
<<<<<<< HEAD
        public BaseResponse ChangePassword(string userId, ChangePasswordRequest request)
=======
        public BaseResponse ChangePassword(string userId, ChangePasswordRequest request, string domain = "")
>>>>>>> 767840d... updates for .net core and language helper function
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

<<<<<<< HEAD
            return this._apiClient.Post<BaseResponse>(string.Format("/api/v1/users/{0}/changepwd", userId), request);
=======
            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/v1/users/{0}", userId);
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}", domain, userId);
            }

            return this._apiClient.Post<BaseResponse>(endpoint, request);
>>>>>>> 767840d... updates for .net core and language helper function
        }

        /// <summary>
        /// Administrative reset password when only the 
        /// new password is known
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The reset password request</param>
        /// <returns>BaseResponse</returns>
<<<<<<< HEAD
        public BaseResponse ResetPassword(string userId, ResetPasswordRequest request)
=======
        public BaseResponse ResetPassword(string userId, ResetPasswordRequest request, string domain = "")
>>>>>>> 767840d... updates for .net core and language helper function
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

<<<<<<< HEAD
            return this._apiClient.Post<BaseResponse>(string.Format("/api/v1/users/{0}/resetpwd", userId), request);
=======
            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/v1/users/{0}/resetpwd", userId);
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}/resetpwd", domain, userId);
            }

            return this._apiClient.Post<BaseResponse>(endpoint, request);
>>>>>>> 767840d... updates for .net core and language helper function
        }

        /// <summary>
        /// Associate a user and group. This implies LDAP has
        /// been configured as the SecureAuth realm's datastore
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="groupName">The LDAP group name.</param>
        /// <returns>BaseResponse</returns>
<<<<<<< HEAD
        public BaseResponse AddGroupToUser(string userId, string groupName)
=======
        public BaseResponse AddGroupToUser(string userId, string groupName, string domain = "")
>>>>>>> 767840d... updates for .net core and language helper function
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException("groupName", "Group name cannot be empty.");
            }

<<<<<<< HEAD
            return this._apiClient.Post<BaseResponse>(string.Format("/api/v1/users/{0}/groups/{1}", userId, Uri.EscapeDataString(groupName)));
=======
            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/v1/users/{0}/groups/{1}", userId, Uri.EscapeDataString(groupName));
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}/groups/{2}", domain, userId, Uri.EscapeDataString(groupName));
            }

            return this._apiClient.Post<BaseResponse>(endpoint);
>>>>>>> 767840d... updates for .net core and language helper function
        }

        /// <summary>
        /// Associate a user with multiple groups. This implies
        /// LDAP has been configured as the SecureAuth realm's 
        /// datastore
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="request">The LDAP group name.</param>
        /// <returns>BaseResponse</returns>
<<<<<<< HEAD
        public GroupAssociateResponse AddGroupsToUser(string userId, GroupAssociateRequest request)
=======
        public GroupAssociateResponse AddGroupsToUser(string userId, GroupAssociateRequest request, string domain = "")
>>>>>>> 767840d... updates for .net core and language helper function
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }

<<<<<<< HEAD
            return this._apiClient.Post<GroupAssociateResponse>(string.Format("/api/v1/users/{0}/groups", userId), request);
=======
            string endpoint;

            if (string.IsNullOrEmpty(domain))
            {
                endpoint = string.Format("/api/v1/users/{0}/groups", userId);
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}/groups", domain, userId);
            }

            return this._apiClient.Post<GroupAssociateResponse>(endpoint, request);
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
                endpoint = string.Format("/api/v1/users/{0}/throttle", userId);
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}/throttle", domain, userId);
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
                endpoint = string.Format("/api/v1/users/{0}/throttle", userId);
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}/throttle", domain, userId);
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
                endpoint = string.Format("/api/v1/users/{0}/otpvalidatethrottle", userId);
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}/otpvalidatethrottle", domain, userId);
            }

            return this._apiClient.Get<ThrottleResponse>(endpoint);
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
                endpoint = string.Format("/api/v1/users/{0}/otpvalidatethrottle", userId);
            }
            else
            {
                endpoint = string.Format("/api/v1/users/{0}/{1}/otpvalidatethrottle", domain, userId);
            }

            return this._apiClient.Put<ThrottleResponse>(endpoint);
>>>>>>> 767840d... updates for .net core and language helper function
        }
    }
}