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
    public class HelpsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Helps
        public IQueryable<Help> Gethelps()
        {
            return db.helps;
        }

        // GET: api/Helps/5
        [ResponseType(typeof(Help))]
        public IHttpActionResult GetHelp(int id)
        {
            Help help = db.helps.Find(id);
            if (help == null)
            {
                return NotFound();
            }

            return Ok(help);
        }

        // PUT: api/Helps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHelp(int id, Help help)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != help.I_Id)
            {
                return BadRequest();
            }

            db.Entry(help).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelpExists(id))
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

        // POST: api/Helps
        [ResponseType(typeof(Help))]
        public IHttpActionResult PostHelp(Help help)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.helps.Add(help);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = help.I_Id }, help);
        }

        // DELETE: api/Helps/5
        [ResponseType(typeof(Help))]
        public IHttpActionResult DeleteHelp(int id)
        {
            Help help = db.helps.Find(id);
            if (help == null)
            {
                return NotFound();
            }

            db.helps.Remove(help);
            db.SaveChanges();

            return Ok(help);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HelpExists(int id)
        {
            return db.helps.Count(e => e.I_Id == id) > 0;
        }
    }
}