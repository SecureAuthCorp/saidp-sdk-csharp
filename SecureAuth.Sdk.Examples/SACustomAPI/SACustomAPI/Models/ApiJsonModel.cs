using Newtonsoft.Json;
using SACustomAPI.Utilities;
using SecureAuth.Sdk;
using System.IO;
using System.Text.RegularExpressions;

namespace SACustomAPI.Models
{
    /// <summary>
    /// Intended to hold all the RawJson requests made to the SecureAuth APIs.
    /// </summary>
    public class ApiJson
    {
        public string DfpJsRequest { get; set; }
        public string DfpJsResponse { get; set; }
        public string PwdRequest { get; set; }
        public string PwdResponse { get; set; }
        public string ProfileRequest { get; set; }
        public string ProfileResponse { get; set; }
        public string AccessHistoryRequest { get; set; }
        public string AccessHistoryResponse { get; set; }
        public string AdaptiveRequest { get; set; }
        public string AdaptiveResponse { get; set; }
        public string IpEvalRequest { get; set; }
        public string IpEvalResponse { get; set; }
        public string DfpValidateRequest { get; set; }
        public string DfpValidateResponse { get; set; }
        public string GetFactorsRequest { get; set; }
        public string GetFactorsResponse { get; set; }
        public string OtpRequest { get; set; }
        public string OtpResponse { get; set; }
        public string DfpConfirmRequest { get; set; }
        public string DfpConfirmResponse { get; set; }
    }

    public static class ApiJsonExtensions
    {
        public static string MaskPhone (this string number)
        {
            string maskedNumber = "(***) ***-" + number.Substring(number.Length - 4);
            return maskedNumber;
        }

        public static string MaskEmail (this string email)
        {
            string maskedEmail = Regex.Replace(email, @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)", m => new string('*', m.Length));
            return maskedEmail;
        }

        public static string PrettyPrint(this string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                using (var stringReader = new StringReader(json))
                using (var stringWriter = new StringWriter())
                {
                    var jsonReader = new JsonTextReader(stringReader);
                    var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                    jsonWriter.WriteToken(jsonReader);
                    return stringWriter.ToString();
                }
            }
            else
            {
                return "";
            }

        }

        public static void SetRequestResponseModel(this BaseResponse resp, string key)
        {
            ApiJson jsonModel;
            if (SessionBag.Current.JsonModel != null)
            {
                jsonModel = SessionBag.Current.JsonModel;
            }
            else
            {
                jsonModel = new ApiJson();
            }

            switch (key)
            {
                case "pwd":
                    jsonModel.PwdRequest = resp.RawRequestJson.PrettyPrint();
                    jsonModel.PwdResponse = resp.RawJson.PrettyPrint();
                    break;
                case "profile":
                    jsonModel.ProfileRequest = resp.RawRequestJson.PrettyPrint();
                    jsonModel.ProfileResponse = resp.RawJson.PrettyPrint();
                    break;
                case "dfpJs":
                    jsonModel.DfpJsRequest = resp.RawRequestJson.PrettyPrint();
                    jsonModel.DfpJsResponse = resp.RawJson.PrettyPrint();
                    break;
                case "access":
                    jsonModel.AccessHistoryRequest = resp.RawRequestJson.PrettyPrint();
                    jsonModel.AccessHistoryResponse = resp.RawJson.PrettyPrint();
                    break;
                case "adapt":
                    jsonModel.AdaptiveRequest = resp.RawRequestJson.PrettyPrint();
                    jsonModel.AdaptiveResponse = resp.RawJson.PrettyPrint();
                    break;
                case "ipeval":
                    jsonModel.IpEvalRequest = resp.RawRequestJson.PrettyPrint();
                    jsonModel.IpEvalResponse = resp.RawJson.PrettyPrint();
                    break;
                case "dfpValidate":
                    jsonModel.DfpValidateRequest = resp.RawRequestJson.PrettyPrint();
                    jsonModel.DfpValidateResponse = resp.RawJson.PrettyPrint();
                    break;
                case "dfpConfirm":
                    jsonModel.DfpConfirmRequest = resp.RawRequestJson.PrettyPrint();
                    jsonModel.DfpConfirmResponse = resp.RawJson.PrettyPrint();
                    break;
                case "factors":
                    jsonModel.GetFactorsRequest = resp.RawRequestJson.PrettyPrint();
                    jsonModel.GetFactorsResponse = resp.RawJson.PrettyPrint();
                    break;
                case "otp":
                    jsonModel.OtpRequest = resp.RawRequestJson.PrettyPrint();
                    jsonModel.OtpResponse = resp.RawJson.PrettyPrint();
                    break;
            }
            SessionBag.Current.JsonModel = jsonModel;
        }
        
    }
}