namespace SecureAuth.Sdk
{
    public interface IGroupService
    {
        BaseResponse AddUserToGroup(string groupName, string userId, string domain = "");
        GroupAssociateResponse AddUsersToGroup(string groupName, GroupAssociateRequest request);
        BaseResponse AddUserToGroupQueryString(string groupName, string userId, string domain = "");
    }
}
