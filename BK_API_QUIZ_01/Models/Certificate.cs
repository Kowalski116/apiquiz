using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string CerName { get; set; }
        public string CerDescription { get; set; }
        public string CerImage { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }
    }
}