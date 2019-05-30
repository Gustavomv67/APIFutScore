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
    public class FaltasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Penaltis/Jogo
        [HttpGet]
        public IQueryable<Falta> Jogo(int codigo)
        {
            return db.Faltas.Include("jogo").Include("time").Include("jogador").Where(a => a.jogo.id == codigo);
        }

        // PUT: api/Faltas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFalta(int id, Falta falta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != falta.id)
            {
                return BadRequest();
            }

            db.Entry(falta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaltaExists(id))
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

        // POST: api/Faltas
        [ResponseType(typeof(Falta))]
        public IHttpActionResult PostFalta(Falta falta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faltas.Add(falta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = falta.id }, falta);
        }

        // DELETE: api/Faltas/5
        [ResponseType(typeof(Falta))]
        public IHttpActionResult DeleteFalta(int id)
        {
            Falta falta = db.Faltas.Find(id);
            if (falta == null)
            {
                return NotFound();
            }

            db.Faltas.Remove(falta);
            db.SaveChanges();

            return Ok(falta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FaltaExists(int id)
        {
            return db.Faltas.Count(e => e.id == id) > 0;
        }
    }
}