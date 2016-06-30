namespace SecureAuth.Sdk.UnitTests
{
    public static class Constants
    {
        public static class ResponseStatus
        {
            public const string Valid = "valid";
            public const string Invalid = "invalid";
            public const string InvalidGroup = "invalid_group";
            public const string Found = "found";
            public const string NotFound = "not_found";
            public const string Disabled = "disabled";
            public const string LockOut = "lock_out";
            public const string PasswordExpired = "password_expired";
            public const string Verified = "verified";
            public const string ServerError = "server_error";
            public const string Success = "success";
            public const string Failed = "failed";
        }

        public static class DfpResponseStatus
        {
            public const string Found = "found";
            public const string FoundForUpdate = "found_for_update";
            public const string FoundWithIdMismatch = "found_with_id_mismatch";
            public const string NotFound = "not_found";
        }

        public static class FactorIds
        {
            public const string Email1 = "Email1";
            public const string Email2 = "Email2";
            public const string Email3 = "Email3";
            public const string Email4 = "Email4";
            public const string Phone1 = "Phone1";
            public const string Phone2 = "Phone2";
            public const string Phone3 = "Phone3";
            public const string Phone4 = "Phone4";
            public const string HelpDesk1 = "HelpDesk1";
            public const string HelpDesk2 = "HelpDesk2";
        }

        public static class SuggestedActions
        {
            public const string SecondFactorPassword = "2ndfactor_password";
            public const string SecondFactorOnly = "2ndfactor";
            public const string Password = "password";
            public const string Redirect = "redirect";
            public const string Stop = "stop";
            public const string None = "none";
        }

        public static class BehaveBioRespons
        {
            public const string ResetSent = "Reset sent to data store.";
            public const string UnabletoParse = "Unable to parse profile.";
            public const string ProfileNotUpdated = "Profile was not updated.";
            public const string FieldNotFound = "Field was not found in profile.";
        }        
    }
}
