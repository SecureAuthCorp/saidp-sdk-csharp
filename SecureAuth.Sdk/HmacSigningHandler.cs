using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecureAuth.Sdk
{
<<<<<<< HEAD
    public class HmacSigningHandler : WebRequestHandler
=======
    public class HmacSigningHandler : HttpClientHandler
>>>>>>> 767840d... updates for .net core and language helper function
    {
        public string AppId { get; set; }
        public string AppKey { get; set; }

        public HmacSigningHandler()
        {
        }

        public HmacSigningHandler(string appId, string appKey)
        {
            AppId = appId;
            AppKey = appKey;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            request.Headers.Date = new DateTimeOffset(DateTime.Now, DateTime.Now - DateTime.UtcNow);
=======
            DateTime inputTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            TimeSpan offsetTime = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now); //DateTime.Now - DateTime.UtcNow; //new TimeSpan(0);//

            request.Headers.Date = new DateTimeOffset(inputTime, offsetTime);
>>>>>>> 767840d... updates for .net core and language helper function
            var hash = HmacBasicAuthenticationHelper.BuildAuthorizationHeaderParameter(AppId, AppKey, request);

            var headerValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", AppId, hash)));
            var header = new AuthenticationHeaderValue("Basic", headerValue);

            request.Headers.Authorization = header;

            return base.SendAsync(request, cancellationToken);
        }
    }
}