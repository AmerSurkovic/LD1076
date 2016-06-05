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
using WebServis.Models;
using WebServis.SRSPS.Models;

namespace WebServis.SRSPS.Controllers
{
    public class Termin1Controller : ApiController
    {
        private SRSPSDB db = new SRSPSDB();

        // GET: api/Termin1
        public IQueryable<Termin> GetTermins()
        {
            return db.Termins;
        }

        // GET: api/Termin1/5
        [ResponseType(typeof(Termin))]
        public IHttpActionResult GetTermin(int id)
        {
            Termin termin = db.Termins.Find(id);
            if (termin == null)
            {
                return NotFound();
            }

            return Ok(termin);
        }

        // PUT: api/Termin1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTermin(int id, Termin termin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != termin.TerminID)
            {
                return BadRequest();
            }

            db.Entry(termin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerminExists(id))
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

        // POST: api/Termin1
        [ResponseType(typeof(Termin))]
        public IHttpActionResult PostTermin(Termin termin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Termins.Add(termin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = termin.TerminID }, termin);
        }

        // DELETE: api/Termin1/5
        [ResponseType(typeof(Termin))]
        public IHttpActionResult DeleteTermin(int id)
        {
            Termin termin = db.Termins.Find(id);
            if (termin == null)
            {
                return NotFound();
            }

            db.Termins.Remove(termin);
            db.SaveChanges();

            return Ok(termin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TerminExists(int id)
        {
            return db.Termins.Count(e => e.TerminID == id) > 0;
        }
    }
}