using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentConnect.UI.Models.Request;

namespace TalentConnect.UI.Areas.Admin.Controllers
{
    public class JobsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(AddJobRequest.CreateEmpty());
        }

        [HttpPost]
        public ActionResult Add(AddJobRequest request)
        {
            return View(request);
        }
    }
}