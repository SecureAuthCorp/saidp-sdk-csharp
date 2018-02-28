namespace SecureAuth.Admin.Sdk
{
    public class WorkflowRequest : BaseRequest
    {
        public Models.Workflow Workflow { get; set; }

        public WorkflowRequest()
        {
            Workflow = new Models.Workflow();
        }
    }
}
