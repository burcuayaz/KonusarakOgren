
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using Web.UI.Models;
using Microsoft.AspNetCore.Authorization;
using AngleSharp;
using System.Threading.Tasks;
using Web.UI.Data;
using System;
using Web.UI.Models.Request;

namespace Web.UI.Controllers
{
    [Authorize]

    public class CreateExam : Controller
    {

        private readonly ApplicationDbContext _context;

        public CreateExam(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var news = new List<NewsModel>();

            XmlReader xr = XmlReader.Create("https://www.wired.com/feed/rss");
            SyndicationFeed feed = SyndicationFeed.Load(xr);

            foreach (var item in feed.Items.ToList().GetRange(0, 5))
            {
                news.Add(new NewsModel { guid = item.Id, title = item.Title.Text, link = item.Links[0].Uri.AbsoluteUri });
            }

            ViewBag.News = news;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> sinavOlustur([FromBody] ReqOlustur reqOlustur)
        {
            var users = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);

            var Exam = new Exam();
            Exam.Title = reqOlustur.title;
            Exam.QuestionMain = reqOlustur.QuestionMain;
            Exam.User = users;
            Exam.createDate = DateTime.Now;

            var questionList = new List<Question>();
            foreach (var item in reqOlustur.Soru)
            {
                var question = new Question
                {
                    Body = item.soruBody,
                    MarkA = item.secenekA,
                    MarkB = item.secenekB,
                    MarkC = item.secenekC,
                    MarkD = item.secenekD,
                    Answer = item.cevap
                };
                questionList.Add(question);
                
            }
            Exam.Questions = questionList;

            _context.Add(Exam);
            await _context.SaveChangesAsync();

            return Ok("Başarılı");
        }


        public async Task<IActionResult> ReadTextFromUrl(string url)
        {


            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(url);
            var someStringValue = document.QuerySelectorAll("p").ToList().Skip(3).Take(4);

            string combindedString = string.Join(" , ", someStringValue.ToList().Select(x => x.TextContent));
            return Ok(combindedString);
        }


    }

  
}
