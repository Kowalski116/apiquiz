using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class Exam_attemp
    {
        public int id { get; set; }
        public int ExamId { get; set; }
        public int? UserId { get; set; }
        public int attempt { get; set; }
        public int SumGrade { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeFinish { get; set; }
        public int Preview { get; set; }

        /*[ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }*/

        public virtual User User { get; set; }
    }
}