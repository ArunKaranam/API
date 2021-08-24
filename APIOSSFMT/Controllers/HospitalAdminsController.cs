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
    public class HospitalAdminsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/HospitalAdmins
        public IQueryable<HospitalAdmin> GethospitalAdmins()
        {
            return db.hospitalAdmins;
        }

        // GET: api/HospitalAdmins/5
        [ResponseType(typeof(HospitalAdmin))]
        public IHttpActionResult GetHospitalAdmin(int id)
        {
            HospitalAdmin hospitalAdmin = db.hospitalAdmins.Find(id);
            if (hospitalAdmin == null)
            {
                return NotFound();
            }

            return Ok(hospitalAdmin);
        }

        // PUT: api/HospitalAdmins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHospitalAdmin(int id, HospitalAdmin hospitalAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospitalAdmin.H_Id)
            {
                return BadRequest();
            }

            db.Entry(hospitalAdmin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAdminExists(id))
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

        // POST: api/HospitalAdmins
        [ResponseType(typeof(HospitalAdmin))]
        public IHttpActionResult PostHospitalAdmin(HospitalAdmin hospitalAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.hospitalAdmins.Add(hospitalAdmin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hospitalAdmin.H_Id }, hospitalAdmin);
        }

        // DELETE: api/HospitalAdmins/5
        [ResponseType(typeof(HospitalAdmin))]
        public IHttpActionResult DeleteHospitalAdmin(int id)
        {
            HospitalAdmin hospitalAdmin = db.hospitalAdmins.Find(id);
            if (hospitalAdmin == null)
            {
                return NotFound();
            }

            db.hospitalAdmins.Remove(hospitalAdmin);
            db.SaveChanges();

            return Ok(hospitalAdmin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalAdminExists(int id)
        {
            return db.hospitalAdmins.Count(e => e.H_Id == id) > 0;
        }
    }
}