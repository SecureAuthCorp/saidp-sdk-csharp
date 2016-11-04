using SACustomAPI.Models;
using SecureAuth.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SACustomAPI.Utilities
{
    public static class ApiHelpers
    {
        public static string getDFPSrc()
        {
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            SecureAuth.Sdk.Responses.DfpJavascriptLinkResponse dfpJs = saService.DeviceFingerprint.GetDfpJavascriptLink();
            dfpJs.SetRequestResponseModel("dfpJs");
            return dfpJs.Source;
        }

        public static string ProcessAdaptiveAuth(string userId, string userIpAddress)
        {
            //SA IdP SDK Config and service
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);

            AccessHistoryRequest accessReq = new AccessHistoryRequest(userId, userIpAddress);
            BaseResponse accessResp = saService.AccessHistory.CreateAccessHistory(accessReq);

            accessResp.SetRequestResponseModel("access");

            //Adaptive Authentication Post and Action
            Dictionary<string, string> authParams = new Dictionary<string, string>();
            authParams.Add("ip_address", userIpAddress);
            AdaptiveAuthRequest adaptReq = new AdaptiveAuthRequest(userId, authParams);
            AdaptiveAuthResponse adaptResp = saService.AdaptiveAuth.RunAdaptiveAuth(adaptReq);
            adaptResp.SetRequestResponseModel("adapt");
            Persona persona = SessionBag.Current.Persona;
            persona.AllowDeviceRecog = true;
            if (adaptResp.SuggestedAction == "stop")
            {
                return "Hardstop";
            }
            else if (adaptResp.SuggestedAction == "2ndfactor")
            {
                persona.AllowDeviceRecog = false;
                SessionBag.Current.Persona = persona;
                return "Select";
            }
            else if (adaptResp.SuggestedAction == "redirect")
            {
                return adaptResp.RedirectUrl;
            }
            else
            {
                return "Continue";
            }
        }

        public static string ProcessIpEval(string userId, string userIpAddress)
        {
            //SA IdP SDK Config and service
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);

            //IpEval Post and Action
            IpRiskRequest riskReq = new IpRiskRequest(userId, userIpAddress);
            IpRiskResponse riskResp = saService.EvaluateIp.GetIpRisk(riskReq);
            riskResp.SetRequestResponseModel("ipeval");
            if (riskResp.IpEvaluation.RiskFactor == 100 || riskResp.IpEvaluation.RiskFactor == 99 || riskResp.IpEvaluation.RiskFactor == 98 || riskResp.IpEvaluation.RiskFactor == 89 || riskResp.IpEvaluation.RiskFactor == 88)
            {
                return "Hardstop";
            }
            else
            {
                return "Continue";
            }
        }

        public static string CheckDevice(string dfp, string userId, string fpId = null)
        {
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            ValidateDfpRequest dfpReq = buildDfpRequest(dfp, userId, fpId);
            DfpResponse dfpResp = saService.DeviceFingerprint.ValidateDfp(dfpReq);
            dfpResp.SetRequestResponseModel("dfpValidate");

            Persona persona = SessionBag.Current.Persona;
            persona.FingerprintId = dfpResp.FingerprintId;
            if (dfpResp.Status == "found")
            {
                if (persona != null)
                {
                    persona.AuthState |= AuthorizeEnum.State.Adapt;
                    persona.AuthState |= AuthorizeEnum.State.Select;
                    persona.AuthState |= AuthorizeEnum.State.Otp;
                    SessionBag.Current.Persona = persona;
                    //Clean Up: Add catch for invalid session and default redirect location.
                    if (persona.UserReturnUrl != null)
                    {
                        return persona.UserReturnUrl;
                    }
                    else
                    {
                        return "Authorized";
                    }

                }
                else
                {
                    throw new Exception("AuthState Session object does not exist");
                }
            }
            else
            {
                return "Select";
            }
        }

        public static string ConfirmDevice(string userId, string fpId)
        {
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);

            ConfirmDfpRequest confirmReq = new ConfirmDfpRequest();
            confirmReq.FingerprintId = fpId;
            confirmReq.UserId = userId;

            DfpResponse confirmResp = saService.DeviceFingerprint.ConfirmDfp(confirmReq);
            confirmResp.SetRequestResponseModel("dfpConfirm");
            return confirmResp.Status;
        }

        public static ValidateDfpRequest buildDfpRequest(string dfp, string userid, string fpId = null)
        {
            ValidateDfpRequest dfpRequest = new ValidateDfpRequest(dfp);
            Persona persona = SessionBag.Current.Persona;
            dfpRequest.HostAddress = persona.UserIpAddress;
            dfpRequest.UserId = userid;
            if (fpId != null)
            {
                dfpRequest.FingerprintId = fpId;
            }
            dfpRequest.Fingerprint.Accept = HttpContext.Current.Request.Headers.Get("Accept");
            dfpRequest.Fingerprint.AcceptCharSet = HttpContext.Current.Request.Headers.Get("Accept-Charset");
            dfpRequest.Fingerprint.AcceptEncoding = HttpContext.Current.Request.Headers.Get("Accept-Encoding");
            dfpRequest.Fingerprint.AcceptLanguage = HttpContext.Current.Request.Headers.Get("Accept-Language");
            return dfpRequest;
        }

        public static SelectViewModel GetUserFactors(string userId)
        {
            SelectViewModel select = new SelectViewModel();
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            GetFactorsResponse factors = saService.User.GetFactors(userId);
            factors.SetRequestResponseModel("factors");
            select.phoneFactors = factors.GetPhoneFactors();
            select.emailFactors = factors.GetEmailFactors();
            select.oathFactors = factors.GetOathFactors();
            select.kbqFactors = factors.GetKBQFactors();
            select.helpDeskFactors = factors.GetHelpDeskFactors();
            select.pushFactors = factors.GetPushFactors();

            Persona persona = SessionBag.Current.Persona;
            persona.factors = factors;
            SessionBag.Current.Persona = persona;

            return select;
        }

        public static string SecondFactorDelivery(string userId, string factorId, string type, string capability)
        {
            string otp = string.Empty;
            Persona persona = SessionBag.Current.Persona;
            switch (type)
            {
                case "phone":
                    {
                        if (capability == "sms")
                        {
                            persona.selectedFactor = persona.factors.Factors.Where(f => f.FactorId == factorId).Single();
                            otp = SendOTPSMS(userId, factorId);
                        }
                        else if (capability == "call")
                        {
                            persona.selectedFactor = persona.factors.Factors.Where(f => f.FactorId == factorId).Single();
                            otp = SendOTPCall(userId, factorId);
                        }
                        break;
                    }
                case "email":
                    {
                        persona.selectedFactor = persona.factors.Factors.Where(f => f.FactorId == factorId).Single();
                        otp = SendOTPEmail(userId, factorId);
                        break;
                    }
                case "kbq":
                    {
                        persona.selectedFactor = persona.factors.Factors.Where(f => f.FactorType == type).FirstOrDefault();
                        otp = "kbq";
                        break;
                    }
                case "help_desk":
                    {
                        persona.selectedFactor = persona.factors.Factors.Where(f => f.FactorId == factorId).Single();
                        otp = SendOTPHelpDesk(userId, factorId);
                        break;
                    }
                case "push":
                    {
                        if (capability == "push_accept")
                        {
                            persona.selectedFactor = persona.factors.Factors.Where(f => f.FactorType == type).FirstOrDefault();
                            otp = capability;
                        } 
                        else
                        {
                            persona.selectedFactor = persona.factors.Factors.Where(f => f.FactorType == type).FirstOrDefault();
                            otp = SendOTPPush(userId, factorId);
                        }                   
                        break;
                    }
                case "oath":
                    {
                        persona.selectedFactor = persona.factors.Factors.Where(f => f.FactorType == type).FirstOrDefault();
                        otp = "oath";
                        break;
                    }
            }
            SessionBag.Current.Persona = persona;
            return otp;
        }

        public static string SendOTPSMS(string userId, string factorId)
        {
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            SmsOtpRequest smsReq = new SmsOtpRequest(userId, factorId);
            SendOtpResponse smsResp = saService.Authenticate.SendSmsOtp(smsReq);
            smsResp.SetRequestResponseModel("otp");
            if (smsResp.Status == "invalid")
            {
                return smsResp.Status;
            }
            else
            {
                return smsResp.OneTimePasscode;
            }
        }

        public static string SendOTPCall(string userId, string factorId)
        {
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            PhonecallOtpRequest callReq = new PhonecallOtpRequest(userId, factorId);
            SendOtpResponse callResp = saService.Authenticate.SendPhonecallOtp(callReq);
            callResp.SetRequestResponseModel("otp");
            if (callResp.Status == "invalid")
            {
                return callResp.Status;
            }
            else
            {
                return callResp.OneTimePasscode;
            }
        }

        public static string SendOTPEmail(string userId, string factorId)
        {
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            EmailOtpRequest emailReq = new EmailOtpRequest(userId, factorId);
            SendOtpResponse emailResp = saService.Authenticate.SendEmailOtp(emailReq);
            emailResp.SetRequestResponseModel("otp");
            if (emailResp.Status == "invalid")
            {
                return emailResp.Status;
            }
            else
            {
                return emailResp.OneTimePasscode;
            }
        }

        public static string SendOTPHelpDesk(string userId, string factorId)
        {
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            HelpDeskOtpRequest helpReq = new HelpDeskOtpRequest(userId, factorId);
            SendOtpResponse helpResp = saService.Authenticate.SendHelpDeskOtp(helpReq);
            helpResp.SetRequestResponseModel("otp");
            if (helpResp.Status == "invalid")
            {
                return helpResp.Status;
            }
            else
            {
                return helpResp.OneTimePasscode;
            }
        }

        public static string SendOTPPush(string userId, string factorId)
        {
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            PushOtpRequest pushReq = new PushOtpRequest(userId, factorId);
            SendOtpResponse pushResp = saService.Authenticate.SendPushOtp(pushReq);
            pushResp.SetRequestResponseModel("otp");
            if (pushResp.Status == "invalid")
            {
                return pushResp.Status;
            }
            else
            {
                return pushResp.OneTimePasscode;
            }
        }

        public static string SendPushAccept(string userId, string factorId)
        {
            Persona persona = SessionBag.Current.Persona;
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            PushAcceptRequest pushReq = new PushAcceptRequest(userId, factorId);
            PushAcceptResponse pushResp = saService.Authenticate.SendPushAccept(pushReq);
            pushResp.SetRequestResponseModel("otp");
            if (pushResp.Status == "invalid")
            {
                return pushResp.Status;
            }
            else
            {
                return pushResp.ReferenceId;
            }
        }

        public static string CheckPushStatus(string refId)
        {
            string result = string.Empty;
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            while (true)
            {
                BaseResponse resp = saService.Authenticate.GetPushAcceptStatus(refId);
                if (resp.Status == "not_found" || resp.Status == "invalid")
                {
                    result = resp.Status;
                    break;
                }
                else
                {
                    if (resp.Message == "PENDING")
                    {
                        Thread.Sleep(5000);
                        continue;
                    }
                    else
                    {
                        result = resp.Message;
                        break;
                    }
                }
            }
            return result;
        }

        public static bool CheckOathToken(string userId, string factorId, string token)
        {
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            ValidateOathRequest oathReq = new ValidateOathRequest(userId, token, factorId);
            BaseResponse oathResp = saService.Authenticate.ValidateOath(oathReq);
            oathResp.SetRequestResponseModel("otp");
            if (oathResp.Status == "valid")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckKBA(string userId, string answer, string factorId)
        {
            Configuration config = ConfigurationModel.getConfig();
            SecureAuthService saService = new SecureAuthService(config);
            ValidateKbaRequest kbaReq = new ValidateKbaRequest(userId, answer, factorId);
            BaseResponse kbaResp = saService.Authenticate.ValidateKba(kbaReq);
            if (kbaResp.Status == "valid")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SetPersistentCookies(string name, string value)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = value;
            cookie.Expires = System.DateTime.Today.AddDays(30);
            HttpContext.Current.Response.SetCookie(cookie);
        }
    }
}