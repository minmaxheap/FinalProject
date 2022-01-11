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

            TableData t = new TableData();

            //으갸갸갸갸갸갸갸갸ㅑ 어찌 뿌려줘 ㅡ흐ㅏㅈㄴ커라저렞럳재러ㅡㅐ러ㅔㅏ
           
            //combobox binding
            CommonDAC comDAC = new CommonDAC();

            Adding_materialDAC dac = new Adding_materialDAC();
            //List<Adding_materialProperty> list = dac.GetData();

            List<TableData> product = dac.GetProduct();
            //ViewBag.order = new SelectList(order, "Data", "Data");
            ViewBag.product = new SelectList(product, "Data", "Data");

           // List<string
            

            //datatable 
            // list로 보여주기 

            List<ColumnsInfo> _col = new List<ColumnsInfo>();


            return View();
        }
    }
}