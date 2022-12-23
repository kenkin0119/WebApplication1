using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            var emp = db.tEmployee.Find(employee.fEmpId);   //try只能抓例外(阻擋錯誤訊息)  連結第三方容易出現例外 ex:資料庫發生的錯誤

            if (emp != null)
                {
                    ViewBag.PKCheck = "員工代碼重複";
                }
            else if(ModelState.IsValid)
                {
                    db.tEmployee.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { deptId = employee.fDepId }); //從網址帶值回去
                }
            else
                {
                    ViewBag.Msg = "驗證失敗，請檢查表單資料是否正確";
                }

            ViewBag.Dept = db.tDepartment.ToList();
            return View(employee);

        }

        public ActionResult Edit(string id) //因為是從既有的資料作修改(已有id)可以用Find(id)傳進View
        {                                   //不用像Create一樣用網址傳值
            var emp = db.tEmployee.Find(id);
            ViewBag.Dept = db.tDepartment.ToList();

            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tEmployee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified; //讓db.tEmployee變為可修改
                db.SaveChanges();
                return RedirectToAction("Index", new {depId = employee.fDepId});
            }
            return View(employee);
        }

        public ActionResult Delete(String id)
        {
            var emp = db.tEmployee.Find(id);
            db.tEmployee.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index", new {deptId=emp.fDepId});
        }
    }
}