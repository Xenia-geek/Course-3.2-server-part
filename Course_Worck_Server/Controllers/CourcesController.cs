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
    public class CourcesController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/Cources
        public IQueryable<Cource> GetCources()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Cources;
        }

        // GET: api/Cources/5
        [ResponseType(typeof(Cource))]
        public IHttpActionResult GetCource(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Cource cource = db.Cources.Find(id);
            if (cource == null)
            {
                return NotFound();
            }

            return Ok(cource);
        }

        
        private bool CourceExists(int id)
        {
            return db.Cources.Count(e => e.IDCource == id) > 0;
        }
    }
}