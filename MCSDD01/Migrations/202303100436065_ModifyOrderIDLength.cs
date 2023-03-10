namespace MCSDD01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyOrderIDLength : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropPrimaryKey("dbo.OrderDetails");
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.OrderDetails", "OrderID", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Orders", "OrderID", c => c.String(nullable: false, maxLength: 12));
            AddPrimaryKey("dbo.OrderDetails", new[] { "OrderID", "ProductID" });
            AddPrimaryKey("dbo.Orders", "OrderID");
            CreateIndex("dbo.OrderDetails", "OrderID");
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.OrderDetails");
            AlterColumn("dbo.Orders", "OrderID", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.OrderDetails", "OrderID", c => c.String(nullable: false, maxLength: 11));
            AddPrimaryKey("dbo.Orders", "OrderID");
            AddPrimaryKey("dbo.OrderDetails", new[] { "OrderID", "ProductID" });
            CreateIndex("dbo.OrderDetails", "OrderID");
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
    }
}
