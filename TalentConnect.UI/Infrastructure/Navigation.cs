using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentConnect.UI.Infrastructure
{
    public class Navigation
    {
        public class About
        {
            public string Controller = "about";
            public string Index = "index";
        }

        public class Candidates
        {
            public string Controller = "candidates";
            public string Index = "index";
        }

        public class Contact
        {
            public string Controller = "contact";
            public string Index = "index";
        }

        public class Employers
        {
            public string Controller = "employers";
            public string Index = "index";
        }

        public class Home
        {
            public string Controller = "home";
            public string Index = "index";
        }

        public class Jobs
        {
            public string Controller = "jobs";
            public string Index = "index";
            public string ManageJobs = "manage";
        }

        public class Privacy
        {
            public string Controller = "privacy";
            public string Index = "index";
        }

        public class Terms
        {
            public string Controller = "terms";
            public string Index = "index";
        }
    }
}