using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class Exam_override
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int? UserId { get; set; }
        public int Attemps { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual User User { get; set; }
    }
}