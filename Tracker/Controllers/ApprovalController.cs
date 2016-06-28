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
    public class ApprovalController : ApiController
    {
        private TrackerContext db = new TrackerContext();

        // GET api/Approval
        public IQueryable<Approval> GetApprovals()
        {
            return db.Approvals;
        }

        // GET api/Approval/5
        [ResponseType(typeof(Approval))]
        public async Task<IHttpActionResult> GetApproval(int id)
        {
            Approval approval = await db.Approvals.FindAsync(id);
            if (approval == null)
            {
                return NotFound();
            }

            return Ok(approval);
        }

        // PUT api/Approval/5
        public async Task<IHttpActionResult> PutApproval(int id, Approval approval)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != approval.Id)
            {
                return BadRequest();
            }

            db.Entry(approval).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovalExists(id))
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

        // POST api/Approval
        [ResponseType(typeof(Approval))]
        public async Task<IHttpActionResult> PostApproval(Approval approval)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Approvals.Add(approval);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = approval.Id }, approval);
        }

        // DELETE api/Approval/5
        [ResponseType(typeof(Approval))]
        public async Task<IHttpActionResult> DeleteApproval(int id)
        {
            Approval approval = await db.Approvals.FindAsync(id);
            if (approval == null)
            {
                return NotFound();
            }

            db.Approvals.Remove(approval);
            await db.SaveChangesAsync();

            return Ok(approval);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApprovalExists(int id)
        {
            return db.Approvals.Count(e => e.Id == id) > 0;
        }
    }
}