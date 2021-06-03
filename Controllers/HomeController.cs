using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
namespace SampleMvcForAzure.Controllers
{
  public  class Item
    {
        public String ItemName
        {
            get;
            set;
        }
        public float Price
        {
            get;
            set;
        }
    }


    public class HomeController : Controller
    {
        MyItemContext ctx = new MyItemContext();
        public IActionResult Index()
        {

            return View();
        }

        
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(MyItem item)
        {
            MyItemContext ctx = new MyItemContext();
            ctx.MyItems.Add(item);
            ctx.SaveChanges();
            return View();

        }
        public IActionResult ViewItems()
        {
            MyItemContext ctx = new MyItemContext();
            List<MyItem> itemlist = ctx.MyItems.ToList<MyItem>();
            ViewBag.itemlist = itemlist;
            return View();
        }


        public async Task<IActionResult> GetFromStorage()
        {
            HttpClient client = new HttpClient();
            var res = await client.GetAsync("http://localhost:7074/api/Function3");


             var content = JsonConvert.DeserializeObject(await res.Content.ReadAsStringAsync())  ;
            ViewBag.content = content;
            return View();
        }

    }
}