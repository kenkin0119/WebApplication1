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
    public class AttrationsController : Controller
    {
        private TourContext db = new TourContext();

        // GET: Attrations
        public ActionResult Index()
        {
            return View(db.Attrations.ToList());
        }

        // GET: Attrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attrations attrations = db.Attrations.Find(id);
            if (attrations == null)
            {
                return HttpNotFound();
            }
            return View(attrations);
        }

        // GET: Attrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attrations/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttrationID,AttrationName,Address,AttrationPhotos")] Attrations attrations)
        {
            if (ModelState.IsValid)
            {
                db.Attrations.Add(attrations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attrations);
        }

        // GET: Attrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attrations attrations = db.Attrations.Find(id);
            if (attrations == null)
            {
                return HttpNotFound();
            }
            return View(attrations);
        }

        // POST: Attrations/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttrationID,AttrationName,Address,AttrationPhotos")] Attrations attrations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attrations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attrations);
        }

        // GET: Attrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attrations attrations = db.Attrations.Find(id);
            if (attrations == null)
            {
                return HttpNotFound();
            }
            return View(attrations);
        }

        // POST: Attrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attrations attrations = db.Attrations.Find(id);
            db.Attrations.Remove(attrations);
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
