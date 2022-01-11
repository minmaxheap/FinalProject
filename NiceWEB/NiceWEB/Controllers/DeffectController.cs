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
    public class DeffectController : Controller
    {
        // GET: Deffect
        public ActionResult Index()
        {
            DeffectDAC dac = new DeffectDAC();
            List<DeffectProperty> list = dac.GetData();
            return View(list);
        }
    }
}