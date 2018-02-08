
namespace SecureAuth.Admin.Sdk.Models.v2
{
    public class UserRiskProvider
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string ProfileRelativeUrl { get; set; }
        public string AuthenticationMethod { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CookieUrl { get; set; }
        public string RequestIdField { get; set; }
        public string RequestJson { get; set; }
        public string RiskScoreJsonPath { get; set; }
        public int? RangeMax { get; set; }
        public int? RangeMin { get; set; }
        public int? HighRisk { get; set; }
        public int? MediumRisk { get; set; }
        public bool? DeleteProvider { get; set; }
        public bool? Enabled { get; set; }
        public bool? IsFixedConnectionSetting { get; set; }

        public bool ShouldSerializeDeleteProvider()
        {
            return false;
        }
    }
}
