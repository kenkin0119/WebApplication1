using MCSDD01.Models;
using MCSDD01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MCSDD01.Controllers
{
    public class HomeController : Controller
    {
        MCSDD01Context db = new MCSDD01Context();
        public ActionResult Index()
        {

            var products = db.Products.Where(p => p.Discontinued == false).ToList();

            return View(products);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            string password = BR.getHashPassword(vMLogin.Password);

            var user = db.Members.Where(m => m.Account == vMLogin.Account && m.Password == password).FirstOrDefault();

            if (user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有誤";
                return View(vMLogin);
            }

            Session["member"] = user;
            return RedirectToAction("Index");
        }

        [LoginCheck(id = 1)]
        public ActionResult Logout()
        {
            Session["member"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult Display(string id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Find(id);

            if(product == null)
                return HttpNotFound();

            return View(product);
        }

        public ActionResult MyCart()
        {
            return View();
        }
    }
}
