using SACustomAPI.Utilities;

namespace SACustomAPI.Models
{
    public class HardstopViewModel
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