using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BK_API_QUIZ_01.DAL;
using BK_API_QUIZ_01.Models;

namespace BK_API_QUIZ_01.Controllers
{
    [AllowAnonymous]
    public class ExamsController : ApiController
    {
        private APIQuizDBContext db = new APIQuizDBContext();

        // GET: api/Exams
        public IQueryable<Exam> GetExam()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Exam;
        }

        // GET: api/Exams/5
        [ResponseType(typeof(Exam))]
        public async Task<IHttpActionResult> GetExam(int id)
        {
            Exam exam = await db.Exam.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }

        // PUT: api/Exams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExam(int id, Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exam.Id)
            {
                return BadRequest();
            }

            db.Entry(exam).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Exams
        [ResponseType(typeof(Exam))]
        public async Task<IHttpActionResult> PostExam(Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var quizadd = exam.Quizs;
            exam.Quizs = null;

            /*foreach (var item in quiz.MultipleChoices)
            {
                db.Entry(item).State = EntityState.Modified;
            }*/

            db.Exam.Add(exam);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = exam.Id }, exam);
        }

        // DELETE: api/Exams/5
        [ResponseType(typeof(Exam))]
        public async Task<IHttpActionResult> DeleteExam(int id)
        {
            Exam exam = await db.Exam.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            db.Exam.Remove(exam);
            await db.SaveChangesAsync();

            return Ok(exam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamExists(int id)
        {
            return db.Exam.Count(e => e.Id == id) > 0;
        }
    }
}