using NiceWEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
            if (Session["UserID"] == null || Session["UserID"].ToString().Length < 1)
            {
                return RedirectToAction("Login", "Home");
            }

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
            int totalCount = dac.GetTotalCount(startDate, endDate, workID, prdCode);
            List<Efficiency> list = dac.GetData(startDate, endDate, workID,prdCode,page,pagesize);
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

            StringBuilder labels = new StringBuilder();
            StringBuilder orderQty = new StringBuilder();
            StringBuilder productQty = new StringBuilder();
            StringBuilder defectQty = new StringBuilder();
            StringBuilder workRate = new StringBuilder();
            StringBuilder downRate = new StringBuilder();

            foreach (DataRow dr in dt.Rows)
            {
                labels.Append(dr["DATE"]+",");
                orderQty.Append(dr["ORDER_QTY"] + ",");
                productQty.Append(dr["PRODUCT_QTY"] + ",");
                defectQty.Append(dr["DEFECT_QTY"] + ",");
                workRate.Append(dr["WORK_RATE"] + ",");
                downRate.Append(dr["DOWN_RATE"] + ",");

            }

            ViewBag.Labels =  labels.ToString().TrimEnd(',');
            ViewBag.OrderQty = "[" + orderQty.ToString().TrimEnd(',') + "]";
            ViewBag.ProductQty = "[" + productQty.ToString().TrimEnd(',') + "]";
            ViewBag.DefectQty = "[" + defectQty.ToString().TrimEnd(',') + "]";
            ViewBag.WorkRate = "[" + workRate.ToString().TrimEnd(',') + "]";
            ViewBag.DownRate = "[" + downRate.ToString().TrimEnd(',') + "]";
          


            if (startDate == null) ViewBag.startDate = DateTime.Now.ToString();
            else { ViewBag.startDate = startDate; }

            if (endDate == null) ViewBag.endDate = DateTime.Now.ToString();
            else { ViewBag.endDate = endDate; }



            return View(list);
        }
    }
}