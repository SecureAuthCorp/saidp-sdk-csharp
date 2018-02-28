using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SecureAuth.Admin.Sdk.Models
{
    public class KnowledgeBasedSetting
    {
        public bool? EnableQuestions { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.MultiFactorKbFormat? Format { get; set; }
        public int? QuestionCount { get; set; }
        public bool? DoConversion { get; set; }
    }
}
