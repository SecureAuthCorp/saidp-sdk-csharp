using System.Runtime.Serialization;

namespace SecureAuth.Admin.Sdk.Models
{
    public class Realm
    {
        public int Id { get; set; }
        public Overview Overview { get; set; }
        public Data Data { get; set; }
        public Workflow Workflow { get; set; }
        public AdaptiveAuthentication AdaptiveAuthentication { get; set; }
        public MultiFactor MultiFactor { get; set; }
        public PostAuthentication PostAuthentication { get; set; }
        public ApiSetting ApiSetting { get; set; }
        public LogSetting LogSetting { get; set; }
    }
}
