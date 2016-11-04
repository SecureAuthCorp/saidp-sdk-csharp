using Microsoft.Owin.Security;
using SACustomAPI.Models;
using SACustomAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SACustomAPI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public virtual ActionResult Index(string ipSpoof)
        {
            //Providing the device recognition javascript source to the view.
            ViewBag.DFP = ApiHelpers.getDFPSrc();

            //Creating person object to hold authentication specific information for the session.
            Persona persona = new Persona();
            if (string.IsNullOrWhiteSpace(ipSpoof))
            {
                persona.UserIpAddress = Request.UserHostAddress;
            }
            else
            {
                persona.UserIpAddress = ipSpoof;
            }

            //Saving the persona object to session.
            SessionBag.Current.Persona = persona;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Using Owin context to perform user SignIn and create base authentication token.
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            var authService = new AuthenticationServiceModel(authManager);

            var authResult = authService.SignIn(model.Username, model.Password);

            if (authResult.IsSuccess)
            {
                //Creating state token to keep track of users' state in the authentication process.
                AuthorizeEnum.State state = AuthorizeEnum.State.Index;
                Persona persona = SessionBag.Current.Persona;

                //Storing the return url so we can support deep links and still force auth when session is expired.
                persona.UserReturnUrl = returnUrl;

                //Storing the fingerprint json value returned by the javascript ran on the GET index action.
                persona.FingerprintJson = model.Fingerprint;
                persona.AuthState = state;
                SessionBag.Current.Persona = persona;
                return RedirectToAction("Adapt");
            }
          
            ModelState.AddModelError("", authResult.ErrorMessage);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize]
        public virtual ActionResult Adapt()
        {
            try
            {
                //Getting the userId out of the claim token created by Owin middleware.
                var identity = (ClaimsIdentity)User.Identity;
                List<Claim> claims = identity.Claims.ToList();
                Claim nameIdClaim = claims.Find(c => c.Type == ClaimTypes.NameIdentifier);
                var userId = nameIdClaim.Value;
                Persona persona = SessionBag.Current.Persona;

                
                string dfp = persona.FingerprintJson;
                string userIpAddress = persona.UserIpAddress;

                //Checking for fingerprint cookie to get existing fingerprint Id.
                string fpId = null;
                if (Request.Cookies["sadfp"] != null)
                {
                    fpId = Request.Cookies["sadfp"].Value.ToString();
                }

                //Creating view model to provide context to the page.
                AdaptViewModel model = new AdaptViewModel();

                string adaptState = ApiHelpers.ProcessAdaptiveAuth(userId, userIpAddress);
                string ipEvalState = ApiHelpers.ProcessIpEval(userId, userIpAddress);
                string deviceState = ApiHelpers.CheckDevice(dfp, userId, fpId);

                //Decision tree based on returns for the Adaptive Authentication API, IpEval API, and Device Fingerprint API.
                if (adaptState != "Continue")
                {
                    if (adaptState != "Hardstop" || adaptState != "Select")
                    {
                        model.outsideRedirect = adaptState;
                        return View(model);
                    }
                    else
                    {
                        model.actionRedirect = adaptState;
                        return View(model);
                    }
                }
                else
                {
                    if (ipEvalState == "Hardstop")
                    {
                        model.actionRedirect = ipEvalState;
                        return View(model);
                    }
                    if (deviceState == "Authorized")
                    {
                        model.routeRedirect = deviceState;
                        return View(model);
                    }
                    else if (deviceState == "Select")
                    {
                        model.actionRedirect = deviceState;
                        return View(model);
                    }
                    else
                    {
                        model.localRedirect = deviceState;
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AdaptError", "Unsupported workflow detected. Please contact your system administrator: " + ex.Message.ToString());
                return View();
            }
        }

        [HttpPost]
        [CustomAuthorize]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Adapt(AdaptViewModel model)
        {
            Persona persona = SessionBag.Current.Persona;
            //Decision tree to handle each redirect type from API results. This is only here, kind of needlessly, to allow me to create a delay before processing through to 2FA select or authorized or hardstop.
            //in production we would just have a GET action and it would redirect when the decision logic is complete.
            if (persona != null)
            {
                if (!string.IsNullOrWhiteSpace(model.actionRedirect))
                {
                    if (model.actionRedirect == "Select")
                    {
                        persona.AuthState |= AuthorizeEnum.State.Adapt;
                        SessionBag.Current.Persona = persona;
                        return RedirectToAction(model.actionRedirect);
                    }
                    else if (model.actionRedirect == "Hardstop")
                    {
                        IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                        authManager.SignOut(SAAuthentication.ApplicationCookie);
                        persona.AuthState = AuthorizeEnum.State.Index;
                        SessionBag.Current.Persona = persona;
                        return RedirectToAction("Hardstop");
                    }
                }
                if (!string.IsNullOrWhiteSpace(model.localRedirect))
                {
                    return RedirectToLocal(model.localRedirect);
                }
                if (!string.IsNullOrWhiteSpace(model.routeRedirect))
                {
                    return RedirectToAction("Index", model.routeRedirect);
                }
                if (!string.IsNullOrWhiteSpace(model.outsideRedirect))
                {
                    //Signing the user out because they have been instructed to leave the applicaton and authentication context.
                    IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                    authManager.SignOut(SAAuthentication.ApplicationCookie);
                    persona.AuthState = AuthorizeEnum.State.Index;
                    SessionBag.Current.Persona = persona;
                    return Redirect(model.outsideRedirect);
                }
            }
            else
            {
                ModelState.AddModelError("AdaptError", "Unsupported workflow detected. Please contact your system administrator: ");
                return View();
            }
           
            ModelState.AddModelError("AdaptError", "Unsupported workflow detected. Please contact your system administrator: ");
            return View();
        }


        [HttpGet]
        [CustomAuthorize]
        public virtual ActionResult Select()
        {
            var identity = (ClaimsIdentity)User.Identity;
            List<Claim> claims = identity.Claims.ToList();
            Claim nameIdClaim = claims.Find(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = nameIdClaim.Value;

            //Building the 2FA factors for the user.
            SelectViewModel model = ApiHelpers.GetUserFactors(userId);
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Select(SelectViewModel model)
        {
            var identity = (ClaimsIdentity)User.Identity;
            List<Claim> claims = identity.Claims.ToList();
            Claim nameIdClaim = claims.Find(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = nameIdClaim.Value;
            string otp = string.Empty;
            
            //Delievering or processing the 2FA method the user selected.
            otp = ApiHelpers.SecondFactorDelivery(userId, model.selectedFactorId, model.selectedType, model.selectedCapability);

            Persona persona = SessionBag.Current.Persona;

            //Decision logic to process otp type and help guide the proper OTP input type.
            if (!string.IsNullOrWhiteSpace(otp) || otp != "invalid")
            {
                if (persona != null)
                {
                    persona.AuthState |= AuthorizeEnum.State.Select;
                    SessionBag.Current.Persona = persona;
                    SessionBag.Current.Otp = otp;
                    return RedirectToAction("Otp");
                }
            }

            //Passing the factors back to the view so the user can re-select 2FA method.
            model.phoneFactors = persona.factors.GetPhoneFactors();
            model.emailFactors = persona.factors.GetEmailFactors();
            model.kbqFactors = persona.factors.GetKBQFactors();
            model.oathFactors = persona.factors.GetOathFactors();
            model.helpDeskFactors = persona.factors.GetHelpDeskFactors();
            model.pushFactors = persona.factors.GetPushFactors();
            ModelState.AddModelError("", "Invalid OTP Method selected. Please select a different method or contact your System Administrator.");
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize]
        public virtual ActionResult Otp()
        {
            var identity = (ClaimsIdentity)User.Identity;
            List<Claim> claims = identity.Claims.ToList();
            Claim nameIdClaim = claims.Find(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = nameIdClaim.Value;
            OtpViewModel model = new OtpViewModel();
            model.canTrust = true;
            Persona persona = SessionBag.Current.Persona;
            string otp = SessionBag.Current.Otp;

            //Checking if the user is allowed to use device recognition based on Adaptive Auth results.
            if (persona != null && !persona.AllowDeviceRecog)
            {
                model.canTrust = false;
            }

            //Decision tree to drive the proper view for OTP entry.
            if (otp == "push_accept")
            {
                SessionBag.Current.Otp = ApiHelpers.SendPushAccept(userId, persona.selectedFactor.FactorId);
                model.OtpType = "push_accept";
            }
            else if (otp == "kbq")
            {
                model.OtpType = otp;
                Random rnd = new Random();
                int upperBound = persona.factors.GetKBQFactors().Count;
                int kbIndex1 = rnd.Next(0, upperBound);
                int kbIndex2 = rnd.Next(0, upperBound);
                model.KbqQuestion1 = persona.factors.GetKBQFactors()[kbIndex1];
                model.Kbq1FactorId = model.KbqQuestion1.FactorId;
                model.KbqQuestion2 = persona.factors.GetKBQFactors()[kbIndex2];
                model.Kbq2FactorId = model.KbqQuestion2.FactorId;
            }
            else
            {
                model.OtpType = "pin";
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult Push()
        {
            Persona persona = SessionBag.Current.Persona;
            string otp = SessionBag.Current.Otp;
            string pushStatus = ApiHelpers.CheckPushStatus(otp);
            if (pushStatus == "ACCEPTED")
            {
                persona.AuthState |= AuthorizeEnum.State.Otp;
                SessionBag.Current.Persona = persona;
                return Json(new { result = "Redirect", url = Url.Action("Index", "Authorized") }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = pushStatus }, JsonRequestBehavior.AllowGet);
            }

        }
        
        [HttpPost]
        [CustomAuthorize]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Otp(OtpViewModel model)
        {
            var identity = (ClaimsIdentity)User.Identity;
            List<Claim> claims = identity.Claims.ToList();
            Claim nameIdClaim = claims.Find(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = nameIdClaim.Value;
            Persona persona = SessionBag.Current.Persona;
            string sentOtp = SessionBag.Current.Otp;
            bool isTrusted = model.isTrustedDevice;
            if (sentOtp == "oath")
            {
                if (string.IsNullOrWhiteSpace(model.Passcode)) {
                    model.Passcode = string.Empty;
                    ModelState.AddModelError("", "Invalid OTP Entered. Please make sure you have the current One-Time Passcode and try again.");
                    return View(model);
                }
                else
                {
                    bool valid = ApiHelpers.CheckOathToken(userId, persona.selectedFactor.FactorId, model.Passcode);
                    if (valid)
                    {
                        if (isTrusted)
                        {
                            string fpId = persona.FingerprintId;
                            string confirm = ApiHelpers.ConfirmDevice(userId, fpId);
                            ApiHelpers.SetPersistentCookies("sadfp", fpId);
                        }
                        persona.AuthState |= AuthorizeEnum.State.Otp;
                        SessionBag.Current.Persona = persona;
                        return RedirectToAction("Index", "Authorized");
                    }
                    else
                    {
                        model.Passcode = string.Empty;
                        ModelState.AddModelError("", "Invalid OTP Entered. Please make sure you have the current One-Time Passcode and try again.");
                        return View(model);
                    }
                }
            }
            if (sentOtp == "kbq")
            {
                if (!string.IsNullOrWhiteSpace(model.KbqAnswer1) || !string.IsNullOrWhiteSpace(model.KbqAnswer2))
                {
                    bool valid1 = ApiHelpers.CheckKBA(userId, model.KbqAnswer1, model.Kbq1FactorId);
                    if (!valid1)
                    {
                        model.KbqAnswer1 = string.Empty;
                        model.KbqAnswer2 = string.Empty;
                        ModelState.AddModelError("", "Invalid KBA1 Entered.");
                        return View(model);
                    }
                    else
                    {
                        bool valid2 = ApiHelpers.CheckKBA(userId, model.KbqAnswer2, model.Kbq2FactorId);
                        if (!valid2)
                        {
                            model.KbqAnswer1 = string.Empty;
                            model.KbqAnswer2 = string.Empty;
                            ModelState.AddModelError("", "Invalid KBA1 Entered.");
                            return View(model);
                        }
                        if (isTrusted)
                        {
                            string fpId = persona.FingerprintId;
                            string confirm = ApiHelpers.ConfirmDevice(userId, fpId);
                            ApiHelpers.SetPersistentCookies("sadfp", fpId);
                        }
                        persona.AuthState |= AuthorizeEnum.State.Otp;
                        SessionBag.Current.Persona = persona;
                        return RedirectToAction("Index", "Authorized");
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(model.Passcode) && sentOtp == model.Passcode)
            {
                if (isTrusted)
                {
                    string fpId = persona.FingerprintId;
                    string confirm = ApiHelpers.ConfirmDevice(userId, fpId);
                    ApiHelpers.SetPersistentCookies("sadfp", fpId);
                }
                
                if (persona != null)
                {
                    persona.AuthState |= AuthorizeEnum.State.Otp;
                    SessionBag.Current.Persona = persona;
                    return RedirectToAction("Index","Authorized");
                }
            }
            else
            {
                model.Passcode = string.Empty;
                ModelState.AddModelError("", "Invalid OTP Entered selected. Please make sure you have the current One-Time Passcode and try again.");
                return View(model);
            }
            model.Passcode = string.Empty;
            ModelState.AddModelError("", "Invalid OTP Entered selected. Please make sure you have the current One-Time Passcode and try again.");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult Hardstop()
        {
            HardstopViewModel model = new HardstopViewModel();
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(SAAuthentication.ApplicationCookie);
            Persona persona = SessionBag.Current.Persona;
            if (persona != null)
            {
                persona.AuthState = AuthorizeEnum.State.Index;
                SessionBag.Current.Persona = persona;
            }
            HttpContext.Session.Abandon();
            HttpContext.Session.Clear();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult Fraud()
        {
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [ValidateAntiForgeryToken]
        public virtual ActionResult Logoff()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(SAAuthentication.ApplicationCookie);

            return RedirectToAction("Index");
        }
    }
}