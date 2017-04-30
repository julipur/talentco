using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentConnect.UI.Domain.Queries;
using TalentConnect.UI.ViewModels;

namespace TalentConnect.UI.Controllers
{
    public class VacanciesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var dto = new GetActiveVacancies().ExecuteQuery();

            var vm = new VacanciesViewModel()
            {
                Vacancies = dto.Select(v => new VacancyViewModel()
                {
                    Id = v.Id,
                    Title = v.Title,
                    ShortDescription = v.ShortDescription,
                    Description = v.Description,
                    City = v.City,
                    Province = v.Province,
                    JobType = v.JobType.ToString(),
                    YearsOfExperince = v.YearsOfExperience,
                    ClosingDate = v.ClosingDate.HasValue ? v.ClosingDate.Value.ToString("MMM dd, yyyy") : string.Empty,
                    Hours = v.Hours,
                    Rate = v.Rate
                })
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

       
    }
}