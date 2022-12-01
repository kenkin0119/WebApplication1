using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    public class SimpleBindController : Controller
    {
        
        public ActionResult Create()
        {
            return View();
        }
        //接收表單送過來的資料
        //method 選Post 所以會挑這個Create
        [HttpPost]
        public ActionResult Create(string PId,string PName,int Price)
        {
            ViewBag.PId = PId;
            ViewBag.PName = PName;
            ViewBag.Price = Price;

            return View();
        }

        public ActionResult Index()
        {
            //只有Action可以return View

            return View();
        }
    }
}