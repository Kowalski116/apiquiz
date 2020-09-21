using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BK_API_QUIZ_01.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Windows.Forms;
using BK_API_QUIZ_01.Filters;
using BK_API_QUIZ_01.DAL;

namespace BK_API_QUIZ_01.Controllers
{
    [AllowAnonymous]
    public class TokenController : ApiController
    {
        private APIQuizDBContext db = new APIQuizDBContext();
        // THis is naive endpoint for demo, it should use Basic authentication to provide token or POST request
        [HttpGet]
        [Route("api/token/{username}/{password}")]
        public string Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                return JwtManager.GenerateToken(username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
        [HttpPost]
        [Route("api/register/{username}/{password}")]
        [ResponseType(typeof(User))]
        public string Post(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            User user1 = db.Users
            .FirstOrDefault(u => u.UserName == username);
            if (user1 != null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            var user = new User()
            {
                UserName = username,
                Password = password
            };
            db.Users.Add(user);
            db.SaveChanges();
            return JwtManager.GenerateToken(username);
        }
        public bool CheckUser(string username, string password)
        {
            // should check in the database
            User user = db.Users
            .FirstOrDefault(u => u.UserName == username
                     && u.Password == password);
            if (user == null)
            {
                return false;
            }
            return true;
        }
        
    }

}