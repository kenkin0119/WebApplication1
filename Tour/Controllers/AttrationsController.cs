using PagedList;
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
    [LoginCheck]
    public class AttrationsController : Controller
    {
        private TourContext db = new TourContext();
        SetData sd = new SetData();
        GetData gd = new GetData();

        int pageSize = 20;

        public ActionResult Index(int page = 1)
        {
            //pagedlist
            int currentPage = page < 1 ? 1 : page;

            var Attration = db.Attrations.ToList();

            var result = Attration.ToPagedList(currentPage, pageSize);

            return View(result);
        }

        [LoginCheck(flag = false)]
        public ActionResult Search()
        {
            return View();
        }

        [LoginCheck(flag = false)]
        [HttpPost]
        public ActionResult Search(string keyword)
        {
            string sql = "SELECT *  FROM Attrations WHERE AttrationName like '%'+@keyword+'%' or Address like '%'+@keyword+'%'";

            List<SqlParameter> list = new List<SqlParameter> { 
            new SqlParameter("keyword",keyword)
            };

            var result = gd.TableQuery(sql, list, false);

            return View(result);
        }

        // GET: Attrations/Details/5
        public ActionResult _Details(int? id)
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
            return PartialView(attrations);
        }

        // GET: Attrations/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Attrations/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "AttrationID,AttrationName,Address,Picture1,Picdescribe1,Description,Tel,Ticketinfo,Px,Py")] Attrations attrations)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Attrations.Add(attrations);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(attrations);
        //}

        // GET: Attrations/Edit/5
        public ActionResult _Edit(int? id)
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
            return PartialView(attrations);
        }

        // POST: Attrations/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Edit(Attrations attrations)
        {
            string sql = "update Attrations set AttrationName=@AttrationName , Address=@Address , Picture1=@Picture1 , Picdescribe1=@Picdescribe1 , Description=@Description , Tel=@Tel , Ticketinfo=@Ticketinfo , Px=@Px , Py=@Py where AttrationID=@AttrationID";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("AttrationID",attrations.AttrationID),
                new SqlParameter("AttrationName",attrations.AttrationName),
                new SqlParameter("Address",attrations.Address),
                new SqlParameter("Picture1",attrations.Picture1),
                new SqlParameter("Picdescribe1",attrations.Picdescribe1),
                new SqlParameter("Description",attrations.Description),
                new SqlParameter("Tel",attrations.Tel),
                new SqlParameter("Ticketinfo",attrations.Ticketinfo),
                new SqlParameter("Px",attrations.Px),
                new SqlParameter("Py",attrations.Py)
            };


                sd.executeSql(sql, list);//因為存取資料庫容易發生例外
                return RedirectToAction("Index");



        }

        // GET: Attrations/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Attrations attrations = db.Attrations.Find(id);
        //    if (attrations == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(attrations);
        //}

        // POST: Attrations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Attrations attrations = db.Attrations.Find(id);
        //    db.Attrations.Remove(attrations);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
