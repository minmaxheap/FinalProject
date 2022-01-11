using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using NiceWEB.Models;
using System.Web.Script.Serialization;

namespace NiceWEB.Controllers
{
    public class MaterialController : Controller
    {
        // GET: Material
        public ActionResult Index()
        {
            Adding_materialDAC dac = new Adding_materialDAC();
            List<Adding_materialProperty> list = dac.GetData();

            CommonDAC comDAC = new CommonDAC();
            //select box에 전달할 데이터
            List<TableData> product = dac.GetProduct();
          

            ViewBag.product = new SelectList(product, "Data", "Data");

            return View(list);
        }

       
    }
}