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
    public class JogosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Jogos
        public IQueryable<Jogo> GetJogoes()
        {
            return db.Jogoes.Include("mandante").Include("visitante");
        }

        // GET: api/Jogos/5
        [ResponseType(typeof(Jogo))]
        public IHttpActionResult GetJogo(int id)
        {
            Jogo jogo = db.Jogoes.Find(id);
            if (jogo == null)
            {
                return NotFound();
            }

            return Ok(jogo);
        }

        // PUT: api/Jogos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJogo(int id, Jogo jogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jogo.id)
            {
                return BadRequest();
            }

            db.Entry(jogo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogoExists(id))
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

        // POST: api/Jogos
        [ResponseType(typeof(Jogo))]
        public IHttpActionResult PostJogo(Jogo jogo, int mandante, int visitante)
        {
            jogo.mandante = db.Equipes.First(a => a.id == mandante);
            jogo.visitante = db.Equipes.First(a => a.id == visitante);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jogoes.Add(jogo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jogo.id }, jogo);
        }

        // DELETE: api/Jogos/5
        [ResponseType(typeof(Jogo))]
        public IHttpActionResult DeleteJogo(int id)
        {
            Jogo jogo = db.Jogoes.Find(id);
            if (jogo == null)
            {
                return NotFound();
            }

            db.Jogoes.Remove(jogo);
            db.SaveChanges();

            return Ok(jogo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JogoExists(int id)
        {
            return db.Jogoes.Count(e => e.id == id) > 0;
        }
    }
}