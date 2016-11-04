using System.Web.Mvc;
using SACustomAPI.Utilities;
using SACustomAPI.Models;

namespace SACustomAPI.Controllers
{
    public class AuthorizedController : Controller
    {
        // GET: Authorized
        [CustomAuthorize]
        public virtual ActionResult Index()
        {
            AuthorizedViewModel model = new AuthorizedViewModel();
            return View(model);
        }
    }
}