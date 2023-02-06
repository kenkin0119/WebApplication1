using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MCSDD01.Models
{                                   //DropCreateDatabaseAlways:執行就砍掉資料庫並重新建立
                                    //DropCreateDatabaseIfModelChanges:資料庫模型變動就砍掉重建

                                    //寫在Global.asax
                                    //啟動DB Initializer建立資料庫  每次載入網頁時啟動
                                    //Database.SetInitializer<MCSDD01Context>(new MCSDD01initializer() );
    public class MCSDD01initializer: DropCreateDatabaseAlways<MCSDD01Context>
    {
        protected override void Seed(MCSDD01Context db)
        {
            base.Seed(db);

            ///////////////////
            ////建立某些資料表的基礎資料(沒有的話就上面那個就好)
            ///
            List<Shippers> shippers = new List<Shippers>
            {
                new Shippers
                {
                    ShipVia="到店取貨"
                },
                new Shippers
                {
                    ShipVia="宅配到府"
                },
                new Shippers
                {
                    ShipVia="郵寄"
                }
            };
            shippers.ForEach(s=>db.Shippers.Add(s));
            db.SaveChanges();

            List<PayTypes> payTypes = new List<PayTypes>
            {
                new PayTypes
                {
                    PayTypeName="信用卡"
                },
                new PayTypes
                {
                    PayTypeName="Line Pay"
                },
                new PayTypes
                {
                    PayTypeName="貨到付款"
                },
                new PayTypes
                {
                    PayTypeName="到店取貨付款"
                }
            };
            payTypes.ForEach(s=>db.PayTypes.Add(s));
            db.SaveChanges();

            List<Employees> employees = new List<Employees>
            {
                new Employees
                {
                    EmployeeName="張無忌",
                    CreatedDate=DateTime.Today,
                    Account="admin",
                    Password="12345678"
                }
            };
            employees.ForEach(s=>db.Employees.Add(s));
            db.SaveChanges();

            List<Members> members = new List<Members> {

                new Members
                {
                    MemberName="莊孝維",
                    MemberBirthday=Convert.ToDateTime("1999/10/10"),
                    CreatedDate=DateTime.Today,
                    Account="shiao",
                    Password="12345678"
                }
            };
            members.ForEach(s=>db.Members.Add(s));
            db.SaveChanges();

            
        }
    }
}