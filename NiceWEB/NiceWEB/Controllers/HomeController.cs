using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiceWEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["UserID"] == null || Session["UserID"].ToString().Length < 1)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email.Equals("admin@gd.com") && password.Equals("1234"))
            {
                Session["UserID"] = "admin";
                if (ViewBag.ReturlUrl != null)
                    return Redirect(ViewBag.ReturlUrl.ToString());
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            return RedirectToAction("Index");
        }
    }
}
