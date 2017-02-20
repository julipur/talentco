using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TalentConnect.UI.Controllers
{
    public class JobsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("manage-jobs"), HttpGet]
        public ActionResult ManageJobs()
        {
            return View();
        }
    }
}