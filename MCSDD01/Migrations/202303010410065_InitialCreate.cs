namespace MCSDD01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 40),
                        CreatedDate = c.DateTime(nullable: false),
                        Account = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        MemberName = c.String(nullable: false, maxLength: 40),
                        MemberPhotoFile = c.String(),
                        MemberBirthday = c.DateTime(nullable: false),
                        Account = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.String(nullable: false, maxLength: 11),
                        ProductID = c.String(nullable: false, maxLength: 6),
                        UnitPrice = c.Short(nullable: false),
                        Quantity = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.String(nullable: false, maxLength: 11),
                        OrderDate = c.DateTime(nullable: false),
                        ShipName = c.String(nullable: false, maxLength: 40),
                        ShipAddress = c.String(nullable: false, maxLength: 100),
                        ShippedDate = c.DateTime(),
                        EmployeeID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                        ShipID = c.Int(nullable: false),
                        PayTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.PayTypes", t => t.PayTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Shippers", t => t.ShipID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.MemberID)
                .Index(t => t.ShipID)
                .Index(t => t.PayTypeID);
            
            CreateTable(
                "dbo.PayTypes",
                c => new
                    {
                        PayTypeID = c.Int(nullable: false, identity: true),
                        PayTypeName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.PayTypeID);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        ShipVia = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ShipID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.String(nullable: false, maxLength: 6),
                        ProductName = c.String(nullable: false, maxLength: 150),
                        PhotoFile = c.Binary(nullable: false),
                        ImageMimeType = c.String(nullable: false, maxLength: 10),
                        UnitPrice = c.Short(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        UnitsInStock = c.Short(nullable: false),
                        Discontinued = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ShipID", "dbo.Shippers");
            DropForeignKey("dbo.Orders", "PayTypeID", "dbo.PayTypes");
            DropForeignKey("dbo.Orders", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Orders", new[] { "PayTypeID" });
            DropIndex("dbo.Orders", new[] { "ShipID" });
            DropIndex("dbo.Orders", new[] { "MemberID" });
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropTable("dbo.Products");
            DropTable("dbo.Shippers");
            DropTable("dbo.PayTypes");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Members");
            DropTable("dbo.Employees");
        }
    }
}
