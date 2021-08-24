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
    public class TreatmentReportsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/TreatmentReports
        public IQueryable<TreatmentReport> GettreatmentReports()
        {
            return db.treatmentReports;
        }

        // GET: api/TreatmentReports/5
        [ResponseType(typeof(TreatmentReport))]
        public IHttpActionResult GetTreatmentReport(int id)
        {
            TreatmentReport treatmentReport = db.treatmentReports.Find(id);
            if (treatmentReport == null)
            {
                return NotFound();
            }

            return Ok(treatmentReport);
        }

        // PUT: api/TreatmentReports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTreatmentReport(int id, TreatmentReport treatmentReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != treatmentReport.Tr_Id)
            {
                return BadRequest();
            }

            db.Entry(treatmentReport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentReportExists(id))
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

        // POST: api/TreatmentReports
        [ResponseType(typeof(TreatmentReport))]
        public IHttpActionResult PostTreatmentReport(TreatmentReport treatmentReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.treatmentReports.Add(treatmentReport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = treatmentReport.Tr_Id }, treatmentReport);
        }

        // DELETE: api/TreatmentReports/5
        [ResponseType(typeof(TreatmentReport))]
        public IHttpActionResult DeleteTreatmentReport(int id)
        {
            TreatmentReport treatmentReport = db.treatmentReports.Find(id);
            if (treatmentReport == null)
            {
                return NotFound();
            }

            db.treatmentReports.Remove(treatmentReport);
            db.SaveChanges();

            return Ok(treatmentReport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TreatmentReportExists(int id)
        {
            return db.treatmentReports.Count(e => e.Tr_Id == id) > 0;
        }
    }
}