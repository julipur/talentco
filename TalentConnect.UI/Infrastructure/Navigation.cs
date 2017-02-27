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
            public const string Controller = "about";
            public const string Index = "index";
        }

        public class Candidates
        {
            public const string Controller = "candidates";
            public const string Index = "index";
        }

        public class Contact
        {
            public const string Controller = "contact";
            public const string Index = "index";
        }

        public class Employers
        {
            public const string Controller = "employers";
            public const string Index = "index";
        }

        public class Home
        {
            public const string Controller = "home";
            public const string Index = "index";
        }

        public class Jobs
        {
            public const string Area = "admin";
            public const string Controller = "jobs";
            public const string Index = "index";
            public const string Add = "add";
            public const string Edit = "edit";
        }

        public class Privacy
        {
            public const string Controller = "privacy";
            public const string Index = "index";
        }

        public class Terms
        {
            public const string Controller = "terms";
            public const string Index = "index";
        }
    }
}