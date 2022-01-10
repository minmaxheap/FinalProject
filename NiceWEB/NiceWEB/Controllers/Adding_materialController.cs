using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NiceWEB.Models;

namespace NiceWEB.Controllers
{
    public class Adding_materialController : Controller
    {
        // GET: Adding_material
        public ActionResult Adding_material()
        {
            List<Adding_materialProperty> list = new List<Adding_materialProperty>();
            Adding_materialDAC dac = new Adding_materialDAC();
            list = dac.GetData(); // 원 데이터 조회
            return View(list); // 이거모르겠음 


        }
    }
}