using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Tour.Models;

namespace Tour.Controllers
{
    public class LoginController : Controller
    {
        GetData gd = new GetData();

        // GET: Login
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
            if (rd == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有誤";
                return RedirectToAction("Index","Comments");
            }

            if (rd.HasRows)
            {
                Session["emp"] = rd;
                rd.Close();
                return RedirectToAction("Index", "Attrations");
            }

            ViewBag.ErrMsg = "帳號或密碼有誤";
            rd.Close();
            return View();
        }

        public ActionResult Logout()
        {
            Session["emp"] = null;
            return RedirectToAction("Login");
        }
    }
}