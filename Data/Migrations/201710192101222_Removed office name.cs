namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedofficename : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Offices", "OfficeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offices", "OfficeName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
