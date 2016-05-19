using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class KbProperty
    {
        [DataMember(Name = "question")]
        public string Question { get; set; }

        [DataMember(Name = "answer")]
        public string Answer { get; set; }
    }
}
