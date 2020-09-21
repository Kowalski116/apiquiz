using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class Exam_slot
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int QuizId { get; set; }
        public int Quizslot { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}