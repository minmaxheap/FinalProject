using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using NiceWEB.Models;
using System.Web.Script.Serialization;
using NiceWEB.Models.DAC;
namespace NiceWEB.Controllers
{
    public class DefectController : Controller
    {
        // GET: Deffect
        public ActionResult Index()
        {
            DefectDAC dac = new DefectDAC();
            List<DefectProperty> list = dac.GetData();
            return View(list);
        }
    }
}