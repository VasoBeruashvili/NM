using NM.Utils;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace NM.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.message = "";
            return NMContext.IsLicenseValid() ? View("Index") : null;
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if (NMContext.IsLicenseValid())
            {
                string returnUrl = "/Home/AddProducts";

                MyMembershipProvider myMembershipProvider = new MyMembershipProvider();
                if (myMembershipProvider.ValidateUser(userName, password))
                {
                    FormsAuthentication.SetAuthCookie(userName, false);

                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else return RedirectToAction("Index", "Account");
                }
                else
                {
                    ViewBag.ValidateUserMessage = "სახელი ან პაროლი არასწორია!";
                    return View("Index");
                }
            }
            else
            {
                return null;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return NMContext.IsLicenseValid() ? RedirectToAction("Index", "Account") : null;
        }
    }
}