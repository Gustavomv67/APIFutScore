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
    public class EquipesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Equipes
        public IQueryable<Equipe> GetEquipes()
        {
            return db.Equipes;
        }

        // GET: api/Equipes/5
        [ResponseType(typeof(Equipe))]
        public IHttpActionResult GetEquipe(int id)
        {
            Equipe equipe = db.Equipes.Find(id);
            if (equipe == null)
            {
                return NotFound();
            }

            return Ok(equipe);
        }

        // PUT: api/Equipes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEquipe(int id, Equipe equipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipe.id)
            {
                return BadRequest();
            }

            db.Entry(equipe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipeExists(id))
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

        // POST: api/Equipes
        [ResponseType(typeof(Equipe))]
        public IHttpActionResult PostEquipe(Equipe equipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Equipes.Add(equipe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = equipe.id }, equipe);
        }

        // DELETE: api/Equipes/5
        [ResponseType(typeof(Equipe))]
        public IHttpActionResult DeleteEquipe(int id)
        {
            Equipe equipe = db.Equipes.Find(id);
            if (equipe == null)
            {
                return NotFound();
            }

            db.Equipes.Remove(equipe);
            db.SaveChanges();

            return Ok(equipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquipeExists(int id)
        {
            return db.Equipes.Count(e => e.id == id) > 0;
        }
    }
}