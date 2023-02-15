using _06ADOnet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06ADOnet.Controllers
{
    public class LoginController : Controller
    {
        //NorthwindEntities2 db = new NorthwindEntities2();

        GetData gd = new GetData();

        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(VMLogin vMLogin)
        //{
        //    var emp= db.Employees.Where(e => e.LastName == vMLogin.Account && e.FirstName == vMLogin.Password).FirstOrDefault();

        //    if (emp == null)
        //    {
        //        ViewBag.ErrMsg = "帳號或密碼有誤";
        //        return View();
        //    }

        //    //若帳號密碼打對,則登入成功,跳轉至後台管理首頁
        //    Session["emp"] = emp;  //把登入成功的狀態保留在session裡面

        //    return RedirectToAction("Index", "Customers");

        //}

        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {   //避免將變數和sql語法寫一起 以免受到攻擊 ' or 1=1--
            //string sql = "select * from Employees where LastName='"+vMLogin.Account+"' and FirstName='"+vMLogin.Password+"'";
            string sql = "select * from Employees where LastName=@id and FirstName=@pw";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@id",vMLogin.Account),
                new SqlParameter("@pw",vMLogin.Password)
            };

            var rd = gd.LoginQuery(sql,list);
            if (rd == null)
            {
                return View();
            }

            if (rd.HasRows)
            {
                Session["emp"] = rd;
                rd.Close();
                return RedirectToAction("Index", "Customers");
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