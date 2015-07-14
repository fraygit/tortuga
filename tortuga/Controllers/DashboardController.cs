using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mindscape.LightSpeed;
using tortuga.Data;
using tortuga.Models;
using System.Threading.Tasks;
using tortuga.MongoData.Entities.Repository;

namespace tortuga.Controllers
{
    public class DashboardController : Controller
    {
        private static LightSpeedContext<TortugaModelUnitOfWork> _context;

        //
        // GET: /Dashboard/
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var orgRepo = new OrganisationRepository();

            var currentUser = new List<string>();
            currentUser.Add(User.Identity.Name);

            var model = await orgRepo.GetOrganisations(User.Identity.Name);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult LeftPane()
        {
            _context = new LightSpeedContext<TortugaModelUnitOfWork>("default");
            Data.UserProfile profile;
            using (var data = _context.CreateUnitOfWork())
            {
                profile = data.UserProfiles.Single(n => n.UserName == User.Identity.Name);
                
            }
            return PartialView("~/Views/Partial/Dashboard/LeftPane.cshtml", profile);
        }

        [ChildActionOnly]
        public ActionResult Breadcrumb()
        {
            var currentPage = HttpContext.Request.Url.AbsolutePath;

            return PartialView("~/Views/Partial/Dashboard/Breadcrumb.cshtml", currentPage.Split('/'));
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
