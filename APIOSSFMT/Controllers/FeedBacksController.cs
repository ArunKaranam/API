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
using MVCProject.Models;

namespace APIOSSFMT.Controllers
{
    public class FeedBacksController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/FeedBacks
        public IQueryable<FeedBack> GetfeedBacks()
        {
            return db.feedBacks;
        }

        // GET: api/FeedBacks/5
        [ResponseType(typeof(FeedBack))]
        public IHttpActionResult GetFeedBack(int id)
        {
            FeedBack feedBack = db.feedBacks.Find(id);
            if (feedBack == null)
            {
                return NotFound();
            }

            return Ok(feedBack);
        }

        // PUT: api/FeedBacks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeedBack(int id, FeedBack feedBack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedBack.F_Id)
            {
                return BadRequest();
            }

            db.Entry(feedBack).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedBackExists(id))
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

        // POST: api/FeedBacks
        [ResponseType(typeof(FeedBack))]
        public IHttpActionResult PostFeedBack(FeedBack feedBack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.feedBacks.Add(feedBack);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = feedBack.F_Id }, feedBack);
        }

        // DELETE: api/FeedBacks/5
        [ResponseType(typeof(FeedBack))]
        public IHttpActionResult DeleteFeedBack(int id)
        {
            FeedBack feedBack = db.feedBacks.Find(id);
            if (feedBack == null)
            {
                return NotFound();
            }

            db.feedBacks.Remove(feedBack);
            db.SaveChanges();

            return Ok(feedBack);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedBackExists(int id)
        {
            return db.feedBacks.Count(e => e.F_Id == id) > 0;
        }
    }
}