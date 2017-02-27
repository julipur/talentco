using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalentConnect.UI.Infrastructure.Context;

namespace TalentConnect.UI.Domain.Queries
{
    public class GetJobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string JobType { get; set; }
        public int? YearsOfExperience { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int? Hours { get; set; }
        public string Rate { get; set; }
        public bool Filled { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class GetJobById
    {
        public GetJobDto ExecuteQuery(int id)
        {
            using (var context = new TalentConnectContext())
            {
                var job =  context.Jobs.SingleOrDefault(u => u.Id == id);
                return new GetJobDto()
                {
                    Id = job.Id,
                    Title = job.Title,
                    Description = job.Description,
                    City = job.City,
                    Province = job.Province,
                    JobType = job.JobType.ToString(),
                    YearsOfExperience = job.YearsOfExperience,
                    ClosingDate = job.ClosingDate,
                    Hours = job.Hours,
                    Rate = job.Rate,
                    Filled = job.Filled,
                    Active = job.Active,
                    CreatedDate = job.CreatedDate
                };
            }
        }
    }
}