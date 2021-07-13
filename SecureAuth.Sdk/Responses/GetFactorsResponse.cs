using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class GetFactorsResponse : BaseResponse
    {
        [DataMember(Name = "user_id", EmitDefaultValue = false)]
        public string UserId { get; set; }

        [DataMember(Name = "factors", EmitDefaultValue = false)]
        public IList<MultiFactorOption> Factors { get; set; }

        public override bool IsSuccess()
        {
            return ((this.StatusCode == HttpStatusCode.OK) && (this.Status == "found"));
        }

        /// <summary>
        /// Returns a list of MultiFactorOptions where type is phone.
        /// </summary>
        /// <returns>List of MultiFactorOption</returns>
        public IList<MultiFactorOption> GetPhoneFactors()
        {
            return this.Factors.Where(f => f.FactorType == "phone").ToList();
        }

        /// <summary>
        /// Returns a list of MultiFactorOptions where type is email.
        /// </summary>
        /// <returns>List of MultiFactorOption</returns>
        public IList<MultiFactorOption> GetEmailFactors()
        {
            return this.Factors.Where(f => f.FactorType == "email").ToList();
        }

        /// <summary>
        /// Returns a list of MultiFactorOptions where type is kbq.
        /// </summary>
        /// <returns>List of MultiFactorOption</returns>
        public IList<MultiFactorOption> GetKBQFactors()
        {
            return this.Factors.Where(f => f.FactorType == "kbq").ToList();
        }

        /// <summary>
        /// Returns a list of MultiFactorOptions where type is help_desk.
        /// </summary>
        /// <returns>List of MultiFactorOption</returns>
        public IList<MultiFactorOption> GetHelpDeskFactors()
        {
            return this.Factors.Where(f => f.FactorType == "help_desk").ToList();
        }

        /// <summary>
        /// Returns a list of MultiFactorOptions where type is push.
        /// </summary>
        /// <returns>List of MultiFactorOption</returns>
        public IList<MultiFactorOption> GetPushFactors()
        {
            return this.Factors.Where(f => f.FactorType == "push").ToList();
        }

        /// <summary>
        /// Returns a list of MultiFactorOptions where type is oath.
        /// </summary>
        /// <returns>List of MultiFactorOption</returns>
        public IList<MultiFactorOption> GetOathFactors()
        {
            return this.Factors.Where(f => f.FactorType == "oath").ToList();
        }
    }
}