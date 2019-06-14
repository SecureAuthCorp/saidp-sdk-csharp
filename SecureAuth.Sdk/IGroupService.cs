namespace SecureAuth.Sdk
{
    public interface IGroupService
    {
        BaseResponse AddUserToGroup(string groupName, string userId);
        GroupAssociateResponse AddGroupsToUser(string groupName, GroupAssociateRequest request);
    }
}
