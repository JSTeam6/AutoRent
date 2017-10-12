namespace PimpMyRentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        OfficeId = c.Int(),
                        Type = c.String(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offices", t => t.OfficeId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PurchaseDate = c.DateTime(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        Car_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        FamilyName = c.String(nullable: false),
                        PIN = c.String(nullable: false),
                        DrivingLicenseNumber = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Offices", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cars", "OfficeId", "dbo.Offices");
            DropIndex("dbo.Orders", new[] { "Car_Id" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Offices", new[] { "CityId" });
            DropIndex("dbo.Cars", new[] { "OfficeId" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Cities");
            DropTable("dbo.Offices");
            DropTable("dbo.Cars");
        }
    }
}
