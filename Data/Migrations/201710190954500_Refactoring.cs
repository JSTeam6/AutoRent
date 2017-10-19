namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false, maxLength: 20),
                        Model = c.String(nullable: false, maxLength: 20),
                        Type = c.String(nullable: false, maxLength: 20),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailableFrom = c.DateTime(),
                        OfficeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offices", t => t.OfficeId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, maxLength: 20),
                        OfficeName = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.City);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DepartureDate = c.DateTime(),
                        ArrivalDate = c.DateTime(),
                        ICar_Id = c.Int(),
                        Car_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.ICar_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.CarId)
                .Index(t => t.UserId)
                .Index(t => t.ICar_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        FamilyName = c.String(nullable: false, maxLength: 20),
                        PIN = c.String(nullable: false, maxLength: 10),
                        DrivingLicenseNumber = c.String(nullable: false, maxLength: 10),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "ICar_Id", "dbo.Cars");
            DropForeignKey("dbo.Orders", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "OfficeId", "dbo.Offices");
            DropIndex("dbo.Orders", new[] { "Car_Id" });
            DropIndex("dbo.Orders", new[] { "ICar_Id" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "CarId" });
            DropIndex("dbo.Offices", new[] { "City" });
            DropIndex("dbo.Cars", new[] { "OfficeId" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Offices");
            DropTable("dbo.Cars");
        }
    }
}
