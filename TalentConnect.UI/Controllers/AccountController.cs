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
        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}

        // GET: Account
        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Logon(LogOnViewModel vm)
        {
            var result = await new GetCredentialsByEmail().ExecuteQuery(vm.Email);
            var authenticated = result != null && new SaltedHash().VerifyHashString(vm.Password, result.HashedPassword, result.PasswordSalt);

            if (authenticated)
            {
                //AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, IdentityFactory.GetIdentity(vm.Email, result.Role));
            }

            return View(vm);
        }
    }
}