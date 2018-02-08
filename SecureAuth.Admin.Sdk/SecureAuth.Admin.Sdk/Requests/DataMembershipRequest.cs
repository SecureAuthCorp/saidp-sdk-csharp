namespace SecureAuth.Admin.Sdk
{
    public class DataMembershipRequest : BaseRequest
    {
        public Models.Membership Membership { get; set; }

        public DataMembershipRequest()
        {
            Membership = new Models.Membership();
        }
    }
}
