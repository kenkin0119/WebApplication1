using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tour.Models
{
            //DropCreateDatabaseAlways:執行就砍掉資料庫並重新建立
            //DropCreateDatabaseIfModelChanges:資料庫模型變動就砍掉重建

            //寫在Global.asax
            //啟動DB Initializer建立資料庫  每次載入網頁時啟動
            //Database.SetInitializer<MCSDD01Context>(new MCSDD01initializer() );
    public class Tourinitializer: DropCreateDatabaseIfModelChanges<TourContext>
    {
        protected override void Seed(TourContext db)
        {
            base.Seed(db);

            List<Members> members = new List<Members> {

                new Members
                {
                    MemberName="member01",
                    MemberBirthday=Convert.ToDateTime("1999/10/10"),
                    CreatedDate=DateTime.Today,
                    Account="member",
                    Password="12345678"
                }
            };
            members.ForEach(s => db.Members.Add(s));
            db.SaveChanges();

            List<Adminstrators> admins = new List<Adminstrators> {

                new Adminstrators
                {
                    AdminName = "admin01",
                    Account = "admin",
                    Password = "12345678"
                }
            };
            admins.ForEach(s => db.Administrators.Add(s));
            db.SaveChanges();
        }
    }
}