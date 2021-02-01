using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Body { get; set; }
        public string MarkA { get; set; }
        public string MarkB { get; set; }
        public string MarkC { get; set; }
        public string MarkD { get; set; }
        public string Answer { get; set; }
        public Exam Exam { get; set; }
    }
}
