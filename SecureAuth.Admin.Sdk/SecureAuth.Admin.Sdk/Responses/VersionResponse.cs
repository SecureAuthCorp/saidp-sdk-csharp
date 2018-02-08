using System.Net;

namespace SecureAuth.Admin.Sdk
{
    public class VersionResponse : BaseResponse
    {
        public Models.AssemblyVersion Version { get; set; }

        public override bool IsSucess()
        {
            return ((this.StatusCode == HttpStatusCode.OK));
        }
    }
}
