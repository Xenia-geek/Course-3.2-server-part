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
    public class StudentPassesController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/StudentPasses
        public IQueryable<StudentPass> GetStudentPasses()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.StudentPasses;
        }

        // GET: api/StudentPasses/5
        [ResponseType(typeof(StudentPass))]
        public IHttpActionResult GetStudentPass(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            StudentPass studentPass = db.StudentPasses.Find(id);
            if (studentPass == null)
            {
                return NotFound();
            }

            return Ok(studentPass);
        }

        // PUT: api/StudentPasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentPass(int id, StudentPass studentPass)
        {
            db.Configuration.ProxyCreationEnabled = false;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentPass.IDStudentPass)
            {
                return BadRequest();
            }

            db.Entry(studentPass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentPassExists(id))
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

        // POST: api/StudentPasses
        [ResponseType(typeof(StudentPass))]
        public IHttpActionResult PostStudentPass(StudentPass studentPass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentPasses.Add(studentPass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentPass.IDStudentPass }, studentPass);
        }

        // DELETE: api/StudentPasses/5
        [ResponseType(typeof(StudentPass))]
        public IHttpActionResult DeleteStudentPass(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            StudentPass studentPass = db.StudentPasses.Find(id);
            if (studentPass == null)
            {
                return NotFound();
            }

            db.StudentPasses.Remove(studentPass);
            db.SaveChanges();

            return Ok(studentPass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentPassExists(int id)
        {
            return db.StudentPasses.Count(e => e.IDStudentPass == id) > 0;
        }
    }
}