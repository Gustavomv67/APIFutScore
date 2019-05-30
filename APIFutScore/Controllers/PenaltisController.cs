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
    public class PenaltisController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Penaltis/Jogo
        [HttpGet]
        public IQueryable<Penalti> Jogo(int codigo)
        {
            return db.Penaltis.Include("jogo").Include("time").Include("jogador").Where(a => a.jogo.id == codigo);
        }


        

        // PUT: api/Penaltis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPenalti(int id, Penalti penalti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != penalti.id)
            {
                return BadRequest();
            }

            db.Entry(penalti).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PenaltiExists(id))
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

        // POST: api/Penaltis
        [ResponseType(typeof(Penalti))]
        public IHttpActionResult PostPenalti(Penalti penalti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Penaltis.Add(penalti);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = penalti.id }, penalti);
        }

        // DELETE: api/Penaltis/5
        [ResponseType(typeof(Penalti))]
        public IHttpActionResult DeletePenalti(int id)
        {
            Penalti penalti = db.Penaltis.Find(id);
            if (penalti == null)
            {
                return NotFound();
            }

            db.Penaltis.Remove(penalti);
            db.SaveChanges();

            return Ok(penalti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PenaltiExists(int id)
        {
            return db.Penaltis.Count(e => e.id == id) > 0;
        }
    }
}