using BK_API_QUIZ_01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BK_API_QUIZ_01.DAL
{


    public class APIQuizDBContext : DbContext
    {
        public APIQuizDBContext() : base()
        {
        }
        public DbSet<Certificate> Certificate { get; set; }
        public DbSet<CertificateUser> CertificateUser { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Exam_attemp> Exam_attemp { get; set; }
        public DbSet<Exam_grade> Exam_grade { get; set; }
        public DbSet<Exam_override> Exam_override { get; set; }
        public DbSet<Exam_slot> Exam_slot { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<FillinBlank> FillinBlank { get; set; }
        public DbSet<DragDrop> DragDrop { get; set; }
        public DbSet<MultipleChoice> MultipleChoice { get; set; }
        public DbSet<MultipleResponse> MultipleResponse { get; set; }
        public DbSet<TrueFalse> TrueFalse { get; set; }
        public DbSet<Essay> Essay { get; set; }
        public DbSet<ShortAnswer> ShortAnswer { get; set; }
        public DbSet<Matching> Matching { get; set; }
        public DbSet<User> Users { get; set; }
    }
}