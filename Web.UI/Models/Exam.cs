using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string Title { get; set; }
        public string QuestionMain { get; set; }
        public DateTime createDate { get; set; }
        public List<Question> Questions { get; set; }
        public User User { get; set; }
    }
}
