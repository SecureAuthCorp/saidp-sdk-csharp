namespace SecureAuth.Sdk
{
    public interface IUserService
    {
        GetFactorsResponse GetFactors(string userId);
        GetUserProfileResponse GetUserProfile(string userId);
        BaseResponse UpdateUserProfile(string userId, UpdateUserProfileRequest request);
        BaseResponse CreateUser(CreateUserRequest request);
        BaseResponse ChangePassword(string userId, ChangePasswordRequest request);
        BaseResponse ResetPassword(string userId, ResetPasswordRequest request);
        BaseResponse AddGroupToUser(string userId, string groupName);
        GroupAssociateResponse AddGroupsToUser(string userId, GroupAssociateRequest request);
        ThrottleResponse GetThrottleCount(string userId);
        ThrottleResponse ResetThrottleCount(string userId);
    }
}
