using SWE.RFID.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWE.RFID.Controllers
{
    public class AccountController : Controller
    {
        private IAccountManager _accountManager;
        public AccountController(IAccountManager  accountManager)
        {
            _accountManager = accountManager;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("login");
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
         var user =   _accountManager.Login(username, password);
            if (!string.IsNullOrEmpty(user.Token))
            {
                Session["userName"] = user.UserName;
                Session["accessToken"] = user.Token;
                Session["Role"] = user.RolesId.Contains(2) ? "admin" : "employee";
                return RedirectToAction("Index","Home");

            }
            else
            {
                ViewBag.Error = "User Not Exists";
                return View();

            }

        }
        public void Change(string id,string currenturl)
        {
            if (System.Web.HttpContext.Current.Response.Cookies["lang"] != null)
            {
                System.Web.HttpContext.Current.Response.Cookies["lang"].Value = id;
            }
            else
            {

            var cuka = new HttpCookie("lang", id + "");
            cuka.Expires = DateTime.Now.AddYears(10);
            System.Web.HttpContext.Current.Response.Cookies.Add(cuka);

            }
            Response.Redirect(currenturl);
        }
    }
}