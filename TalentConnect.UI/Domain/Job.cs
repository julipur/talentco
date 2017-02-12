using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentConnect.UI.Domain
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}