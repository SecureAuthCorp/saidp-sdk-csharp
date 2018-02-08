namespace SecureAuth.Admin.Sdk.Models
{
    public class Smtp
    {
        public string ServerAddress { get; set; }
        public int? Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public bool? UseSsl { get; set; }
    }
}
