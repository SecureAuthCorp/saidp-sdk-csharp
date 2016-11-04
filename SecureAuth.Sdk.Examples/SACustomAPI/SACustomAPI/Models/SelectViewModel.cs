using SACustomAPI.Utilities;
using SecureAuth.Sdk;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SACustomAPI.Models
{
    public class SelectViewModel
    {
        [UIHint("PhoneSelect")]
        public IList<MultiFactorOption> phoneFactors { get; set; }

        [UIHint("EmailSelect")]
        public IList<MultiFactorOption> emailFactors { get; set; }

        [UIHint("KbqSelect")]
        public IList<MultiFactorOption> kbqFactors { get; set; }

        [UIHint("HelpDeskSelect")]
        public IList<MultiFactorOption> helpDeskFactors { get; set; }

        [UIHint("PushSelect")]
        public IList<MultiFactorOption> pushFactors { get; set; }

        [UIHint("OathSelect")]
        public IList<MultiFactorOption> oathFactors { get; set; }

        public string selectedFactorId { get; set; }
        public string selectedType { get; set; }
        public string selectedCapability { get; set; }

        public ApiJson apiJson
        {
            get
            {
                return SessionBag.Current.JsonModel;
            }
        }
    }
}