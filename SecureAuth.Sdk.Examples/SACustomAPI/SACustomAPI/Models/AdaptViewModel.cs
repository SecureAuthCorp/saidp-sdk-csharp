using SACustomAPI.Utilities;

namespace SACustomAPI.Models
{
    public class AdaptViewModel
    {
        public string actionRedirect { get; set; }

        public string outsideRedirect { get; set; }

        public string localRedirect { get; set; }

        public string routeRedirect { get; set; }

        public ApiJson apiJson
        {
            get
            {
                return SessionBag.Current.JsonModel;
            }
        }
    }
}