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
    public class Sala1Controller : ApiController
    {
        private DataBaze db = new DataBaze();

        // GET: api/Sala1
        public IQueryable<Sala> GetSale()
        {
            return db.Sale;
        }

        // GET: api/Sala1/5
        [ResponseType(typeof(Sala))]
        public IHttpActionResult GetSala(int id)
        {
            Sala sala = db.Sale.Find(id);
            if (sala == null)
            {
                return NotFound();
            }

            return Ok(sala);
        }

        // PUT: api/Sala1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSala(int id, Sala sala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sala.salaID)
            {
                return BadRequest();
            }

            db.Entry(sala).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(id))
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

        // POST: api/Sala1
        [ResponseType(typeof(Sala))]
        public IHttpActionResult PostSala(Sala sala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sale.Add(sala);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sala.salaID }, sala);
        }

        // DELETE: api/Sala1/5
        [ResponseType(typeof(Sala))]
        public IHttpActionResult DeleteSala(int id)
        {
            Sala sala = db.Sale.Find(id);
            if (sala == null)
            {
                return NotFound();
            }

            db.Sale.Remove(sala);
            db.SaveChanges();

            return Ok(sala);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalaExists(int id)
        {
            return db.Sale.Count(e => e.salaID == id) > 0;
        }
    }
}