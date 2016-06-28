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
    public class PetOwnerController : ApiController
    {
        private TrackerContext db = new TrackerContext();

        // GET api/PetOwner
        public IQueryable<PetOwner> GetPetOwners()
        {
            return db.PetOwners;
        }

        // GET api/PetOwner/5
        [ResponseType(typeof(PetOwner))]
        public async Task<IHttpActionResult> GetPetOwner(int id)
        {
            PetOwner petowner = await db.PetOwners.FindAsync(id);
            if (petowner == null)
            {
                return NotFound();
            }

            return Ok(petowner);
        }

        // PUT api/PetOwner/5
        public async Task<IHttpActionResult> PutPetOwner(int id, PetOwner petowner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petowner.Id)
            {
                return BadRequest();
            }

            db.Entry(petowner).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetOwnerExists(id))
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

        // POST api/PetOwner
        [ResponseType(typeof(PetOwner))]
        public async Task<IHttpActionResult> PostPetOwner(PetOwner petowner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetOwners.Add(petowner);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = petowner.Id }, petowner);
        }

        // DELETE api/PetOwner/5
        [ResponseType(typeof(PetOwner))]
        public async Task<IHttpActionResult> DeletePetOwner(int id)
        {
            PetOwner petowner = await db.PetOwners.FindAsync(id);
            if (petowner == null)
            {
                return NotFound();
            }

            db.PetOwners.Remove(petowner);
            await db.SaveChangesAsync();

            return Ok(petowner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetOwnerExists(int id)
        {
            return db.PetOwners.Count(e => e.Id == id) > 0;
        }
    }
}