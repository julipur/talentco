using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TalentConnect.UI.Domain.Queries;
using TalentConnect.UI.Infrastructure.Security;
using TalentConnect.UI.ViewModels;

namespace TalentConnect.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Logon(LogOnViewModel vm)
        {
            string hashedPassword, salt;
            var hasher = new SaltedHash();
            hasher.GetHashAndSaltString(vm.Password, out hashedPassword, out salt);

            var query = new Login();
            var authenticated = await query.ExecuteQuery(vm.Email, hashedPassword).ConfigureAwait(false);

            return View(vm);
        }
    }
}