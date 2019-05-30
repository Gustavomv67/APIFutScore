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
    public class ResultadosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Resultados
        public IQueryable<Resultado> GetResultadoes()
        {
            return db.Resultadoes.Include("jogo").Include("jogo.mandante").Include("jogo.visitante");
        }

        // GET: api/Resultados/5
        [ResponseType(typeof(Resultado))]
        public IHttpActionResult GetResultado(int id)
        {
            Resultado resultado = db.Resultadoes.Include("jogo.mandante").Include("jogo.visitante").First(a => a.jogo.id == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        // PUT: api/Resultados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResultado(int id, Resultado resultado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resultado.id)
            {
                return BadRequest();
            }

            db.Entry(resultado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultadoExists(id))
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

        // POST: api/Resultados
        [ResponseType(typeof(Resultado))]
        public IHttpActionResult PostResultado(Resultado resultado, int jogo, int time)
        {
            resultado.jogo = db.Jogoes.First(a => a.id == time);
            resultado.time = db.Equipes.First(a => a.id == time);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Resultadoes.Add(resultado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resultado.id }, resultado);
        }

        // DELETE: api/Resultados/5
        [ResponseType(typeof(Resultado))]
        public IHttpActionResult DeleteResultado(int id)
        {
            Resultado resultado = db.Resultadoes.Find(id);
            if (resultado == null)
            {
                return NotFound();
            }

            db.Resultadoes.Remove(resultado);
            db.SaveChanges();

            return Ok(resultado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResultadoExists(int id)
        {
            return db.Resultadoes.Count(e => e.id == id) > 0;
        }
    }
}