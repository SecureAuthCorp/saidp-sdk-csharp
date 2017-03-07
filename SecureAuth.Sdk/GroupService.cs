using System;

namespace SecureAuth.Sdk
{
    public class GroupService : IGroupService
    {
        private readonly ApiClient _apiClient;

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
        public BaseResponse AddUserToGroup(string groupName, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException("groupName", "Group name cannot be empty.");
            }

            return this._apiClient.Post<BaseResponse>(string.Format("/api/v1/groups/{0}/users/{1}", Uri.EscapeDataString(groupName), userId));
        }

        /// <summary>
        /// Associate a group with multiple users. This implies
        /// LDAP has been configured as the SecureAuth realm's 
        /// datastore
        /// </summary>
        /// <param name="groupName">The unique group name.</param>
        /// <param name="request">GroupAssociateRequest</param>
        /// <returns>BaseResponse</returns>
        public GroupAssociateResponse AddGroupsToUser(string groupName, GroupAssociateRequest request)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException("groupName", "Group name cannot be empty.");
            }

            return this._apiClient.Post<GroupAssociateResponse>(string.Format("/api/v1/groups/{0}/users", groupName), request);
        }
    }
}
