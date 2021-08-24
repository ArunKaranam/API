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
using APIOSSFMT.Models;
using MVCProject.Models;

namespace APIOSSFMT.Controllers
{
    public class DoctorUpdatesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/DoctorUpdates
        public IQueryable<DoctorUpdate> GetdoctorUpdates()
        {
            return db.doctorUpdates;
        }

        // GET: api/DoctorUpdates/5
        [ResponseType(typeof(DoctorUpdate))]
        public IHttpActionResult GetDoctorUpdate(int id)
        {
            DoctorUpdate doctorUpdate = db.doctorUpdates.Find(id);
            if (doctorUpdate == null)
            {
                return NotFound();
            }

            return Ok(doctorUpdate);
        }

        // PUT: api/DoctorUpdates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoctorUpdate(int id, DoctorUpdate doctorUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctorUpdate.Up_Id)
            {
                return BadRequest();
            }

            db.Entry(doctorUpdate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorUpdateExists(id))
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

        // POST: api/DoctorUpdates
        [ResponseType(typeof(DoctorUpdate))]
        public IHttpActionResult PostDoctorUpdate(DoctorUpdate doctorUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.doctorUpdates.Add(doctorUpdate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = doctorUpdate.Up_Id }, doctorUpdate);
        }

        // DELETE: api/DoctorUpdates/5
        [ResponseType(typeof(DoctorUpdate))]
        public IHttpActionResult DeleteDoctorUpdate(int id)
        {
            DoctorUpdate doctorUpdate = db.doctorUpdates.Find(id);
            if (doctorUpdate == null)
            {
                return NotFound();
            }

            db.doctorUpdates.Remove(doctorUpdate);
            db.SaveChanges();

            return Ok(doctorUpdate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorUpdateExists(int id)
        {
            return db.doctorUpdates.Count(e => e.Up_Id == id) > 0;
        }
    }
}