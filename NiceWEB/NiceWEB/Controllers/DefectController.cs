using NiceWEB.Models;
using NiceWEB.Models.DAC;
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Mvc;
namespace NiceWEB.Controllers
{
	public class DefectController : Controller
    {
        // GET: Deffect
        public ActionResult Index(string startDate, string endDate, string productCode, string op_code, int page=1)
        {

            if (Session["UserID"] == null || Session["UserID"].ToString().Length < 1)
            {
                return RedirectToAction("Login", "Home");
            }

            //DateTime from = Convert.ToDateTime("2021-10-10");
            //DateTime to = Convert.ToDateTime("2022-10-10");

            int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
            DefectDAC dac = new DefectDAC();
            List<DefectProperty> list = dac.GetData(startDate, endDate, productCode,op_code,page,pagesize);
            int totalCount = dac.GetProductTotalCount(startDate, endDate, productCode, op_code);
            List<ComboItem> categories = dac.GetProduct();
            List<ComboItem> categories2 = dac.GetOperation();

            PagingInfo pageInfo = new PagingInfo
            {
                TotalItems = totalCount,
                ItemsPerPage = pagesize,
                CurrentPage = page
            };

            categories.Insert(0, new ComboItem { Code = "" });

            categories2.Insert(0, new ComboItem { Code = "" });

            ViewBag.Categories = new SelectList(categories, "Code", "Code");
            ViewBag.Categories2 = new SelectList(categories2, "Code", "Code");

            ViewBag.productCode = productCode;
            ViewBag.op_code = op_code;

            if (startDate == null) ViewBag.startDate = DateTime.Now.ToString();
            else { ViewBag.startDate = startDate; }

            if (endDate == null) ViewBag.endDate = DateTime.Now.ToString();
            else { ViewBag.endDate = endDate; }

            ViewBag.PagingInfo = pageInfo;
            return View(list);
        }
    }
}