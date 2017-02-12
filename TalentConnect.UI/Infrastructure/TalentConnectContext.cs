using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TalentConnect.UI.Domain;

namespace TalentConnect.UI.Infrastructure
{
    public class TalentConnectContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
    }
}