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
    public class PatientMedicalReportsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/PatientMedicalReports
        public IQueryable<PatientMedicalReport> GetpatientMedicalReports()
        {
            return db.patientMedicalReports;
        }

        // GET: api/PatientMedicalReports/5
        [ResponseType(typeof(PatientMedicalReport))]
        public IHttpActionResult GetPatientMedicalReport(string id)
        {
            PatientMedicalReport patientMedicalReport = db.patientMedicalReports.Find(id);
            if (patientMedicalReport == null)
            {
                return NotFound();
            }

            return Ok(patientMedicalReport);
        }

        // PUT: api/PatientMedicalReports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatientMedicalReport(string id, PatientMedicalReport patientMedicalReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientMedicalReport.New_P_Id)
            {
                return BadRequest();
            }

            db.Entry(patientMedicalReport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientMedicalReportExists(id))
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

        // POST: api/PatientMedicalReports
        [ResponseType(typeof(PatientMedicalReport))]
        public IHttpActionResult PostPatientMedicalReport(PatientMedicalReport patientMedicalReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.patientMedicalReports.Add(patientMedicalReport);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PatientMedicalReportExists(patientMedicalReport.New_P_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = patientMedicalReport.New_P_Id }, patientMedicalReport);
        }

        // DELETE: api/PatientMedicalReports/5
        [ResponseType(typeof(PatientMedicalReport))]
        public IHttpActionResult DeletePatientMedicalReport(string id)
        {
            PatientMedicalReport patientMedicalReport = db.patientMedicalReports.Find(id);
            if (patientMedicalReport == null)
            {
                return NotFound();
            }

            db.patientMedicalReports.Remove(patientMedicalReport);
            db.SaveChanges();

            return Ok(patientMedicalReport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientMedicalReportExists(string id)
        {
            return db.patientMedicalReports.Count(e => e.New_P_Id == id) > 0;
        }
    }
}