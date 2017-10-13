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
                        Type = c.String(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Office_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offices", t => t.Office_Id)
                .Index(t => t.Office_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CarId = c.Int(),
                        PurchaseDate = c.DateTime(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.UserId);
            
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
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offices", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cars", "Office_Id", "dbo.Offices");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "Id", "dbo.Cars");
            DropIndex("dbo.Offices", new[] { "CityId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "Id" });
            DropIndex("dbo.Cars", new[] { "Office_Id" });
            DropTable("dbo.Offices");
            DropTable("dbo.Cities");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Cars");
        }
    }
}
