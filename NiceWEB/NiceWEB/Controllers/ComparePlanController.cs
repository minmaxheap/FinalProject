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
    public class ComparePlanController : Controller
    {

        // GET: ComparePlan
        public ActionResult Index(string workID, string prdCode, int page = 1)
        {
            //select box에 전달할 데이터
            CommonDAC comDAC = new CommonDAC();
           
              List<ComboItem> orderList = comDAC.GetWorkOrder();
              List<ComboItem> prodList = comDAC.GetProductCode();


            orderList.Insert(0, new ComboItem { Code = ""});
            prodList.Insert(0, new ComboItem { Code = "" });
            ViewBag.orderList = new SelectList(orderList, "Code", "Code");
            ViewBag.prodList = new SelectList(prodList, "Code", "Code");


            //datatable을 JSON으로 바꾸는 코드 => list로 바꾸기

            ComparePlanDAC dac = new ComparePlanDAC();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    


            int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
            DataTable dt = dac.GetData("2020-01-01","2010-02-02", "D","");

            //workID = "1";
            //prdCode = "1";
            List<ComparePlan> list = dac.GetPageList( workID, prdCode, page, pagesize);

            TableData t = new TableData();
            List<ColumnsInfo> _col = new List<ColumnsInfo>();
            // GAUGE CHART 데이터 받고 보내기
            List <ComparePlan> gauge = dac.GetChartData("3", "3",workID,prdCode);
            ViewBag.chart = gauge;
            ViewBag.work = gauge[0].WORK_ORDER_ID;
            ViewBag.ordQty = gauge[0].ORDER_QTY;
            ViewBag.prdQty = gauge[0].PRODUCT_QTY;
            ViewBag.defQty = gauge[0].DEFECT_QTY;

             //산술 오버플로우가 일어나서 DECIMAL 반올림함
            ViewBag.qualityRate = Math.Round( (gauge[0].PRODUCT_QTY / (gauge[0].PRODUCT_QTY + gauge[0].DEFECT_QTY)) * Convert.ToDecimal(100),2);
            ViewBag.defectRate = Math.Round((gauge[0].DEFECT_QTY / (gauge[0].PRODUCT_QTY + gauge[0].DEFECT_QTY))* Convert.ToDecimal(100),2);


            //  dac.Dispose();
            return View(list);
        }



    }
}