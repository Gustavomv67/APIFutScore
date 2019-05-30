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
    public class EscalacaosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Escalacao/Jogo
        [HttpGet]
        public IQueryable<Escalacao> Jogo(int codigo)
        {
            return db.Escalacaos.Include("jogo").Include("time").Include("jogador").Where(a => a.jogo.id == codigo);
        }

        // PUT: api/Escalacaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEscalacao(int id, Escalacao escalacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != escalacao.id)
            {
                return BadRequest();
            }

            db.Entry(escalacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscalacaoExists(id))
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

        // POST: api/Escalacaos
        [ResponseType(typeof(Escalacao))]
        public IHttpActionResult PostEscalacao(Escalacao escalacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Escalacaos.Add(escalacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = escalacao.id }, escalacao);
        }

        // DELETE: api/Escalacaos/5
        [ResponseType(typeof(Escalacao))]
        public IHttpActionResult DeleteEscalacao(int id)
        {
            Escalacao escalacao = db.Escalacaos.Find(id);
            if (escalacao == null)
            {
                return NotFound();
            }

            db.Escalacaos.Remove(escalacao);
            db.SaveChanges();

            return Ok(escalacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EscalacaoExists(int id)
        {
            return db.Escalacaos.Count(e => e.id == id) > 0;
        }
    }
}