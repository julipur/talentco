using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentConnect.UI.Infrastructure;

namespace TalentConnect.UI.Models.Request
{
    public class AddJobRequest
    {
        [Display(Name = "Title"), Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public string City { get; set; }

        public string SelectedProvince { get; set; }

        public IEnumerable<Province> Provinces { get; set; }

        [Display(Name = "Job Type"), Required(ErrorMessage = "Job type is required.")]
        public string JobType { get; set; }

        public int YearOfExperince { get; set; }

        [Required(ErrorMessage = "Expiry date is required.")]
        public DateTime ExpiryDate { get; set; }

        internal static AddJobRequest CreateEmpty()
        {
            return new AddJobRequest()
            {
                Provinces = Province.GetProvinces()
            };
        }
    }
}