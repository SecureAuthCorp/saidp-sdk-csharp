using SACustomAPI.Utilities;
using SecureAuth.Sdk;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SACustomAPI.Models
{
    public class OtpViewModel
    {
        [AllowHtml]
        [DataType(DataType.Password)]
        public string Passcode { get; set; }

        [AllowHtml]
        [Display(Name = "Remember this device?")]
        public bool isTrustedDevice { get; set; }

        [AllowHtml]
        public bool canTrust { get; set; }

        [AllowHtml]
        [DataType(DataType.Password)]
        public string KbqAnswer1 { get; set; }

        [AllowHtml]
        [DataType(DataType.Password)]
        public string KbqAnswer2 { get; set; }

        public string OtpType { get; set; }

        public MultiFactorOption KbqQuestion1 { get; set; }

        public MultiFactorOption KbqQuestion2 { get; set; }

        public string Kbq1FactorId { get; set; }

        public string Kbq2FactorId { get; set; }

        public ApiJson apiJson
        {
            get
            {
                return SessionBag.Current.JsonModel;
            }
        }
    }
}