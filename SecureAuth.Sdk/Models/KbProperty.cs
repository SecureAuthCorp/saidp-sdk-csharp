using System.Runtime.Serialization;

namespace SecureAuth.Sdk
{
    [DataContract]
    public class KbProperty
    {
        public KbProperty()
        {

        }

        public KbProperty(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }

        [DataMember(Name = "question")]
        public string Question { get; set; }

        [DataMember(Name = "answer")]
        public string Answer { get; set; }
    }
}
