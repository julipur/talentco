﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentConnect.UI.Areas.Admin.ViewModels
{
    public class JobsViewModel
    {
        public IEnumerable<JobViewModel> Jobs { get; set; }
    }
}