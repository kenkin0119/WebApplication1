using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class AdminstratorsController : Controller
    {
        private TourContext db = new TourContext();

        // GET: Adminstrators
        public ActionResult Index()
        {
            return View(db.Administrators.ToList());
        }

        // GET: Adminstrators/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adminstrators adminstrators = db.Administrators.Find(id);
            if (adminstrators == null)
            {
                return HttpNotFound();
            }
            return View(adminstrators);
        }

        // GET: Adminstrators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adminstrators/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminID,AdminName,Account,Password")] Adminstrators adminstrators)
        {
            if (ModelState.IsValid)
            {
                db.Administrators.Add(adminstrators);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminstrators);
        }

        // GET: Adminstrators/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adminstrators adminstrators = db.Administrators.Find(id);
            if (adminstrators == null)
            {
                return HttpNotFound();
            }
            return View(adminstrators);
        }

        // POST: Adminstrators/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminID,AdminName,Account,Password")] Adminstrators adminstrators)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminstrators).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminstrators);
        }

        // GET: Adminstrators/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adminstrators adminstrators = db.Administrators.Find(id);
            if (adminstrators == null)
            {
                return HttpNotFound();
            }
            return View(adminstrators);
        }

        // POST: Adminstrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Adminstrators adminstrators = db.Administrators.Find(id);
            db.Administrators.Remove(adminstrators);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
