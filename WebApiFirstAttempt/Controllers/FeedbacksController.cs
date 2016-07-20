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
using WebApiFirstAttempt.DB;

namespace WebApiFirstAttempt.Controllers
{
    public class FeedbacksController : ApiController
    {
        private PractiseEntities db = new PractiseEntities();

        // GET: api/Feedbacks
        public IQueryable<tblFeedback> GettblFeedbacks()
        {
            return db.tblFeedbacks;
        }

        // GET: api/Feedbacks/5
        [ResponseType(typeof(tblFeedback))]
        public IHttpActionResult GettblFeedback(int id)
        {
            tblFeedback tblFeedback = db.tblFeedbacks.Find(id);
            if (tblFeedback == null)
            {
                return NotFound();
            }

            return Ok(tblFeedback);
        }

        // PUT: api/Feedbacks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblFeedback(int id, tblFeedback tblFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblFeedback.id)
            {
                return BadRequest();
            }

            db.Entry(tblFeedback).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblFeedbackExists(id))
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

        // POST: api/Feedbacks
        [ResponseType(typeof(tblFeedback))]
        public IHttpActionResult PosttblFeedback(tblFeedback tblFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblFeedbacks.Add(tblFeedback);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblFeedback.id }, tblFeedback);
        }

        // DELETE: api/Feedbacks/5
        [ResponseType(typeof(tblFeedback))]
        public IHttpActionResult DeletetblFeedback(int id)
        {
            tblFeedback tblFeedback = db.tblFeedbacks.Find(id);
            if (tblFeedback == null)
            {
                return NotFound();
            }

            db.tblFeedbacks.Remove(tblFeedback);
            db.SaveChanges();

            return Ok(tblFeedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblFeedbackExists(int id)
        {
            return db.tblFeedbacks.Count(e => e.id == id) > 0;
        }
    }
}