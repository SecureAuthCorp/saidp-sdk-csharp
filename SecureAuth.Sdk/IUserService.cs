using SecureAuth.Sdk.Models;

namespace SecureAuth.Sdk
{
    public interface IUserService
    {
        GetFactorsResponse GetFactors(string userId,  bool errorOnAccountStatus = false, string domain = "");
        GetUserProfileResponse GetUserProfile(string userId, string domain = "");
        BaseResponse UpdateUserProfile(string userId, UpdateUserProfileRequest request, string domain = "");
        BaseResponse CreateUser(CreateUserRequest request);
        BaseResponse ChangePassword(string userId, ChangePasswordRequest request, string domain = "");
        BaseResponse ResetPassword(string userId, ResetPasswordRequest request, string domain = "", bool errorOnAccountStatus = false);
        BaseResponse AddUserToGroup(string userId, string groupName, string domain = "");
        GroupAssociateResponse AddGroupsToUser(string userId, GroupAssociateRequest request, string domain = "");
        ThrottleResponse GetThrottleCount(string userId, string domain = "");
        ThrottleResponse ResetThrottleCount(string userId, string domain = "");
        ThrottleResponse GetOTPThrottleCount(string userId, string domain = "");
        ThrottleResponse ResetOTPThrottleCount(string userId, string domain = "");
        GetFactorsResponse GetUserFactorsQueryString(string userId, string domain = "");
        GroupAssociateResponse AddGroupsToUserQueryString(string userId, GroupAssociateRequest request, string domain = "");
        BaseResponse AddUserToGroupQueryString(string groupName, string userId, string domain = "");
        UserStatusResponse GetUserStatus(string userId, string domain = "");
        BaseResponse SetUserStatus(string userId, SetUserStatusRequest request, string domain = "");
    }
}
