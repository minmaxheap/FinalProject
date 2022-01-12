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
        public ActionResult Index(string order, string product)
        {


            int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
              CommonDAC comDAC = new CommonDAC();
              //select box에 전달할 데이터
              List<ComboItem> orderList = comDAC.GetWorkOrder();
              List<ComboItem> prodList = comDAC.GetProductCode();

            ComparePlanDAC dac = new ComparePlanDAC();
            int totalCount = dac.GetProductTotalCount("", "");

            PagingInfo pageInfo = new PagingInfo
            {
                TotalItems = totalCount,
                ItemsPerPage = pagesize,
                CurrentPage = 1
            };

            ViewBag.storeCode = "";
            ViewBag.productCode = "";
            ViewBag.PagingInfo = pageInfo;


            //  CommonDAC comDAC = new CommonDAC();
            //  //select box에 전달할 데이터
            //  List<ComboItem> orderList = comDAC.GetWorkOrder();
            //  List<ComboItem> prodList = comDAC.GetProductCode();
            //  ViewBag.Order = new SelectList(orderList, "Code", "Code");
            //  ViewBag.Product = new SelectList(prodList, "Code", "Code");

            //datatable을 JSON으로 바꾸는 코드
           
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
         TableData t = new TableData();
         List<ColumnsInfo> _col = new List<ColumnsInfo>();


        DataTable dt = dac.GetData("2020-01-01","2010-02-02", "D","");
        //  dac.Dispose();


         for (int i = 0; i <= dt.Columns.Count - 1; i++)
         {
             _col.Add(new ColumnsInfo { data = dt.Columns[i].ColumnName });
         }

         string col = (string)serializer.Serialize(_col);
         t.Columns = col;


         var lst = dt.AsEnumerable()
         .Select(r => r.Table.Columns.Cast<DataColumn>()
                 .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                ).ToDictionary(z => z.Key, z => z.Value)
         ).ToList();

         string data = serializer.Serialize(lst);
         t.Data = data;


            //  // GAUGE CHART 데이터 받고 보내기
           List <ComparePlan> list = dac.GetChartData("3", "3","","");
            ViewBag.chart = list;
            ViewBag.work = list[0].WORK_ORDER_ID;
            ViewBag.ordQty = list[0].ORDER_QTY;
            ViewBag.prdQty = list[0].PRODUCT_QTY;
            ViewBag.defQty = list[0].DEFECT_QTY;

            //  //산술 오버플로우가 일어나서 DECIMAL 반올림함
            ViewBag.qualityRate = Math.Round( (list[0].PRODUCT_QTY / (list[0].PRODUCT_QTY + list[0].DEFECT_QTY)) * Convert.ToDecimal(100),2);
            ViewBag.defectRate = Math.Round((list[0].DEFECT_QTY / (list[0].PRODUCT_QTY + list[0].DEFECT_QTY))* Convert.ToDecimal(100),2);

            //  return View(t);

            //return View(data);

            return View(list);
        }



    }
}