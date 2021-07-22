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
    public class SemestrsController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/Semestrs
        public IQueryable<Semestr> GetSemestrs()
        {

            db.Configuration.ProxyCreationEnabled = false;

            return db.Semestrs;
        }

        // GET: api/Semestrs/5
        [ResponseType(typeof(Semestr))]
        public IHttpActionResult GetSemestr(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Semestr semestr = db.Semestrs.Find(id);
            if (semestr == null)
            {
                return NotFound();
            }

            return Ok(semestr);
        }

        
        private bool SemestrExists(int id)
        {
            return db.Semestrs.Count(e => e.IDSem == id) > 0;
        }
    }
}