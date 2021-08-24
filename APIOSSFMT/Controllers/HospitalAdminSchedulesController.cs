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
    public class HospitalAdminSchedulesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/HospitalAdminSchedules
        public IQueryable<HospitalAdminSchedule> GethospitalAdminSchedules()
        {
            return db.hospitalAdminSchedules;
        }

        // GET: api/HospitalAdminSchedules/5
        [ResponseType(typeof(HospitalAdminSchedule))]
        public IHttpActionResult GetHospitalAdminSchedule(int id)
        {
            HospitalAdminSchedule hospitalAdminSchedule = db.hospitalAdminSchedules.Find(id);
            if (hospitalAdminSchedule == null)
            {
                return NotFound();
            }

            return Ok(hospitalAdminSchedule);
        }

        // PUT: api/HospitalAdminSchedules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHospitalAdminSchedule(int id, HospitalAdminSchedule hospitalAdminSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospitalAdminSchedule.Sch_Id)
            {
                return BadRequest();
            }

            db.Entry(hospitalAdminSchedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAdminScheduleExists(id))
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

        // POST: api/HospitalAdminSchedules
        [ResponseType(typeof(HospitalAdminSchedule))]
        public IHttpActionResult PostHospitalAdminSchedule(HospitalAdminSchedule hospitalAdminSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.hospitalAdminSchedules.Add(hospitalAdminSchedule);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hospitalAdminSchedule.Sch_Id }, hospitalAdminSchedule);
        }

        // DELETE: api/HospitalAdminSchedules/5
        [ResponseType(typeof(HospitalAdminSchedule))]
        public IHttpActionResult DeleteHospitalAdminSchedule(int id)
        {
            HospitalAdminSchedule hospitalAdminSchedule = db.hospitalAdminSchedules.Find(id);
            if (hospitalAdminSchedule == null)
            {
                return NotFound();
            }

            db.hospitalAdminSchedules.Remove(hospitalAdminSchedule);
            db.SaveChanges();

            return Ok(hospitalAdminSchedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalAdminScheduleExists(int id)
        {
            return db.hospitalAdminSchedules.Count(e => e.Sch_Id == id) > 0;
        }
    }
}