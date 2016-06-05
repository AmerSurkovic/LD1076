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
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class Predmet1Controller : ApiController
    {
        private DataBaze db = new DataBaze();

        // GET: api/Predmet1
        public IQueryable<Predmet> GetPredmeti()
        {
            return db.Predmeti;
        }

        // GET: api/Predmet1/5
        [ResponseType(typeof(Predmet))]
        public IHttpActionResult GetPredmet(int id)
        {
            Predmet predmet = db.Predmeti.Find(id);
            if (predmet == null)
            {
                return NotFound();
            }

            return Ok(predmet);
        }

        // PUT: api/Predmet1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPredmet(int id, Predmet predmet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != predmet.predmetID)
            {
                return BadRequest();
            }

            db.Entry(predmet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredmetExists(id))
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

        // POST: api/Predmet1
        [ResponseType(typeof(Predmet))]
        public IHttpActionResult PostPredmet(Predmet predmet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Predmeti.Add(predmet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = predmet.predmetID }, predmet);
        }

        // DELETE: api/Predmet1/5
        [ResponseType(typeof(Predmet))]
        public IHttpActionResult DeletePredmet(int id)
        {
            Predmet predmet = db.Predmeti.Find(id);
            if (predmet == null)
            {
                return NotFound();
            }

            db.Predmeti.Remove(predmet);
            db.SaveChanges();

            return Ok(predmet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PredmetExists(int id)
        {
            return db.Predmeti.Count(e => e.predmetID == id) > 0;
        }
    }
}