using SACustomAPI.Utilities;

namespace SACustomAPI.Models
{
    public class AuthorizedViewModel
    {
        public ApiJson apiJson
        {
            get
            {
                return SessionBag.Current.JsonModel;
            }
        }
    }
}