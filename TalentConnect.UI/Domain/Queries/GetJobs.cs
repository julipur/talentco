using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalentConnect.UI.Infrastructure.Context;

namespace TalentConnect.UI.Domain.Queries
{
    public class GetJobsDto
    {
        public IEnumerable<GetJobDto> Jobs { get; set; }
    }
    public class GetJobs
    {
        public IEnumerable<GetJobDto> ExecuteQuery()
        {
            using (var context = new TalentConnectContext())
            {
                return context.Jobs.ToList().Select(j => new GetJobDto()
                {
                    Id = j.Id,
                    Title = j.Title,
                    Description = j.Description,
                    City = j.City,
                    Province = j.Province,
                    JobType = j.JobType.ToString(),
                    YearsOfExperience = j.YearsOfExperience,
                    ClosingDate = j.ClosingDate,
                    Hours = j.Hours,
                    Rate = j.Rate,
                    Filled = j.Filled,
                    Active = j.Active,
                    CreatedDate = j.CreatedDate
                });
            }
        }
    }
}