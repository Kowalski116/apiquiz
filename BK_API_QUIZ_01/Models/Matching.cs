using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class Matching
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public int QuizId { get; set; }

        public Quiz Quiz { get; set; }
    }
}