namespace Logics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewBookClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "LocationId", c => c.Int(nullable: false));
        }
    }
}
