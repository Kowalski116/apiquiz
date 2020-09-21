using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string QType { get; set; }
        public string QName { get; set; }
        public string QuestionText { get; set; }
        public string QSkill { get; set; }
        public decimal DefaultMask { get; set; }
        public DateTime TimeCreate { get; set; }
        public DateTime TimeUpdate { get; set; }
        public string QLevel { get; set; }
        public string Image { get; set; }

        public ICollection<Exam> Exams { get; set; }
        public ICollection<TrueFalse> TrueFalses { get; set; }
        public ICollection<MultipleChoice> MultipleChoices { get; set; }
        public ICollection<MultipleResponse> MultipleResponses { get; set; }
        public ICollection<Matching> Matchings { get; set; }
        public ICollection<FillinBlank> FillinBlanks { get; set; }
        public ICollection<Essay> Essays { get; set; }
        public ICollection<DragDrop> DragDrops { get; set; }
        public ICollection<ShortAnswer> ShortAnswer { get; set; }
    }
}