 using NiceWEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace NiceWEB.Controllers
{
    public class InspectController : Controller
    {
        // GET: Inspect
        public ActionResult Index(string startDate, string endDate, string prdCode, string operCode, string lotID, int page = 1)
        {

            if (Session["UserID"] == null || Session["UserID"].ToString().Length < 1)
            {
                Session["ReturlUrl"] = "/Inspect/Index";

                return RedirectToAction("Login", "Home");
            }


            if (startDate == null)
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy-MM-dd");
            }

            ViewBag.startDate = startDate;

            if (endDate == null)
            {
                endDate = new DateTime(DateTime.Now.Year, 1, 31).ToString("yyyy-MM-dd");
            }

            ViewBag.endDate = endDate;

            //select box에 전달할 데이터
            CommonDAC comDAC = new CommonDAC();

            List<ComboItem> operList = comDAC.GetOperation();
            List<ComboItem> prodList = comDAC.GetProductCode();
            comDAC.Dispose();


            operList.Insert(0, new ComboItem { Code = "" });
            prodList.Insert(0, new ComboItem { Code = "" });
            ViewBag.operList = new SelectList(operList, "Code", "Code");
            ViewBag.prodList = new SelectList(prodList, "Code", "Code");
            ViewBag.LotID = lotID;


            int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
            InspectDAC dac = new InspectDAC();
            int totalCount = dac.GetTotalCount(startDate, endDate, prdCode, operCode,lotID);
            List<Inspect> list = dac.GetPageList(startDate, endDate, prdCode, operCode, lotID, page, pagesize);
            dac.Dispose();

            PagingInfo pageInfo = new PagingInfo
            {
                TotalItems = totalCount, 
                ItemsPerPage = pagesize,
                CurrentPage = page
            };

            ViewBag.PagingInfo = pageInfo;



            ViewBag.menu1 = "";
            ViewBag.menu2 = "";
            ViewBag.menu3 = "active";
            ViewBag.menu4 = "";
            ViewBag.menu5 = "";
            ViewBag.menu6 = "";
            ViewBag.menu7 = "";
            ViewBag.menu8 = "";


            return View(list);
        }
    }
}