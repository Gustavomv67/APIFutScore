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
using APIFutScore.Models;

namespace APIFutScore.Controllers
{
    public class GolsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Penaltis/Jogo
        [HttpGet]
        public IQueryable<Gols> Jogo(int codigo)
        {
            return db.Gols.Include("jogo").Include("time").Include("jogador").Where(a => a.jogo.id == codigo);
        }

        // PUT: api/Gols/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGols(int id, Gols gols)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gols.id)
            {
                return BadRequest();
            }

            db.Entry(gols).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GolsExists(id))
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

        // POST: api/Gols
        [ResponseType(typeof(Gols))]
        public IHttpActionResult PostGols(Gols gols)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gols.Add(gols);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gols.id }, gols);
        }

        // DELETE: api/Gols/5
        [ResponseType(typeof(Gols))]
        public IHttpActionResult DeleteGols(int id)
        {
            Gols gols = db.Gols.Find(id);
            if (gols == null)
            {
                return NotFound();
            }

            db.Gols.Remove(gols);
            db.SaveChanges();

            return Ok(gols);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GolsExists(int id)
        {
            return db.Gols.Count(e => e.id == id) > 0;
        }
    }
}