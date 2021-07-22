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
    public class SpecialitiesController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/Specialities
        public IQueryable<Speciality> GetSpecialities()
        {
            return db.Specialities;
        }

        // GET: api/Specialities/5
        [ResponseType(typeof(Speciality))]
        public IHttpActionResult GetSpeciality(string id)
        {
            Speciality speciality = db.Specialities.Find(id);
            if (speciality == null)
            {
                return NotFound();
            }

            return Ok(speciality);
        }

        
        private bool SpecialityExists(string id)
        {
            return db.Specialities.Count(e => e.NameSpeciality == id) > 0;
        }
    }
}