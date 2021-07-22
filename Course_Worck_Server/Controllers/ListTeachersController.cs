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
    public class ListTeachersController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/ListTeachers
        [Authorize]
        public IQueryable<ListTeacher> GetListTeachers()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.ListTeachers;
        }

        // GET: api/ListTeachers/5
        [ResponseType(typeof(ListTeacher))]
        public IHttpActionResult GetListTeacher(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ListTeacher listTeacher = db.ListTeachers.Find(id);
            if (listTeacher == null)
            {
                return NotFound();
            }

            return Ok(listTeacher);
        }

        // PUT: api/ListTeachers/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListTeacher(int id, ListTeacher listTeacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listTeacher.IDTeacher)
            {
                return BadRequest();
            }

            db.Entry(listTeacher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListTeacherExists(id))
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

        // POST: api/ListTeachers
        [Authorize]
        [ResponseType(typeof(ListTeacher))]
        public IHttpActionResult PostListTeacher(ListTeacher listTeacher)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListTeachers.Add(listTeacher);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ListTeacherExists(listTeacher.IDTeacher))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = listTeacher.IDTeacher }, listTeacher);
        }

        // DELETE: api/ListTeachers/5
        [Authorize]
        [ResponseType(typeof(ListTeacher))]
        public IHttpActionResult DeleteListTeacher(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ListTeacher listTeacher = db.ListTeachers.Find(id);
            if (listTeacher == null)
            {
                return NotFound();
            }

            db.ListTeachers.Remove(listTeacher);
            db.SaveChanges();

            return Ok(listTeacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListTeacherExists(int id)
        {
            return db.ListTeachers.Count(e => e.IDTeacher == id) > 0;
        }
    }
}