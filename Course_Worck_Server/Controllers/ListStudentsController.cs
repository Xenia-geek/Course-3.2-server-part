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
    public class ListStudentsController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/ListStudents
     
        public IQueryable<ListStudent> GetListStudents()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.ListStudents;
        }

        // GET: api/ListStudents/5
        [ResponseType(typeof(ListStudent))]
        public IHttpActionResult GetListStudent(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ListStudent listStudent = db.ListStudents.Find(id);
            if (listStudent == null)
            {
                return NotFound();
            }

            return Ok(listStudent);
        }

        // PUT: api/ListStudents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListStudent(int id, ListStudent listStudent)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listStudent.IDStudent)
            {
                return BadRequest();
            }

            db.Entry(listStudent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListStudentExists(id))
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

        // POST: api/ListStudents
        [Authorize]
        [ResponseType(typeof(ListStudent))]
        public IHttpActionResult PostListStudent(ListStudent listStudent)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListStudents.Add(listStudent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ListStudentExists(listStudent.IDStudent))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = listStudent.IDStudent }, listStudent);
        }

        // DELETE: api/ListStudents/5
        [Authorize]
        [ResponseType(typeof(ListStudent))]
        public IHttpActionResult DeleteListStudent(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ListStudent listStudent = db.ListStudents.Find(id);
            if (listStudent == null)
            {
                return NotFound();
            }

            db.ListStudents.Remove(listStudent);
            db.SaveChanges();

            return Ok(listStudent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListStudentExists(int id)
        {
            return db.ListStudents.Count(e => e.IDStudent == id) > 0;
        }
    }
}