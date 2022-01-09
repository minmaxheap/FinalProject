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
            DataTable dt = dac.GetData("2020-01-01", "2010-02-02");

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


            return View(t);
        }
    }
}