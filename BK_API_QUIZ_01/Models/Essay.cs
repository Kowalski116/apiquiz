using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class Essay
    {
        public int Id { get; set; }
        public string GradeInfo { get; set; }
        public string Response { get; set; }
        public int QuizId { get; set; }

        public virtual Quiz Quiz { get; set; }
    }
}