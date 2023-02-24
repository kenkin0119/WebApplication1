using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tour.Models;

namespace Tour.Controllers
{
    public class MembersController : Controller
    {
        private TourContext db = new TourContext();

        SetData sd = new SetData();

        // GET: Members
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Members members, HttpPostedFileBase photo,DateTime birth)
        {
            string photoPath = "";

            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                        if (photo.ContentLength > 0)
                        {
                            string subName = "";
                            string nowStr = DateTime.Now.ToString("yyyyMMddhhmmssff"); //取上傳時間(命名用)
                            string random = Guid.NewGuid().ToString(); //給變數 (命名用)
                            subName = photo.FileName.Substring(photo.FileName.IndexOf(".") + 1, 3);
                            subName = subName.ToLower();
                            if (subName == "jpg" || subName == "png" || subName == "gif")
                            {
                                photoPath = Server.MapPath("~/photos/" + nowStr + random + "." + subName);
                                photo.SaveAs(photoPath);
                            }
                        }
                    }

                members.MemberPhoto = photoPath;

                if (members.MemberBirthday != null)
                {
                    string sql = "insert into Members(MemberName,MemberPhoto,MemberBirthday,Account,Password,CreatedDate,FavoriteAt) values(@MemberName,@MemberPhoto,@MemberBirthday,@Account,@Password,@CreatedDate,@FavoriteAt)";

                    List<SqlParameter> list = new List<SqlParameter>
                {
                    new SqlParameter("MemberName",members.MemberName),
                    new SqlParameter("MemberPhoto",members.MemberPhoto),
                    new SqlParameter("MemberBirthday",members.MemberBirthday),
                    new SqlParameter("Account",members.Account),
                    new SqlParameter("Password",members.Password),
                    new SqlParameter("CreatedDate",DateTime.Today),
                    new SqlParameter("FavoriteAt","")
                };

                    sd.executeSql(sql, list);

                    //db.Members.Add(members);
                    //db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(members);
            }

            return View(members);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,MemberName,MemberPhoto,MemberBirthday,Account,Password,CreatedDate,FavoriteAt")] Members members)
        {
            if (ModelState.IsValid)
            {
                db.Entry(members).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(members);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Members members = db.Members.Find(id);
            db.Members.Remove(members);
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
