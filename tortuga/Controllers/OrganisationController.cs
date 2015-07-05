using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mindscape.LightSpeed;
using tortuga.Data;

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
                //User.Identity
                var profile = data.UserProfiles.Single(n => n.UserName == User.Identity.Name);

                //var org = data.Organisations.Where(n => n.UserProfiles.Any(y => y.UserName == User.Identity.Name));
                if (!profile.Organisations.Any(n => n.Name == name))
                {
                    //var profile = data.FindById()
                    Organisation newOrg = new Organisation {Name = name, Description = description};
                    profile.Organisations.Add(newOrg);
                    data.SaveChanges();
                    return Json(new { Error = string.Empty }, JsonRequestBehavior.AllowGet);
                }
                return Json(new {Error = "Organisation already exists."}, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
