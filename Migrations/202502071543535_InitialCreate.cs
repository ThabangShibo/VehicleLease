namespace VehicleLease.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyBranches",
                c => new
                    {
                        CompanyBranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(nullable: false),
                        BranchLocation = c.String(nullable: false),
                        NumberOfVehiclesOwned = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyBranchId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        CustomerAddress = c.String(nullable: false),
                        NumberOfVehiclesLeased = c.Int(nullable: false),
                        CompanyBranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.CompanyBranches", t => t.CompanyBranchId, cascadeDelete: true)
                .Index(t => t.CompanyBranchId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VehicleMake = c.String(nullable: false),
                        VehicleModel = c.String(nullable: false),
                        VehicleMileage = c.String(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.CustomerId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        DriverName = c.String(),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        SupplierLocation = c.String(),
                        CompanyBranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.CompanyBranches", t => t.CompanyBranchId, cascadeDelete: true)
                .Index(t => t.CompanyBranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "CompanyBranchId", "dbo.CompanyBranches");
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Vehicles", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CompanyBranchId", "dbo.CompanyBranches");
            DropIndex("dbo.Suppliers", new[] { "CompanyBranchId" });
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            DropIndex("dbo.Vehicles", new[] { "CustomerId" });
            DropIndex("dbo.Vehicles", new[] { "SupplierId" });
            DropIndex("dbo.Customers", new[] { "CompanyBranchId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Drivers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Customers");
            DropTable("dbo.CompanyBranches");
        }
    }
}
