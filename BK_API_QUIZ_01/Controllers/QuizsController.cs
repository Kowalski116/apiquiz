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
using BK_API_QUIZ_01.DTO;
using BK_API_QUIZ_01.Models;

namespace BK_API_QUIZ_01.Controllers
{
    [AllowAnonymous]
    public class QuizsController : ApiController
    {
        private APIQuizDBContext db = new APIQuizDBContext();

        // GET: api/Quizs
        /*public IQueryable<Quiz> GetQuiz()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Quiz;
        }*/

        public IList<QuizDTO> GetQuizs()
        {
            return db.Quiz.Select(p => new QuizDTO
            {
                Id = p.Id,
                QType = p.QType,
                QName = p.QName,
                QuestionText = p.QuestionText,
                QSkill = p.QSkill,
                DefaultMask = p.DefaultMask,
                TimeCreate = p.TimeCreate,
                TimeUpdate = p.TimeUpdate,
                QLevel = p.QLevel,
                MultipleChoices = p.MultipleChoices.ToList(),
                TrueFalses = p.TrueFalses.ToList()
            }).ToList();
        }

        // GET: api/Quizs/5
        [ResponseType(typeof(QuizDTO))]
        public async Task<IHttpActionResult> GetQuizs(int id)
        {
            var quiz = await db.Quiz.Select(p =>
                new QuizDTO()
                {
                    Id = p.Id,
                    QType = p.QType,
                    QName = p.QName,
                    QuestionText = p.QuestionText,
                    QSkill = p.QSkill,
                    DefaultMask = p.DefaultMask,
                    TimeCreate = p.TimeCreate,
                    TimeUpdate = p.TimeUpdate,
                    QLevel = p.QLevel,
                    MultipleChoices = p.MultipleChoices.ToList(),
                    TrueFalses = p.TrueFalses.ToList()

                }).SingleOrDefaultAsync(p => p.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        /*public async Task<IHttpActionResult> GetQuiz(int id)
        {
            Quiz quiz = await db.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }*/

        // PUT: api/Quizs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuiz(int id, Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quiz.Id)
            {
                return BadRequest();
            }

            db.Entry(quiz).State = EntityState.Modified;
            foreach (var item in quiz.MultipleChoices)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            foreach (var item in quiz.TrueFalses)
            {
                db.Entry(item).State = EntityState.Modified;

            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
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

        // POST: api/Quizs
        [ResponseType(typeof(Quiz))]
        public async Task<IHttpActionResult> PostQuiz(Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Quiz.Add(quiz);
            await db.SaveChangesAsync();

            //add khóa ngoại

            var dto = new
            {
                Id = quiz.Id,
                QType = quiz.QType,
                QName = quiz.QName,
                QuestionText = quiz.QuestionText,
                QSkill = quiz.QSkill,
                DefaultMask = quiz.DefaultMask,
                TimeCreate = quiz.TimeCreate,
                TimeUpdate = quiz.TimeUpdate,
                QLevel = quiz.QLevel,
            };

            return CreatedAtRoute("DefaultApi", new { id = quiz.Id }, dto);
        }

        // DELETE: api/Quizs/5
        [ResponseType(typeof(Quiz))]
        public async Task<IHttpActionResult> DeleteQuiz(int id)
        {
            Quiz quiz = await db.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            db.Quiz.Remove(quiz);
            await db.SaveChangesAsync();

            return Ok(quiz);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuizExists(int id)
        {
            return db.Quiz.Count(e => e.Id == id) > 0;
        }
    }
}