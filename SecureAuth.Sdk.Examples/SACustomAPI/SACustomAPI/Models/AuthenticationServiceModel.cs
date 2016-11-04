using Microsoft.Owin.Security;
using SecureAuth.Sdk;
using System;
using System.Security.Claims;

namespace SACustomAPI.Models
{
    public class AuthenticationServiceModel
    {
        public class AuthenticationResult
        {
            public AuthenticationResult(string errorMessage = null)
            {
                ErrorMessage = errorMessage;
            }

            public string ErrorMessage { get; private set; }
            public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage);
        }

        private readonly IAuthenticationManager authenticationManager;

        public AuthenticationServiceModel(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        public AuthenticationResult SignIn (string username, string password)
        { 
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            ValidatePasswordRequest passwordRequest = new ValidatePasswordRequest(username, password);
            BaseResponse passwordResponse = saService.Authenticate.ValidatePassword(passwordRequest);
            passwordResponse.SetRequestResponseModel("pwd");
            if (passwordResponse.Status != "valid")
            {
                return new AuthenticationResult(passwordResponse.Message);
            }

            GetUserProfileResponse profileResponse = saService.User.GetUserProfile(username);
            profileResponse.SetRequestResponseModel("profile");
            var identity = CreateIdentity(profileResponse);

            authenticationManager.SignOut(SAAuthentication.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);
            return new AuthenticationResult();
        }

        public ClaimsIdentity CreateIdentity(GetUserProfileResponse profile)
        {
            var identity = new ClaimsIdentity(SAAuthentication.ApplicationCookie, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "SecureAuth IdP"));
            identity.AddClaim(new Claim(ClaimTypes.Name, profile.UserId));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, profile.UserId));
            string email = profile.Properties["email1"].Value;
            if (!String.IsNullOrWhiteSpace(email))
            {
                identity.AddClaim(new Claim(ClaimTypes.Email, email));
            }

            return identity;
        }
    }
}