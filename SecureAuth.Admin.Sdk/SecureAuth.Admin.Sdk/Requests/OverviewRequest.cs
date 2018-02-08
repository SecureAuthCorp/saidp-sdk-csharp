namespace SecureAuth.Admin.Sdk
{
    public class OverviewRequest : BaseRequest
    {
        public Models.Overview Overview { get; set; }

        public OverviewRequest()
        {
            Overview = new Models.Overview();            
        }
    }
}
