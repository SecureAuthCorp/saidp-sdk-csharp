using System;

namespace SecureAuth.Sdk
{
    public class GroupService : IGroupService
    {
        private readonly ApiClient _apiClient;
        private string apiVersion = "v2";

        protected internal GroupService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        /// <summary>
        /// Associate a user and group. This implies LDAP has
        /// been configured as the SecureAuth realm's datastore
        /// </summary>
        /// <param name="groupName">The LDAP group name.</param>
        /// <param name="userId">The unique user ID.</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse AddUserToGroup(string groupName, string userId, string domain = "")
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
                endpoint = string.Format("/api/" + apiVersion + "/groups/{0}/users/{1}", Uri.EscapeDataString(groupName), userId);
            }
            else
            {
                endpoint = string.Format("/api/" + apiVersion + "/groups/{0}/users/{1}/{2}", Uri.EscapeDataString(groupName), domain, userId);
            }

            return this._apiClient.Post<BaseResponse>(endpoint);
        }

        /// <summary>
        /// Associate a group with multiple users. This implies
        /// LDAP has been configured as the SecureAuth realm's 
        /// datastore
        /// </summary>
        /// <param name="groupName">The unique group name.</param>
        /// <param name="request">GroupAssociateRequest</param>
        /// <returns>BaseResponse</returns>
        public GroupAssociateResponse AddUsersToGroup(string groupName, GroupAssociateRequest request)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException("groupName", "Group name cannot be empty.");
            }

            return this._apiClient.Post<GroupAssociateResponse>(string.Format("/api/" + apiVersion + "/groups/{0}/users", groupName), request);
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
                endpoint = string.Format("/api/" + apiVersion + "/groups/{0}/users{1}", Uri.EscapeDataString(groupName), param);
            }
            else
            {
                param = param + "&domain=" + domain;
                endpoint = string.Format("/api/" + apiVersion + "/groups/{0}/users{1}", Uri.EscapeDataString(groupName), param);
            }

            return this._apiClient.Post<BaseResponse>(endpoint);
        }
    }
}
