using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class HomeController : Controller
    {
        GetData gd = new GetData();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            string sql = "select * from Members where Account=@id and Password=@pw";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@id",vMLogin.Account),
                new SqlParameter("@pw",vMLogin.Password)
            };

            var rd = gd.LoginQuery(sql, list);
            if (rd != null && rd.HasRows)
            {
                Session["user"] = rd;
                rd.Close();
                return RedirectToAction("Index");
            }

            ViewBag.ErrMsg = "帳號或密碼有誤";
            rd.Close();
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login");
        }
    }
}