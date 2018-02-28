using System.Net.Http;

namespace SecureAuth.Admin.Sdk
{
    internal class HmacBasicAuthenticationHelper
    {
        internal static string BuildAuthorizationHeaderParameter(string appId, string appKey, HttpRequestMessage request)
        {
            string result = null;

            if (!string.IsNullOrEmpty(appKey))
            {
                var representation = BuildRequestRepresentation(appId, request);
                if (!string.IsNullOrEmpty(representation))
                {
                    result = HashTool.SHA256HashToBase64(appKey, representation);
                }
            }
            
            return result;
        }

        private static string BuildRequestRepresentation(string appId, HttpRequestMessage request)
        {
            string result = null;

            if (request.Headers.Date.HasValue)
            {
                var dateMillis = request.Headers.Date.Value.UtcDateTime.ToString("ddd, dd MMM yyyy HH:mm:ss.fff G\\MT");
                request.Headers.Add("X-SA-Ext-Date", dateMillis); // used in version 9.2+
                request.Headers.Remove("Date");
                var httpMethod = request.Method.Method;

                string uri = request.RequestUri.AbsolutePath;

                string content = null;
                if (request.Content != null)
                {
                    content = request.Content.ReadAsStringAsync().Result;
                }

                result = (string.IsNullOrEmpty(content)) ?
                    string.Join("\n", httpMethod, dateMillis, appId, uri) :
                    string.Join("\n", httpMethod, dateMillis, appId, uri, content);
            }

            return result;
        }
    }
}