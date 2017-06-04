using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using TalentConnect.UI.Infrastructure.Bootstrap;

namespace TalentConnect.UI
{
    public class DatabaseConfig
    {
        public async Task ConfigureDatabase()
        {
            await new DBInitializer().Initialize();
        }
    }
}