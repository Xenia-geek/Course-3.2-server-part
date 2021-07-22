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
    [Authorize]
    public class AdminsController : ApiController
    {
        private LabTrackerDB db = new LabTrackerDB();

        // GET: api/Admins
        public IQueryable<Admin> GetAdmins()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Admins;
        }

        // GET: api/Admins/5
        [ResponseType(typeof(Admin))]
        public IHttpActionResult GetAdmin(string id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }      

        private bool AdminExists(string id)
        {
            return db.Admins.Count(e => e.Login == id) > 0;
        }
    }
}