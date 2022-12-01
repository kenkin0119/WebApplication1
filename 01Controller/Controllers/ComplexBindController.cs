using _01Controller.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    public class ComplexBindController : Controller
    {
        
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]                //class
        public ActionResult Create(Product product)
        {
            ViewBag.PId = product.PId;
            ViewBag.PName = product.PName;
            ViewBag.Price = product.Price;

            return View();
        }
    }
}