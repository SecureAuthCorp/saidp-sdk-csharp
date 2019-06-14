using System.Net;
using System.Net.Http;
using System.Text;
<<<<<<< HEAD
=======
using SecureAuth.Sdk.Models;
>>>>>>> 767840d... updates for .net core and language helper function

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
<<<<<<< HEAD
=======

>>>>>>> 767840d... updates for .net core and language helper function
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
<<<<<<< HEAD
            string requestUrl = string.Concat(this.SecureAuthRealmUrl, apiEndpoint);

            // Process HTTP request
            using (HttpClient client = new HttpClient(new HmacSigningHandler(this.AppId, this.AppKey)))
            {
                var response = client.GetAsync(requestUrl).Result;
                statusCode = response.StatusCode;

                rawResult = response.Content.ReadAsStringAsync().Result;
=======
            string requestUrl = string.Concat(this.SecureAuthRealmUrl, apiEndpoint);

            // Process HTTP request
            using (var hmacSigningHandler = new HmacSigningHandler(this.AppId, this.AppKey))
            {
                hmacSigningHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (HttpClient client = new HttpClient(hmacSigningHandler))
                {

                    var response = client.GetAsync(requestUrl).Result;
                    statusCode = response.StatusCode;
                    rawResult = response.Content.ReadAsStringAsync().Result;
                }
            }

            // Deserialize the response
            var result = JsonSerializer.Deserialize<T>(rawResult);

            // Set HTTP status code and return
            ((BaseResponse) result).StatusCode = statusCode;
            ((BaseResponse) result).RawJson = rawResult;
            return result;
        }

        internal T Post<T>(string apiEndpoint, BaseRequest request = null, LanguageEnum langDescription = LanguageEnum.English) 
            where T : BaseResponse
        {
            string rawResult = string.Empty;
            string rawRequest = string.Empty;
            HttpStatusCode statusCode;
            string requestUrl = string.Concat(this.SecureAuthRealmUrl, apiEndpoint);



            // Process HTTP request
            using (var hmacSigningHandler = new HmacSigningHandler(this.AppId, this.AppKey))
            {
                hmacSigningHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (HttpClient client = new HttpClient(hmacSigningHandler))
                {
                    if (request != null)
                    {
                        rawRequest = JsonSerializer.Serialize(request);
                    }
                    HttpContent content = new StringContent(rawRequest, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue(SecureAuth.Sdk.Models.LanguageWrapper.GetDescription(langDescription)));

                    var response = client.PostAsync(requestUrl, content).Result;
                    statusCode = response.StatusCode;

                    rawResult = response.Content.ReadAsStringAsync().Result;
                }
>>>>>>> 767840d... updates for .net core and language helper function
            }

            // Deserialize the response
            var result = JsonSerializer.Deserialize<T>(rawResult);

            // Set HTTP status code and return
<<<<<<< HEAD
            ((BaseResponse) result).StatusCode = statusCode;
            ((BaseResponse) result).RawJson = rawResult;
            return result;
        }

        internal T Post<T>(string apiEndpoint, BaseRequest request = null) 
=======
            ((BaseResponse)result).StatusCode = statusCode;
            ((BaseResponse)result).RawJson = rawResult;
            ((BaseResponse)result).RawRequestJson = rawRequest;

            return result;
        }

        internal T Put<T>(string apiEndpoint, BaseRequest request = null)
>>>>>>> 767840d... updates for .net core and language helper function
            where T : BaseResponse
        {
            string rawResult = string.Empty;
            string rawRequest = string.Empty;
            HttpStatusCode statusCode;
            string requestUrl = string.Concat(this.SecureAuthRealmUrl, apiEndpoint);
<<<<<<< HEAD
            
=======

>>>>>>> 767840d... updates for .net core and language helper function
            // Process HTTP request
            using (HttpClient client = new HttpClient(new HmacSigningHandler(this.AppId, this.AppKey)))
            {
                if (request != null)
                {
                    rawRequest = JsonSerializer.Serialize(request);
                }
                HttpContent content = new StringContent(rawRequest, Encoding.UTF8, "application/json");
<<<<<<< HEAD
                var response = client.PostAsync(requestUrl, content).Result;
=======
                var response = client.PutAsync(requestUrl, content).Result;
>>>>>>> 767840d... updates for .net core and language helper function
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
