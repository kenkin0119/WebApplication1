using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04ViewModel.Models;
using _04ViewModel.ViewModels;

namespace _04ViewModel.Controllers
{
    public class tEmployeesController : Controller
    {
        // 第一件事要建立dbContext
        dbEmployeeEntities1 db = new dbEmployeeEntities1();
        
        //讀出tEmployee資料表，並建立成List
        public ActionResult Index(int deptId = 1)
        {
            EmpDept emp = new EmpDept()
            {
                department = db.tDepartment.ToList(),
                employee = db.tEmployee.Where(e => e.fDepId == deptId).ToList()
            };

            ViewBag.deptName = db.tDepartment.Find(deptId).fDepName;
            ViewBag.deptId = deptId;

            return View(emp);
        }

        public ActionResult Create()
        {
            ViewBag.Dept = db.tDepartment.ToList(); //傳值到View
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tEmployee employee)
        {
            if(ModelState.IsValid) 
            {
                try //try只能抓例外(阻擋錯誤訊息)  連結第三方容易出現例外 ex:資料庫發生的錯誤
                {
                    db.tEmployee.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { deptId = employee.fDepId }); //從網址帶值回去
                }
                catch
                {
                    ViewBag.Msg = "驗證失敗，請檢查員工代碼是否正確";
                    ViewBag.Dept = db.tDepartment.ToList();
                    return View(employee);
                }
                
            }
                ViewBag.Msg = "驗證失敗，請檢查表單資料是否正確";
                ViewBag.Dept = db.tDepartment.ToList();
                return View(employee);
             
        }
    }
}