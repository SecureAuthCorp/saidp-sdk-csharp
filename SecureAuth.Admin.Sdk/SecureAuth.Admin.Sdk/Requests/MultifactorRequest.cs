namespace SecureAuth.Admin.Sdk
{
    public class MultifactorRequest : BaseRequest
    {
        public Models.MultiFactor MultiFactor { get; set; }

        public MultifactorRequest()
        {
            MultiFactor = new Models.MultiFactor();
        }
    }
}
