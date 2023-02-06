using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MCSDD01.Models
{
    public class MCSDD01Context:DbContext //繼承DB Context類別
    {
                //            類別          建構子:名稱必定和類別一樣,鑄造物件(r)的工法
                //建構子 ex: Random r = new Random();      
        public MCSDD01Context():base("name=MCSDD01Connection")
        {

        }

        //這段用意是要指定連線資料庫的字串(DB First 專用)
        //       override(部分繼承):1.抽象類別 2.介面(開頭有I)
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        //描述資料庫裡面的資料表
        public virtual DbSet<Employees>Employees { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PayTypes> PayTypes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
    }
}