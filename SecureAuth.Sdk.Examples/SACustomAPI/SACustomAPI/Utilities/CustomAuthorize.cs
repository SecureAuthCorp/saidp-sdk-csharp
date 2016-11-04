using System.Web;
using System.Web.Mvc;
using SACustomAPI.Models;

namespace SACustomAPI.Utilities
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // the user is not authenticated or the forms authentication
                // cookie has expired
                return false;
            }

            AuthorizeEnum.State state = 0x0;

            Persona persona = SessionBag.Current.Persona;
            
            if (persona != null)
            {
                state = persona.AuthState;
            }
            switch (state)
            {
                case AuthorizeEnum.State.Index:
                    if (httpContext.Request.RequestContext.RouteData.Values["action"].ToString() == "Adapt" || httpContext.Request.RequestContext.RouteData.Values["action"].ToString() == "Index")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case AuthorizeEnum.State.Index | AuthorizeEnum.State.Adapt:
                    if (httpContext.Request.RequestContext.RouteData.Values["action"].ToString() == "Select" || httpContext.Request.RequestContext.RouteData.Values["action"].ToString() == "Adapt")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case AuthorizeEnum.State.Index | AuthorizeEnum.State.Adapt | AuthorizeEnum.State.Select:
                    if (httpContext.Request.RequestContext.RouteData.Values["action"].ToString() == "Otp" || httpContext.Request.RequestContext.RouteData.Values["action"].ToString() == "Select")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case AuthorizeEnum.State.Index | AuthorizeEnum.State.Adapt | AuthorizeEnum.State.Select | AuthorizeEnum.State.Otp:
                    return true;
                default:
                    return false;
            }
        }
    }
}