namespace SecureAuth.Admin.Sdk
{
    public class DataGlobalAuxRequest : BaseRequest
    {
        public Models.Data Data { get; set; }

        public DataGlobalAuxRequest()
        {
            Data = new Models.Data();
        }
    }
}
