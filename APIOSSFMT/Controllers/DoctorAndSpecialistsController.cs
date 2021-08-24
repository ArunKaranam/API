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
    public class DoctorAndSpecialistsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/DoctorAndSpecialists
        public IQueryable<DoctorAndSpecialist> GetdoctorAndSpecialists()
        {
            return db.doctorAndSpecialists;
        }

        // GET: api/DoctorAndSpecialists/5
        [ResponseType(typeof(DoctorAndSpecialist))]
        public IHttpActionResult GetDoctorAndSpecialist(int id)
        {
            DoctorAndSpecialist doctorAndSpecialist = db.doctorAndSpecialists.Find(id);
            if (doctorAndSpecialist == null)
            {
                return NotFound();
            }

            return Ok(doctorAndSpecialist);
        }

        // PUT: api/DoctorAndSpecialists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoctorAndSpecialist(int id, DoctorAndSpecialist doctorAndSpecialist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctorAndSpecialist.S_Id)
            {
                return BadRequest();
            }

            db.Entry(doctorAndSpecialist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorAndSpecialistExists(id))
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

        // POST: api/DoctorAndSpecialists
        [ResponseType(typeof(DoctorAndSpecialist))]
        public IHttpActionResult PostDoctorAndSpecialist(DoctorAndSpecialist doctorAndSpecialist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.doctorAndSpecialists.Add(doctorAndSpecialist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = doctorAndSpecialist.S_Id }, doctorAndSpecialist);
        }

        // DELETE: api/DoctorAndSpecialists/5
        [ResponseType(typeof(DoctorAndSpecialist))]
        public IHttpActionResult DeleteDoctorAndSpecialist(int id)
        {
            DoctorAndSpecialist doctorAndSpecialist = db.doctorAndSpecialists.Find(id);
            if (doctorAndSpecialist == null)
            {
                return NotFound();
            }

            db.doctorAndSpecialists.Remove(doctorAndSpecialist);
            db.SaveChanges();

            return Ok(doctorAndSpecialist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorAndSpecialistExists(int id)
        {
            return db.doctorAndSpecialists.Count(e => e.S_Id == id) > 0;
        }
    }
}