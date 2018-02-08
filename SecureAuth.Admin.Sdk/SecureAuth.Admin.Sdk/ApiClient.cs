using System.Net;
using System.Net.Http;
using System.Text;

namespace SecureAuth.Admin.Sdk
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

        internal string SecureAuthUrl
        {
            get { return this.Configuration.SecureAuthUrl; }
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
            string requestUrl = string.Concat(this.SecureAuthUrl, apiEndpoint);

            // Process HTTP request
            using (HttpClient client = new HttpClient(new HmacSigningHandler(this.AppId, this.AppKey)))
            {
                var response = client.GetAsync(requestUrl).Result;
                statusCode = response.StatusCode;
                rawResult = response.Content.ReadAsStringAsync().Result;
            }

            // Deserialize the response
            var result = JsonSerializer.Deserialize<T>(rawResult);

            // Set HTTP status code and return
            ((BaseResponse) result).StatusCode = statusCode;
            ((BaseResponse) result).RawJson = rawResult;
            return result;
        }

        internal T Post<T>(string apiEndpoint, BaseRequest request = null) 
            where T : BaseResponse
        {
            string rawResult = string.Empty;
            string rawRequest = string.Empty;
            HttpStatusCode statusCode;
            string requestUrl = string.Concat(this.SecureAuthUrl, apiEndpoint);
            
            // Process HTTP request
            using (HttpClient client = new HttpClient(new HmacSigningHandler(this.AppId, this.AppKey)))
            {
                if (request != null)
                {
                    rawRequest = JsonSerializer.Serialize(request);
                }
                HttpContent content = new StringContent(rawRequest, Encoding.UTF8, "application/json");
                var response = client.PostAsync(requestUrl, content).Result;
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

        internal T Put<T>(string apiEndpoint, BaseRequest request = null)
            where T : BaseResponse
        {
            string rawResult = string.Empty;
            string rawRequest = string.Empty;
            HttpStatusCode statusCode;
            string requestUrl = string.Concat(this.SecureAuthUrl, apiEndpoint);

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

        internal T Patch<T>(string apiEndpoint, BaseRequest request = null)
            where T : BaseResponse
        {
            string rawResult = string.Empty;
            string rawRequest = string.Empty;
            HttpStatusCode statusCode;
            string requestUrl = string.Concat(this.SecureAuthUrl, apiEndpoint);

            // Process HTTP request
            using (HttpClient client = new HttpClient(new HmacSigningHandler(this.AppId, this.AppKey)))
            {
                var method = new HttpMethod("PATCH");

                if (request != null)
                {
                    rawRequest = JsonSerializer.Serialize(request);
                }

                var httpRequest = new HttpRequestMessage(method, requestUrl)
                {
                    Content = new StringContent(rawRequest, Encoding.UTF8, "application/json")
                };

                var taskResponse = client.SendAsync(httpRequest);
                var response = taskResponse.Result;

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
