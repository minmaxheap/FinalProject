using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NiceWEB.Models.DAC;
using NiceWEB.Models;
using System.Web.Configuration;
using NiceWEB.Models;

namespace NiceWEB.Controllers
{
    public class LOTHController : Controller
    {
        // GET: LOTH
        public ActionResult Index(string LotID, int page = 1)
        {

            if (Session["UserID"] == null || Session["UserID"].ToString().Length < 1)
            {
                return RedirectToAction("Login", "Home");
            }

            if (string.IsNullOrWhiteSpace(LotID))
            {
                LOT_HISDAC dac = new LOT_HISDAC();
                List<LOT_HIS> list = null;
                
                List<ComboItem> categories = dac.GetCode();
                PagingInfo pageInfo = new PagingInfo
                {
                    TotalItems = 0,
                    ItemsPerPage = 10,
                    CurrentPage = page
                };

                categories.Insert(0, new ComboItem { Code = "" });
                ViewBag.Categories = new SelectList(categories, "Code", "Code");
                ViewBag.LotID = LotID;

                ViewBag.PagingInfo = pageInfo;
                ViewBag.menu1 = "";
                ViewBag.menu2 = "";
                ViewBag.menu3 = "";
                ViewBag.menu4 = "active";
                ViewBag.menu5 = "";
                ViewBag.menu6 = "";
                ViewBag.menu7 = "";
                ViewBag.menu8 = "";

                return View(list);
            }
            else
            {

                int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);

                LOT_HISDAC dac = new LOT_HISDAC();
                List<LOT_HIS> List = dac.GetData(LotID, page, pagesize);
                List<ComboItem> categories = dac.GetCode();
                int totalCount = dac.GetProductTotalCount(LotID);
                dac.Dispose();

                PagingInfo pageInfo = new PagingInfo
                {
                    TotalItems = totalCount,
                    ItemsPerPage = pagesize,
                    CurrentPage = page
                };

                categories.Insert(0, new ComboItem { Code = "" });
                ViewBag.Categories = new SelectList(categories, "Code", "Code");

                ViewBag.LotID = LotID;
                ViewBag.PagingInfo = pageInfo;


                ViewBag.menu1 = "";
                ViewBag.menu2 = "";
                ViewBag.menu3 = "";
                ViewBag.menu4 = "active";
                ViewBag.menu5 = "";
                ViewBag.menu6 = "";
                ViewBag.menu7 = "";
                ViewBag.menu8 = "";

                return View(List);
            }
        }
    }
}