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
    public class SubGroupsController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/SubGroups
        public IQueryable<SubGroup> GetSubGroups()
        {
            return db.SubGroups;
        }

        // GET: api/SubGroups/5
        [ResponseType(typeof(SubGroup))]
        public IHttpActionResult GetSubGroup(int id)
        {
            SubGroup subGroup = db.SubGroups.Find(id);
            if (subGroup == null)
            {
                return NotFound();
            }

            return Ok(subGroup);
        }

        
        private bool SubGroupExists(int id)
        {
            return db.SubGroups.Count(e => e.IDSubGroup == id) > 0;
        }
    }
}