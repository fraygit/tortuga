using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mindscape.LightSpeed;
using tortuga.Data;

namespace tortuga.Controllers
{
    public class DashboardController : Controller
    {
        private static LightSpeedContext<TortugaModelUnitOfWork> _context;

        //
        // GET: /Dashboard/
        [Authorize]
        public ActionResult Index()
        {
            _context = new LightSpeedContext<TortugaModelUnitOfWork>("default");
            using (var data = _context.CreateUnitOfWork())
            {
                //User.Identity
                var profile = data.UserProfiles.Single(n => n.UserName == User.Identity.Name);
                
                //var org = data.Organisations.Where(n => n.UserProfiles.Any(y => y.UserName == User.Identity.Name));
                if (!profile.Organisations.Any())
                {
                    //var profile = data.FindById()
                    Organisation newOrg = new Organisation {Name = "test org"};
                    profile.Organisations.Add(newOrg);
                    data.SaveChanges();
                }
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult LeftPane()
        {
            _context = new LightSpeedContext<TortugaModelUnitOfWork>("default");
            UserProfile profile;
            using (var data = _context.CreateUnitOfWork())
            {
                profile = data.UserProfiles.Single(n => n.UserName == User.Identity.Name);
                
            }
            return PartialView("~/Views/Partial/Dashboard/LeftPane.cshtml", profile);
        }

        [ChildActionOnly]
        public ActionResult OrganisationSelect()
        {
            _context = new LightSpeedContext<TortugaModelUnitOfWork>("default");
            List<Organisation> organisation;
            using (var data = _context.CreateUnitOfWork())
            {
                var userProfile = data.UserProfiles.Single(n => n.UserName == User.Identity.Name);
                organisation = userProfile.Organisations.ToList();
            }
            return PartialView("~/Views/Partial/Dashboard/OrganisationSelection.cshtml", organisation);
        }

    }
}
