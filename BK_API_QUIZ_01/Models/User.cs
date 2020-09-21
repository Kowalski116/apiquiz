using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Sex { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public int TypeId { get; set; }


        /*public ICollection<Exam_attemp> Exam_Attemps { get; set; }*/
    }
}