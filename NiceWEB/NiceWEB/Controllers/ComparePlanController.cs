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
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            TestData t = new TestData();
            List<ColumnsInfo> _col = new List<ColumnsInfo>();

            ComparePlanDAC dac = new ComparePlanDAC();
           DataTable dt = dac.GetData("2020-01-01","2010-02-02");
            // string data =  DataTableToJson(dt);

            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID", typeof(Int32));
            //dt.Columns.Add("Name", typeof(string));

            //DataRow dr = dt.NewRow();
            //dr[0] = 1;
            //dr[1] = "Ajay";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = 2;
            //dr[1] = "Sanu";

            
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

            //select box에 전달할 데이터
            DataTable dtOrder = dac.GetWorkOrder();
            DataTable dtProduct =  dac.GetProductCode();
            //문제는 이걸 어떻게 전달하냐 => 전달해서 어떻게 바인딩시키냐



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