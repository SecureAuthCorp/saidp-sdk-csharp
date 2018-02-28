namespace SecureAuth.Admin.Sdk.Models
{
    public class TerminationPoint
    {
        public string ClientFqdn { get; set; }
        public string SslTerminationCertificate { get; set; }
        public string SslCertificateAddress { get; set; }
        public string SslTerminationPoint { get; set; }
    }
}