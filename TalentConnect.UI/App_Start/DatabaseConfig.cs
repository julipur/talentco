using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalentConnect.UI.Infrastructure.Context;

namespace TalentConnect.UI
{
    public class DatabaseConfig
    {
        public static void ConfigureDatabase()
        {
            DBInitializer.Initialize();
        }
    }
}