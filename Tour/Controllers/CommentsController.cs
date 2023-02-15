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
    public class CommentsController : Controller
    {
        private TourContext db = new TourContext();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Attrations).Include(c => c.Members);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.AttrationID = new SelectList(db.Attrations, "AttrationID", "AttrationName");
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName");
            return View();
        }

        // POST: Comments/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttrationID,MemberID,Contents,Photos,DateTime,HashTag,Rate")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttrationID = new SelectList(db.Attrations, "AttrationID", "AttrationName", comments.AttrationID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", comments.MemberID);
            return View(comments);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttrationID = new SelectList(db.Attrations, "AttrationID", "AttrationName", comments.AttrationID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", comments.MemberID);
            return View(comments);
        }

        // POST: Comments/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttrationID,MemberID,Contents,Photos,DateTime,HashTag,Rate")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttrationID = new SelectList(db.Attrations, "AttrationID", "AttrationName", comments.AttrationID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", comments.MemberID);
            return View(comments);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comments comments = db.Comments.Find(id);
            db.Comments.Remove(comments);
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
