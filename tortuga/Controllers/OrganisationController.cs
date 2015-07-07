using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mindscape.LightSpeed;
using tortuga.Data;
using System.Net;

namespace tortuga.Controllers
{
    public class OrganisationController : Controller
    {
        private static LightSpeedContext<TortugaModelUnitOfWork> _context;
        //
        // GET: /Organisation/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name, string description)
        {
            _context = new LightSpeedContext<TortugaModelUnitOfWork>("default");
            using (var data = _context.CreateUnitOfWork())
            {
                var profile = data.UserProfiles.Single(n => n.UserName == User.Identity.Name);

                if (!profile.Organisations.Any(n => n.Name == name))
                {
                    Organisation newOrg = new Organisation {Name = name, Description = description};
                    profile.Organisations.Add(newOrg);
                    data.SaveChanges();
                    return Json(new { success = true, responseText = "Organisation created successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(new { success = false, responseText = "Organisation already exists." }, JsonRequestBehavior.AllowGet);
                }
                
                return Json(new { success = false, responseText = "Organisation already exists." }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
