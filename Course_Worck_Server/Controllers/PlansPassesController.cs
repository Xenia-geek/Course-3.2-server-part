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
using Course_Worck_Server.Models;

namespace Course_Worck_Server.Controllers
{
    public class PlansPassesController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/PlansPasses
        public IQueryable<PlansPass> GetPlansPasses()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.PlansPasses;
        }

        // GET: api/PlansPasses/5
        [ResponseType(typeof(PlansPass))]
        public IHttpActionResult GetPlansPass(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            PlansPass plansPass = db.PlansPasses.Find(id);
            if (plansPass == null)
            {
                return NotFound();
            }

            return Ok(plansPass);
        }

        // PUT: api/PlansPasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlansPass(int id, PlansPass plansPass)
        {
            db.Configuration.ProxyCreationEnabled = false;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plansPass.IDPlan)
            {
                return BadRequest();
            }

            db.Entry(plansPass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlansPassExists(id))
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

        // POST: api/PlansPasses
        [ResponseType(typeof(PlansPass))]
        public IHttpActionResult PostPlansPass(PlansPass plansPass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlansPasses.Add(plansPass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = plansPass.IDPlan }, plansPass);
        }

        // DELETE: api/PlansPasses/5
        [ResponseType(typeof(PlansPass))]
        public IHttpActionResult DeletePlansPass(int id)
        {
            PlansPass plansPass = db.PlansPasses.Find(id);
            if (plansPass == null)
            {
                return NotFound();
            }

            db.PlansPasses.Remove(plansPass);
            db.SaveChanges();

            return Ok(plansPass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlansPassExists(int id)
        {
            return db.PlansPasses.Count(e => e.IDPlan == id) > 0;
        }
    }
}