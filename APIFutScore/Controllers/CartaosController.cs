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
    public class CartaosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Penaltis/Jogo
        [HttpGet]
        public IQueryable<Cartao> Jogo(int codigo)
        {
            return db.Cartaos.Include("jogo").Include("jogador").Where(a => a.jogo.id == codigo);
        }

        // PUT: api/Cartaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCartao(int id, Cartao cartao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartao.id)
            {
                return BadRequest();
            }

            db.Entry(cartao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoExists(id))
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

        // POST: api/Cartaos
        [ResponseType(typeof(Cartao))]
        public IHttpActionResult PostCartao(Cartao cartao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cartaos.Add(cartao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cartao.id }, cartao);
        }

        // DELETE: api/Cartaos/5
        [ResponseType(typeof(Cartao))]
        public IHttpActionResult DeleteCartao(int id)
        {
            Cartao cartao = db.Cartaos.Find(id);
            if (cartao == null)
            {
                return NotFound();
            }

            db.Cartaos.Remove(cartao);
            db.SaveChanges();

            return Ok(cartao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartaoExists(int id)
        {
            return db.Cartaos.Count(e => e.id == id) > 0;
        }
    }
}