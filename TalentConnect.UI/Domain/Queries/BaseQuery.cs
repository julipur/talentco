using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TalentConnect.UI.Domain.Queries
{
    public abstract class BaseQuery
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TalentConnect"].ToString();
            }
        }
    }
}