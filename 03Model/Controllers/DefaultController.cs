using _03Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03Model.Controllers
{
    public class DefaultController : Controller
    {
        //建立一個dbSutdentEntities物件取名叫db
        dbSutdentEntities db = new dbSutdentEntities();
        public ActionResult Index()
        {
            var students = db.tStudent.ToList();//把讀出來的資料傳到View

            return View(students);
        }

        //新增
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tStudent student)
        {

            var id = student.fStuId;
            var result = db.tStudent.Find(id);


            if (result!=null)
            {
                ViewBag.ErrMsg="學號重複!!";
                return View(student);
            }



            if (ModelState.IsValid)
            {
                db.tStudent.Add(student);//把表單值新增至模型
                db.SaveChanges();//模型比對資料庫後自動使用下列SQL把資料寫入資料庫
                //insert  into  tStudent values(tStudent.fStuId,tStudent.fName,tStudent.Email,tStudent.Score)

                return RedirectToAction("Index");//重新導向到("")Action
            }



            return View(student);
        }

        public ActionResult Delete(string id)
        {
            var student=db.tStudent.Find(id);
            db.tStudent.Remove(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}