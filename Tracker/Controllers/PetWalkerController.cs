using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Tracker;
using Tracker.Models;

namespace Tracker.Controllers
{
    public class PetWalkerController : ApiController
    {
        private TrackerContext db = new TrackerContext();

        // GET api/PetWalker
        public IQueryable<PetWalker> GetPetWalkers()
        {
            return db.PetWalkers;
        }

        // GET api/PetWalker/5
        [ResponseType(typeof(PetWalker))]
        public async Task<IHttpActionResult> GetPetWalker(int id)
        {
            PetWalker petwalker = await db.PetWalkers.FindAsync(id);
            if (petwalker == null)
            {
                return NotFound();
            }

            return Ok(petwalker);
        }

        // PUT api/PetWalker/5
        public async Task<IHttpActionResult> PutPetWalker(int id, PetWalker petwalker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petwalker.Id)
            {
                return BadRequest();
            }

            db.Entry(petwalker).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetWalkerExists(id))
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

        // POST api/PetWalker
        [ResponseType(typeof(PetWalker))]
        public async Task<IHttpActionResult> PostPetWalker(PetWalker petwalker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetWalkers.Add(petwalker);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = petwalker.Id }, petwalker);
        }

        // DELETE api/PetWalker/5
        [ResponseType(typeof(PetWalker))]
        public async Task<IHttpActionResult> DeletePetWalker(int id)
        {
            PetWalker petwalker = await db.PetWalkers.FindAsync(id);
            if (petwalker == null)
            {
                return NotFound();
            }

            db.PetWalkers.Remove(petwalker);
            await db.SaveChangesAsync();

            return Ok(petwalker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetWalkerExists(int id)
        {
            return db.PetWalkers.Count(e => e.Id == id) > 0;
        }
    }
}