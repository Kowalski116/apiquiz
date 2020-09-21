using BK_API_QUIZ_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.DTO
{
    public class QuizDTO
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
        public List<TrueFalse> TrueFalses { get; set; }
        public List<MultipleChoice> MultipleChoices { get; set; }
        public List<MultipleResponse> MultipleResponses { get; set; }
        public List<Matching> Matchings { get; set; }
        public List<FillinBlank> FillinBlanks { get; set; }
        public List<Essay> Essays { get; set; }
        public List<DragDrop> DragDrops { get; set; }
        public List<ShortAnswer> ShortAnswer { get; set; }





    }
}