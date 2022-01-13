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
        public ActionResult Index(string order, string product)
        {
            CommonDAC comDAC = new CommonDAC();
            //select box에 전달할 데이터
            List<ComboItem> orderList = comDAC.GetWorkOrder();
            List<ComboItem> prodList = comDAC.GetProductCode();
            ViewBag.Order = new SelectList(orderList, "Code", "Code");
            ViewBag.Product = new SelectList(prodList, "Code", "Code");

            //datatable을 JSON으로 바꾸는 코드 => list로 바꾸기


            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            EfficiencyDAC dac = new EfficiencyDAC();
            DataTable dt = dac.GetData("2020-01-01", "2010-02-02", "", "");
            TableData t = new TableData();
            List<ColumnsInfo> _col = new List<ColumnsInfo>();

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

            dac.Dispose();

            //차트

            return View();
        }
    }
}