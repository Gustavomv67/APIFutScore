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
    public class SubtituicaoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Penaltis/Jogo
        [HttpGet]
        public IQueryable<Subtituicao> Jogo(int codigo)
        {
            return db.Subtituicaos.Include("jogo").Include("time").Include("jogadorSaiu").Include("jogadorEntrou").Where(a => a.jogo.id == codigo);
        }

        // PUT: api/Subtituicao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubtituicao(int id, Subtituicao subtituicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subtituicao.id)
            {
                return BadRequest();
            }

            db.Entry(subtituicao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubtituicaoExists(id))
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

        // POST: api/Subtituicao
        [ResponseType(typeof(Subtituicao))]
        public IHttpActionResult PostSubtituicao(Subtituicao subtituicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subtituicaos.Add(subtituicao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subtituicao.id }, subtituicao);
        }

        // DELETE: api/Subtituicao/5
        [ResponseType(typeof(Subtituicao))]
        public IHttpActionResult DeleteSubtituicao(int id)
        {
            Subtituicao subtituicao = db.Subtituicaos.Find(id);
            if (subtituicao == null)
            {
                return NotFound();
            }

            db.Subtituicaos.Remove(subtituicao);
            db.SaveChanges();

            return Ok(subtituicao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubtituicaoExists(int id)
        {
            return db.Subtituicaos.Count(e => e.id == id) > 0;
        }
    }
}