using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.Models
{
    public class CertificateUser
    {
        [Key, Column(Order = 0)]
        public int CertificateId { get; set; }
        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Certificate Certificate { get; set; }
        public int CerFinish { get; set; }
    }
}