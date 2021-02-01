using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models.Request
{
    public class ReqOlustur
    {
        public int examId { get; set; }
        public string title { get; set; }
        public string QuestionMain { get; set; }

        public List<Soru> Soru { get; set; }

    }
    public class Soru
    {
        public string soruBody { get; set; }
        public string secenekA { get; set; }
        public string secenekB { get; set; }
        public string secenekC { get; set; }
        public string secenekD { get; set; }
        public string cevap { get; set; }

    }
}
