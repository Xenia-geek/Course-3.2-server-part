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
    public class GroupsController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/Groups
        public IQueryable<Group> GetGroups()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Groups;
        }

        // GET: api/Groups/5
        [ResponseType(typeof(Group))]
        public IHttpActionResult GetGroup(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        
        private bool GroupExists(int id)
        {
            return db.Groups.Count(e => e.IDGroup == id) > 0;
        }
    }
}