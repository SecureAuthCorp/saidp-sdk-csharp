using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace SACustomAPI
{
	public static class SAAuthentication
    {
        public const string ApplicationCookie = "SAAuthType";
    }

	public partial class Startup
	{
        public void ConfigureAuth(IAppBuilder app)
        {
            // need to add UserManager into owin, because this is used in cookie invalidation
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = SAAuthentication.ApplicationCookie,
                LoginPath = new PathString("/Login"),
                Provider = new CookieAuthenticationProvider(),
                CookieName = "saauth",
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromHours(1), // adjust to your needs
            });
        }
    }
}