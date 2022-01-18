using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NiceWEB.Models.DAC;
using System.Data;
using NiceWEB.Models;
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
            DataTable dt;
            LoginDAC dac = new LoginDAC();
            bool result = dac.CheckLogin(email, password);
            List<ComboItem> list = dac.getName(email);
            dac.Dispose();
			if(result)
			{
                
				Session["UserID"] = list[0].Code.ToString() + "님";
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
