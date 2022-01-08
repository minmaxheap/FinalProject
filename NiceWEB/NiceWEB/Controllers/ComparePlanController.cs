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

            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                _col.Add(new ColumnsInfo { Title = dt.Columns[i].ColumnName, Data = dt.Columns[i].ColumnName });
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

        //public JsonResult EmpDetails()
        //{
        //    //Creating List
        //    List<Employee> ObjEmp = new List<Employee>()
        //    {
        ////Adding records to list
        //new Employee {Id=1,Name="Vithal Wadje",City="Latur",Address="Kabansangvi" },
        //new Employee {Id=2,Name="Sudhir Wadje",City="Mumbai",Address="Kurla" }
        //    };
        //    //return list as Json
        //    return Json(ObjEmp, JsonRequestBehavior.AllowGet);
        //}

        //public class Employee
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string City { get; set; }
        //    public string Address { get; set; }
        //}

     
    }
}