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
        public ActionResult Index(string product, string operation, string lotID, int page = 1)
        {
            //select box에 전달할 데이터
            CommonDAC comDAC = new CommonDAC();

            List<ComboItem> prodList = comDAC.GetProductCode();
            List<ComboItem> operList = comDAC.GetOperation();

            ViewBag.Product = new SelectList(prodList, "Code", "Code");
            ViewBag.Operation = new SelectList(operList, "Code", "Code");
            int pagesize = Convert.ToInt32(WebConfigurationManager.AppSettings["pagesize"]);
            int totalCount = 0;/* = dac.GetProductTotalCount(storeCode, ProductCode);
*/
            PagingInfo pageInfo = new PagingInfo
            {
                TotalItems = totalCount,
                ItemsPerPage = pagesize,
                CurrentPage = page
            };


            ViewBag.LotID = lotID;
            ViewBag.PagingInfo = pageInfo;

            //datatable을 JSON으로 바꾸는 코드 => list로 바꾸기
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            TableData t = new TableData();
            List<ColumnsInfo> _col = new List<ColumnsInfo>();

            InspectDAC dac = new InspectDAC();
            DataTable dt = dac.GetData("2020-01-01", "2010-02-02","", "", "");
            //dac.Dispose();

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





            return View();
        }
    }
}