using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using MCSDD01.Models;
using PagedList;

namespace MCSDD01.Controllers
{
    [LoginCheck]
    public class MembersController : Controller
    {
        private MCSDD01Context db = new MCSDD01Context();
        SetData sd = new SetData();
        int pageSize = 10;
        
        public ActionResult Index(int page = 1)
        {
            //pagedlist
            int currentPage = page < 1 ? 1 : page;

            var member = db.Members.ToList();

            var result = member.ToPagedList(currentPage, pageSize);

            return View(result);
        }

        // GET: Members/Details/5
        [ChildActionOnly]
        public ActionResult _Details(int? id)
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
            return PartialView(members);
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
        public ActionResult Create(Members members, HttpPostedFileBase photo)
        {
            string photoPath = "";

            if (ModelState.IsValid && members.MemberBirthday.Year > 1753)
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

                members.MemberPhotoFile = photoPath;

                string sql = "insert into Members(MemberName,MemberPhotoFile,MemberBirthday,Account,Password,CreatedDate) values(@MemberName,@MemberPhotoFile,@MemberBirthday,@Account,@Password,@CreatedDate)";

                List<SqlParameter> list = new List<SqlParameter>
                {
                    new SqlParameter("MemberName",members.MemberName),
                    new SqlParameter("MemberPhotoFile",members.MemberPhotoFile),
                    new SqlParameter("MemberBirthday",members.MemberBirthday),
                    new SqlParameter("Account",members.Account),
                    new SqlParameter("Password",members.Password),
                    new SqlParameter("CreatedDate",DateTime.Today)
                };

                sd.executeSql(sql, list);
                return RedirectToAction("Index");
            }

            return View(members);
        }

        // GET: Members/Edit/5
        public ActionResult _Edit(int? id)
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
            return PartialView(members);
        }

        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Edit(Members members)
        {

            string sql = "update members set MemberName=@MemberName , MemberBirthday=@MemberBirthday where MemberID=@MemberID";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("MemberID",members.MemberID),
                new SqlParameter("MemberName",members.MemberName),
                new SqlParameter("MemberBirthday",members.MemberBirthday)
            };

            try
            {
                sd.executeSql(sql, list);//因為存取資料庫容易發生例外
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
                return RedirectToAction("Index",members);
            }

            //if (ModelState.IsValid)
            //{
            //    db.Entry(members).State = EntityState.Modified;
            //    db.SaveChanges();
                
            //}
            
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
