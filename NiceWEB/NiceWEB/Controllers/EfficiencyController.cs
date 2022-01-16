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
    public class EfficiencyController : Controller
    {
        // GET: Efficiency
        public ActionResult Index(string startDate, string endDate, string workID, string prdCode, int page = 1)
        {
            CommonDAC comDAC = new CommonDAC();
            //select box에 전달할 데이터
            List<ComboItem> orderList = comDAC.GetWorkOrder();
            List<ComboItem> prodList = comDAC.GetProductCode();
            comDAC.Dispose();

            orderList.Insert(0, new ComboItem { Code = "" });
            prodList.Insert(0, new ComboItem { Code = "" });
            ViewBag.Order = new SelectList(orderList, "Code", "Code");
            ViewBag.Product = new SelectList(prodList, "Code", "Code");

            int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
            EfficiencyDAC dac = new EfficiencyDAC();
            int totalCount = dac.GetTotalCount(workID, prdCode);
            List<Efficiency> list = dac.GetData(startDate, endDate, workID,prdCode);
            DataTable dt = dac.GetChartData(startDate, endDate, workID, prdCode);
            //차트
            dac.Dispose();


            PagingInfo pageInfo = new PagingInfo
            {
                TotalItems = totalCount,
                ItemsPerPage = pagesize,
                CurrentPage = page
            };
            ViewBag.PagingInfo = pageInfo;


            
            //ViewBag.OrderQty = 
            //ViewBag.ProductQty = 
            //ViewBag.DefectQty = 
            //ViewBag.WorkRate = 
            //ViewBag.DownRate = 
            //ViewBag.Labels = startDate to endDate






            return View(list);
        }
    }
}