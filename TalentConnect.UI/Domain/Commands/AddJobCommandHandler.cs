using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TalentConnect.UI.Infrastructure.Context;

namespace TalentConnect.UI.Domain.Commands
{
    public class AddJobCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string JobType { get; set; }
        public string ClosingDate { get; set; }
        public int? YearOfExperince { get; set; }
        public int? Hours { get; set; }
        public string Rate { get; set; }
    }
    public class AddJobCommandHandler
    {
        public async Task HandleAsync(AddJobCommand command)
        {
            using (var context = new TalentConnectContext())
            {
                Job job = new Job()
                {
                    Title = command.Title,
                    Description = command.Description,
                    City = command.City,
                    Province = command.Province,
                    JobType = (JobTypes)Enum.Parse(typeof(JobTypes), command.JobType, true),
                    //ClosingDate = new DateTime(command.ClosingDate),
                    YearsOfExperience = command.YearOfExperince,
                    Hours = command.Hours,
                    Rate = command.Rate
                };

                context.Jobs.Add(job);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }

        } 
    }
}