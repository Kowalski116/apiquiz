using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public string Intro { get; set; }
        public DateTime TimeOpen { get; set; }
        public DateTime TimeClose { get; set; }
        public int Attemps { get; set; }
        public bool GradeMethod { get; set; }
        public int SumGrade { get; set; }
        public int GradetoPass { get; set; }
        public DateTime TimeCreate { get; set; }
        public DateTime TimeUpdate { get; set; }
        public int TimeLimit { get; set; }
        public String Pass { get; set; }


        public virtual ICollection<Quiz> Quizs { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Exam_slot> Exam_slot { get; set; }
        public ICollection<Exam_attemp> Exam_attemp { get; set; }
    }
}