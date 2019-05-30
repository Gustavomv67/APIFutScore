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
    public class EscanteiosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Escanteios/Jogo
        [HttpGet]
        public IQueryable<Escanteio> Jogo(int codigo)
        {
            return db.Escanteios.Include("jogo").Include("time").Where(a => a.jogo.id == codigo);
        }

        // PUT: api/Escanteios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEscanteio(int id, Escanteio escanteio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != escanteio.id)
            {
                return BadRequest();
            }

            db.Entry(escanteio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscanteioExists(id))
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

        // POST: api/Escanteios
        [ResponseType(typeof(Escanteio))]
        public IHttpActionResult PostEscanteio(Escanteio escanteio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Escanteios.Add(escanteio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = escanteio.id }, escanteio);
        }

        // DELETE: api/Escanteios/5
        [ResponseType(typeof(Escanteio))]
        public IHttpActionResult DeleteEscanteio(int id)
        {
            Escanteio escanteio = db.Escanteios.Find(id);
            if (escanteio == null)
            {
                return NotFound();
            }

            db.Escanteios.Remove(escanteio);
            db.SaveChanges();

            return Ok(escanteio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EscanteioExists(int id)
        {
            return db.Escanteios.Count(e => e.id == id) > 0;
        }
    }
}