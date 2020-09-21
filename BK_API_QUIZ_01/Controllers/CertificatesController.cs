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
    public class CertificatesController : ApiController
    {
        private APIQuizDBContext db = new APIQuizDBContext();

        // GET: api/Certificates
        public IQueryable<Certificate> GetCertificate()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Certificate;
        }

        // GET: api/Certificates/5
        [ResponseType(typeof(Certificate))]
        public async Task<IHttpActionResult> GetCertificate(int id)
        {
            Certificate certificate = await db.Certificate.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }

            return Ok(certificate);
        }

        // PUT: api/Certificates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCertificate(int id, Certificate certificate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != certificate.Id)
            {
                return BadRequest();
            }

            db.Entry(certificate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificateExists(id))
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

        // POST: api/Certificates
        [ResponseType(typeof(Certificate))]
        public async Task<IHttpActionResult> PostCertificate(Certificate certificate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Certificate.Add(certificate);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = certificate.Id }, certificate);
        }

        // DELETE: api/Certificates/5
        [ResponseType(typeof(Certificate))]
        public async Task<IHttpActionResult> DeleteCertificate(int id)
        {
            Certificate certificate = await db.Certificate.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }

            db.Certificate.Remove(certificate);
            await db.SaveChangesAsync();

            return Ok(certificate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CertificateExists(int id)
        {
            return db.Certificate.Count(e => e.Id == id) > 0;
        }
    }
}