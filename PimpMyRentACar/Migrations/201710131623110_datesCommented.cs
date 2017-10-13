namespace PimpMyRentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datesCommented : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "PurchaseDate");
            DropColumn("dbo.Orders", "DepartureDate");
            DropColumn("dbo.Orders", "ArrivalDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ArrivalDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "DepartureDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "PurchaseDate", c => c.DateTime(nullable: false));
        }
    }
}
