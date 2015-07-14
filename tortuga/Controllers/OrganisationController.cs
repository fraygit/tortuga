using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Mindscape.LightSpeed;
using tortuga.Data;
using System.Net;
using tortuga.MongoData.Entities.Repository;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace tortuga.Controllers
{
    public class OrganisationController : Controller
    {
        //private static LightSpeedContext<TortugaModelUnitOfWork> _context;
        //
        // GET: /Organisation/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(string name, string description)
        {
            try
            {
                var orgRepo = new OrganisationRepository();

                var currentUser = new List<string>();
                currentUser.Add(User.Identity.Name);

                var userCurrentOrganisationByOrgName = await orgRepo.GetOrganisation(name, User.Identity.Name);

                var result = userCurrentOrganisationByOrgName;

                if (result == null)
                {
                    orgRepo.Create(new MongoData.Entities.Model.Organisation
                    {
                        Name = name,
                        Description = description,
                        Users = currentUser
                    });
                    return Json(new { success = true, responseText = "Added." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(new { success = false, responseText = "Organisation already exists for this user." }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
