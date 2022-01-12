using NiceWEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiceWEB.Controllers
{
    public class EfficiencyController : Controller
    {
        // GET: Efficiency
        public ActionResult Index()
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            TableData t = new TableData();
            List<ColumnsInfo> _col = new List<ColumnsInfo>();

            EfficiencyDAC dac = new EfficiencyDAC();
            DataTable dt = dac.GetData("2020-01-01", "2010-02-02","","");
           // dac.Dispose();


            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                _col.Add(new ColumnsInfo {data = dt.Columns[i].ColumnName });
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

            CommonDAC comDAC = new CommonDAC();
            //select box에 전달할 데이터
            //List<TableData> order = comDAC.GetWorkOrder();
            //List<TableData> product = comDAC.GetProductCode();
            //문제는 이걸 어떻게 전달하냐 => 전달해서 어떻게 바인딩시키냐

           // ViewBag.order = new SelectList(order, "Data", "Data");
           // ViewBag.product = new SelectList(product, "Data", "Data");


            return View(t);
        }
    }
}