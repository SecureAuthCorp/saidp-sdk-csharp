using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SACustomAPI.Models
{
    public class LoginViewModel
    {
        [Required, AllowHtml]
        public string Username { get; set; }

        [Required, AllowHtml]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, AllowHtml]
        public string Fingerprint { get; set; }
    }
}