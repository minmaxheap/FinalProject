using NiceWEB.Models;
using System;
using System.Collections.Generic;
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
        //    ComparePlanDAC db = new ComparePlanDAC();
        //    List<ComparePlan> list = db.GetChartData("1997-01-01", "1997-12-31");

        //    var statGroup = from stat in list
        //                    orderby stat.PRODUCT_NAME
        //                    group stat by stat.PRODUCT_NAME;

        //    int k = 1;
        //    StringBuilder sb = new StringBuilder();

        //    foreach (var prodGroup in statGroup) //3번
        //    {
        //        List<int> amts = new List<int>();
        //        foreach (var prodStat in prodGroup) //12번
        //        {
        //            amts.Add(Convert.ToInt32(prodStat.DEFECT_QTY));

        //            if (k == 1)
        //                sb.Append(prodStat.DEFECT_QTY + "월,");
        //        }

        //        if (k == 1)
        //        {
        //            ViewBag.Label1 = prodGroup.Key;
        //            ViewBag.data1 = "[" + string.Join(",", amts) + "]";
        //        }
        //        else if (k == 2)
        //        {
        //            ViewBag.Label2 = prodGroup.Key;
        //            ViewBag.data2 = "[" + string.Join(",", amts) + "]";
        //        }
        //        else if (k == 3)
        //        {
        //            ViewBag.Label3 = prodGroup.Key;
        //            ViewBag.data3 = "[" + string.Join(",", amts) + "]";
        //        }

        //        k++;
        //    }
        //    ViewBag.Labels = sb.ToString().TrimEnd(',');

        //    ViewBag.Labels = "1월,2월,3월,4월,5월,6월,7월,8월,9월,10월,11월,12월";

        //    ViewBag.Label1 = "제품1";
        //    ViewBag.data1 = "[28, 48, 40, 19, 86, 27, 28, 48, 40, 19, 86, 27]";

        //    ViewBag.Label2 = "제품2";
        //    ViewBag.data2 = "[86, 27, 28, 48, 40, 19, 86, 27,28, 48, 40, 19]";

        //    ViewBag.Label3 = "제품3";
        //    ViewBag.data3 = "[40, 19, 86, 27, 28, 48, 40, 19, 86, 27,28, 48]";

            return View();
        }
    }
}