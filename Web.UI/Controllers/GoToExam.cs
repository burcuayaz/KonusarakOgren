using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.UI.Data;
using Web.UI.Models;
using Web.UI.Models.Request;

namespace Web.UI.Controllers
{
    public class GoToExam: Controller
    {
        private readonly ApplicationDbContext _context;

        public GoToExam(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int i=0)
        {
            var Exam = _context.Exam.Where(x => x.ExamId == i).ToList().FirstOrDefault();
             Exam.Questions= _context.Question.Where(x=>x.Exam.ExamId==i).ToList();
            return View(Exam);
        }
        [HttpPost]
        public async Task<IActionResult> sinavaGir([FromBody] ReqOlustur reqOlustur)
        {
            var questions = _context.Question.Where(x => x.Exam.ExamId == reqOlustur.examId).ToList();

            List<bool> test = new List<bool>();

            int puan = 0;
            foreach(var(value, index) in reqOlustur.Soru.AsEnumerable().Select((v, i) => (v, i)))
            {
               
                switch (questions[index].Answer)
                {
                    case "A":puan += (value.cevap.Contains(questions[index].MarkA)) ? 25 : 0;break;
                    case "B": puan += (value.cevap.Contains(questions[index].MarkB)) ? 25 : 0; break;
                    case "C": puan += (value.cevap.Contains(questions[index].MarkC)) ? 25 : 0; break;
                    case "D": puan += (value.cevap.Contains(questions[index].MarkD)) ? 25 : 0; break;
                }
            }

            var users = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);

            ExamResult examResult = new ExamResult();
            examResult.Exam= _context.Exam.FirstOrDefault(x => x.ExamId == reqOlustur.examId);
            examResult.Puan = puan;



            _context.Add(examResult);
            await _context.SaveChangesAsync();


            return Ok(questions.Select(x=>x.Answer));
        }

    }
}
