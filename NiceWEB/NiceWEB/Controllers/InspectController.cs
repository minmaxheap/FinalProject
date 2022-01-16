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
            int totalCount = dac.GetTotalCount(prdCode, operCode,lotID);
            List<Inspect> list = dac.GetPageList(startDate, endDate, prdCode, operCode, lotID, page, page);
            dac.Dispose();

            PagingInfo pageInfo = new PagingInfo
            {
                TotalItems = totalCount, 
                ItemsPerPage = pagesize,
                CurrentPage = page
            };

            ViewBag.PagingInfo = pageInfo;


            if (startDate == null) ViewBag.startDate = DateTime.Now.AddDays(-6).ToString();
            else { ViewBag.startDate = startDate; }

            if (endDate == null) ViewBag.endDate = DateTime.Now.ToString();
            else { ViewBag.endDate = endDate; }


            return View(list);
        }
    }
}