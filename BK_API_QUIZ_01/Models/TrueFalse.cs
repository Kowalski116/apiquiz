using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class TrueFalse
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public bool IsTrue { get; set; }
        
        
        public  Quiz Quiz { get; set; }
    }
}