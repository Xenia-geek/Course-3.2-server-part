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
    public class ListLabTeachersController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/ListLabTeachers
        public IQueryable<ListLabTeacher> GetListLabTeachers()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.ListLabTeachers;
        }

        // GET: api/ListLabTeachers/5
        [ResponseType(typeof(ListLabTeacher))]
        public IHttpActionResult GetListLabTeacher(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ListLabTeacher listLabTeacher = db.ListLabTeachers.Find(id);
            if (listLabTeacher == null)
            {
                return NotFound();
            }

            return Ok(listLabTeacher);
        }

        // PUT: api/ListLabTeachers/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListLabTeacher(int id, ListLabTeacher listLabTeacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listLabTeacher.IDListLabTeacher)
            {
                return BadRequest();
            }

            db.Entry(listLabTeacher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListLabTeacherExists(id))
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

        // POST: api/ListLabTeachers
        [Authorize]
        [ResponseType(typeof(ListLabTeacher))]
        public IHttpActionResult PostListLabTeacher(ListLabTeacher listLabTeacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListLabTeachers.Add(listLabTeacher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = listLabTeacher.IDListLabTeacher }, listLabTeacher);
        }

        // DELETE: api/ListLabTeachers/5
        [Authorize]
        [ResponseType(typeof(ListLabTeacher))]
        public IHttpActionResult DeleteListLabTeacher(int id)
        {
            ListLabTeacher listLabTeacher = db.ListLabTeachers.Find(id);
            if (listLabTeacher == null)
            {
                return NotFound();
            }

            db.ListLabTeachers.Remove(listLabTeacher);
            db.SaveChanges();

            return Ok(listLabTeacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListLabTeacherExists(int id)
        {
            return db.ListLabTeachers.Count(e => e.IDListLabTeacher == id) > 0;
        }
    }
}