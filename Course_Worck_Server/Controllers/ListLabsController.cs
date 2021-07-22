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
    public class ListLabsController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        //All
        // GET: api/ListLabs
        public IQueryable<ListLab> GetListLabs()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.ListLabs;
        }

        //OneElemByID
        // GET: api/ListLabs/5
        [ResponseType(typeof(ListLab))]
        public IHttpActionResult GetListLab(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ListLab listLab = db.ListLabs.Find(id);
            if (listLab == null)
            {
                return NotFound();
            }

            return Ok(listLab);
        }

        //UPDATE
        // PUT: api/ListLabs/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListLab(int id, ListLab listLab)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listLab.IDLab)
            {
                return BadRequest();
            }

            db.Entry(listLab).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListLabExists(id))
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

        //ADD
        // POST: api/ListLabs
        [Authorize]
        [ResponseType(typeof(ListLab))]
        public IHttpActionResult PostListLab(ListLab listLab)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListLabs.Add(listLab);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = listLab.IDLab }, listLab);
        }

        // DELETE: api/ListLabs/5
        [Authorize]
        [ResponseType(typeof(ListLab))]
        public IHttpActionResult DeleteListLab(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ListLab listLab = db.ListLabs.Find(id);
            if (listLab == null)
            {
                return NotFound();
            }

            db.ListLabs.Remove(listLab);
            db.SaveChanges();

            return Ok(listLab);
        }

        protected override void Dispose(bool disposing)
        {
           
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListLabExists(int id)
        {
            return db.ListLabs.Count(e => e.IDLab == id) > 0;
        }
    }
}