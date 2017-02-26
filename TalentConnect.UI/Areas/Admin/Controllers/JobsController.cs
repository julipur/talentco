using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentConnect.UI.Domain.Commands;
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
            return View(AddJobViewModel.CreateEmpty());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Add(AddJobViewModel vm)
        {
            var commandHandler = new AddJobCommandHandler().HandleAsync(
                new AddJobCommand()
                {
                    Title = vm.Title,
                    Description = vm.Description,
                    City = vm.City,
                    Province = vm.SelectedProvince,
                    JobType = vm.SelectedJobType,
                    ClosingDate = vm.ClosingDate,
                    YearOfExperince = vm.YearOfExperince,
                    Hours = vm.Hours,
                    Rate = vm.Rate
                });

            vm.InitializeLists();
            return View(vm);
        }
    }
}