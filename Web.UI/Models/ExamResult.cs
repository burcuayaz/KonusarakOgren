using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models
{
    public class ExamResult
    {
        public int ExamResultId { get; set; }
        public int Puan { get; set; }
        public Exam Exam { get; set; }
    }
}
