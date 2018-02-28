namespace SecureAuth.Admin.Sdk.Models
{
    public class Oath
    {
        public bool? Enabled { get; set; }
        public int? PasscodeLength { get; set; }
        public int? PasscodeChangeInterval { get; set; }
        public int? PasscodeOffset { get; set; }
        public int? CacheLockoutDuration { get; set; }
    }
}
