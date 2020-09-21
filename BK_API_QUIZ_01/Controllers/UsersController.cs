using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BK_API_QUIZ_01.Models;
using BK_API_QUIZ_01.Filters;
using BK_API_QUIZ_01.DAL;

namespace BK_API_QUIZ_01.Controllers
{
    [JwtAuthentication]
    public class UsersController : ApiController
    {
        private APIQuizDBContext db = new APIQuizDBContext();

        // GET: api/Users
        [HttpGet]
        [Route("api/logged/{username}")]
        public bool logged(string username)
        {
            var Username = System.Web.HttpContext.Current.User.Identity.Name;
            return username == Username;

        }
        [Authorize(Roles = "admin")]
        public List<User> GetUsers()
        {

            return db.Users.ToList();
        }

        // GET: api/Users/5
        [Route("api/getprofile")]
        public User getProfile()
        {
            var Username = System.Web.HttpContext.Current.User.Identity.Name;
            User user = db.Users
            .FirstOrDefault(u => u.UserName == Username);
            return user;
        }
        [Authorize(Roles = "admin")]
        [Route("api/users/{Id}")]
        public User GetUser(int Id)
        {
            User user = db.Users
            .FirstOrDefault(u => u.Id == Id);
            return user;
        }

        // PUT: api/Users/5
        [Authorize(Roles = "admin")]
        [Route("api/updateprofile/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Users = System.Web.HttpContext.Current.User.Identity.Name;

            if (id != user.Id ||(user.UserName != Users && Users!="admin"))
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        
        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [Route("api/deleteuser/{id}")]
        [ResponseType(typeof(User))]

        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}