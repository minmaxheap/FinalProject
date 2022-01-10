using NiceWEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NiceWEB.Controllers
{
    public class ComparePlanController : Controller
    {

        // GET: ComparePlan
        public ActionResult Index()
        {
            CommonDAC comDAC = new CommonDAC();
            //select box에 전달할 데이터
            List<TableData> order = comDAC.GetWorkOrder();
            List<TableData> product = comDAC.GetProductCode();
            ViewBag.order = new SelectList(order, "Data", "Data");
            ViewBag.product = new SelectList(product, "Data", "Data");

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            TableData t = new TableData();
            List<ColumnsInfo> _col = new List<ColumnsInfo>();

            ComparePlanDAC dac = new ComparePlanDAC();
           DataTable dt = dac.GetData("2020-01-01","2010-02-02");
            
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



           List <ComparePlan> list = dac.GetChartData("3", "3");
            ViewBag.chart = list;
            ViewBag.work = list[0].WORK_ORDER_ID;
            ViewBag.ordQty = list[0].ORDER_QTY;
            ViewBag.prdQty = list[0].PRODUCT_QTY;
            ViewBag.defQty = list[0].DEFECT_QTY;

            ViewBag.qualityRate = (list[0].PRODUCT_QTY / (list[0].PRODUCT_QTY + list[0].DEFECT_QTY)) * Convert.ToDecimal(100);
            ViewBag.defectRate = (list[0].DEFECT_QTY / (list[0].PRODUCT_QTY + list[0].DEFECT_QTY))* Convert.ToDecimal(100);

            return View(t);

            //return View(data);
        }

        //#region DataTable -> Json String 
        //public static string DataTableToJson(DataTable ds)
        //{ 
        //    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); 
        //    serializer.MaxJsonLength = 2147483647; 
        //    List<Dictionary<string, object>> listRows = new List<Dictionary<string, object>>(); 
        //    Dictionary<string, object> row; 
        //    foreach (DataRow dr in ds.Rows) 
        //    {
        //        row = new Dictionary<string, object>(); 
        //        foreach (DataColumn col in ds.Columns) 
        //        { 
        //            row.Add(col.ColumnName, dr[col]); 
        //        } 
        //        listRows.Add(row); 
        //    } 
        //    return serializer.Serialize(listRows); 
        //}
        //#endregion

    }
}