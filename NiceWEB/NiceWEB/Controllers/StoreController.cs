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
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            StoreDAC dac = new StoreDAC();
            List<StoreProperty> list = dac.GetData();

            List<string> product = dac.GetProductCode();


           // ViewBag.product = new SelectList(product, "Data", "Data");

            return View(list);
        }
    }
}