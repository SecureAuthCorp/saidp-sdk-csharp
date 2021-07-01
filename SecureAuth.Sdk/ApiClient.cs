using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace SecureAuth.Sdk
{
    public class ApiClient
    {
        #region Private Members
        private Configuration Configuration { get; set; }
        #endregion

        #region Properties
        internal string AppId
        {
            get { return this.Configuration.AppId; }
        }

        internal string AppKey
        {
            get { return this.Configuration.AppKey; }
        }

        internal string SecureAuthRealmUrl
        {
            get { return this.Configuration.SecureAuthRealmUrl; }
        }

        #endregion

        #region Constructors
        internal ApiClient(Configuration configuration)
        {
            this.Configuration = configuration;

            if (configuration.BypassCertValidation)
            {
                ServicePointManager.ServerCertificateValidationCallback = new
                System.Net.Security.RemoteCertificateValidationCallback
                (
                   delegate { return true; }
                );
            }
        }
        #endregion

        #region Methods
        internal T Get<T>(string apiEndpoint) where T : BaseResponse
        {
            string rawResult = string.Empty;
            HttpStatusCode statusCode;
            string ingressCookie = "";
            string requestUrl = string.Concat(this.SecureAuthRealmUrl, apiEndpoint);
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HmacSigningHandler(this.AppId, this.AppKey);
            handler.CookieContainer = cookies;

            // Process HTTP request
            using (HttpClient client = new HttpClient(handler))
            {
                var response = client.GetAsync(requestUrl).Result;
                statusCode = response.StatusCode;
                
                //Ingress cookie for stateful requests
                Uri uri = new Uri(this.SecureAuthRealmUrl);
                IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();

                foreach (Cookie cookie in responseCookies)
                    if (cookie.Name == "INGRESSCOOKIE")
                        ingressCookie = cookie.Value;
                rawResult = response.Content.ReadAsStringAsync().Result;
            }

            // Deserialize the response
            var result = JsonSerializer.Deserialize<T>(rawResult);

            // Set HTTP status code and return
            ((BaseResponse) result).StatusCode = statusCode;
            ((BaseResponse) result).RawJson = rawResult;
            return result;
        }

        internal T GetStateful<T>(string apiEndpoint, string ingressCookie) where T : BaseResponse
        {
            string rawResult = string.Empty;
            HttpStatusCode statusCode;
            string requestUrl = string.Concat(this.SecureAuthRealmUrl, apiEndpoint);
            CookieContainer cookieContainer = new CookieContainer();
            HttpClientHandler handler = new HmacSigningHandler(this.AppId, this.AppKey);
            handler.CookieContainer = cookieContainer;

            // Process HTTP request
            using (HttpClient client = new HttpClient(handler))
            {
                //Send Ingress cookie for stateful requests
                Uri uri = new Uri(apiEndpoint);
                cookieContainer.Add(uri, new Cookie("INGRESSCOOKIE", ingressCookie));
                var response = client.GetAsync(requestUrl).Result;
                statusCode = response.StatusCode;

                rawResult = response.Content.ReadAsStringAsync().Result;
            }

            // Deserialize the response
            var result = JsonSerializer.Deserialize<T>(rawResult);

            // Set HTTP status code and return
            ((BaseResponse)result).StatusCode = statusCode;
            ((BaseResponse)result).RawJson = rawResult;
            return result;
        }

        internal T Post<T>(string apiEndpoint, BaseRequest request = null) 
            where T : BaseResponse
        {
            string rawResult = string.Empty;
            string rawRequest = string.Empty;
            HttpStatusCode statusCode;
            string ingressCookie = "";
            string requestUrl = string.Concat(this.SecureAuthRealmUrl, apiEndpoint);
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HmacSigningHandler(this.AppId, this.AppKey);
            handler.CookieContainer = cookies;

            // Process HTTP request
            using (HttpClient client = new HttpClient(handler))
            {
                if (request != null)
                {
                    rawRequest = JsonSerializer.Serialize(request);
                }           
                HttpContent content = new StringContent(rawRequest, Encoding.UTF8, "application/json");
                var response = client.PostAsync(requestUrl, content).Result;
                statusCode = response.StatusCode;

                //Ingress cookie for stateful requests
                Uri uri = new Uri(this.SecureAuthRealmUrl);
                IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();

                foreach (Cookie cookie in responseCookies)
                    if (cookie.Name == "INGRESSCOOKIE")
                        ingressCookie = cookie.Value;

                rawResult = response.Content.ReadAsStringAsync().Result;
            }

            // Deserialize the response
            var result = JsonSerializer.Deserialize<T>(rawResult);

            // Set HTTP status code and return
            ((BaseResponse)result).StatusCode = statusCode;
            ((BaseResponse)result).RawJson = rawResult;
            ((BaseResponse)result).RawRequestJson = rawRequest;
            ((BaseResponse)result).IngressCookie = ingressCookie;
            return result;
        }

        internal T Put<T>(string apiEndpoint, BaseRequest request = null)
            where T : BaseResponse
        {
            string rawResult = string.Empty;
            string rawRequest = string.Empty;
            HttpStatusCode statusCode;
            string requestUrl = string.Concat(this.SecureAuthRealmUrl, apiEndpoint);

            // Process HTTP request
            using (HttpClient client = new HttpClient(new HmacSigningHandler(this.AppId, this.AppKey)))
            {
                if (request != null)
                {
                    rawRequest = JsonSerializer.Serialize(request);
                }
                HttpContent content = new StringContent(rawRequest, Encoding.UTF8, "application/json");
                var response = client.PutAsync(requestUrl, content).Result;
                statusCode = response.StatusCode;

                rawResult = response.Content.ReadAsStringAsync().Result;
            }

            // Deserialize the response
            var result = JsonSerializer.Deserialize<T>(rawResult);

            // Set HTTP status code and return
            ((BaseResponse)result).StatusCode = statusCode;
            ((BaseResponse)result).RawJson = rawResult;
            ((BaseResponse)result).RawRequestJson = rawRequest;
            return result;
        }
        #endregion
    }
}
