namespace Logics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JustAnotherMigration0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Available = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Shelf_Number = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Shelves", t => t.Shelf_Number)
                .Index(t => t.Shelf_Number);
            
            CreateTable(
                "dbo.PersonBooks",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.PersonId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Passport = c.Int(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Role = c.Boolean(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Shelves",
                c => new
                    {
                        Number = c.Int(nullable: false, identity: true),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.Number);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Shelf_Number", "dbo.Shelves");
            DropForeignKey("dbo.PersonBooks", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonBooks", "BookId", "dbo.Books");
            DropIndex("dbo.PersonBooks", new[] { "PersonId" });
            DropIndex("dbo.PersonBooks", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "Shelf_Number" });
            DropTable("dbo.Shelves");
            DropTable("dbo.People");
            DropTable("dbo.PersonBooks");
            DropTable("dbo.Books");
        }
    }
}
