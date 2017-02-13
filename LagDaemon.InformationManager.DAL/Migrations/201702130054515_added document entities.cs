namespace LagDaemon.InformationManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddocumententities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        PublishedOn = c.DateTime(),
                        Synopsys_TextBlockId = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.TextBlocks", t => t.Synopsys_TextBlockId)
                .Index(t => t.Synopsys_TextBlockId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.DocumentSections",
                c => new
                    {
                        DocumentSectionId = c.Int(nullable: false, identity: true),
                        DocumentSection_DocumentSectionId = c.Int(),
                        Document_DocumentId = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentSectionId)
                .ForeignKey("dbo.DocumentSections", t => t.DocumentSection_DocumentSectionId)
                .ForeignKey("dbo.Documents", t => t.Document_DocumentId)
                .Index(t => t.DocumentSection_DocumentSectionId)
                .Index(t => t.Document_DocumentId);
            
            CreateTable(
                "dbo.TextBlocks",
                c => new
                    {
                        TextBlockId = c.Int(nullable: false, identity: true),
                        Identifier = c.String(),
                        Title = c.String(),
                        Text = c.String(),
                        DocumentSection_DocumentSectionId = c.Int(),
                    })
                .PrimaryKey(t => t.TextBlockId)
                .ForeignKey("dbo.DocumentSections", t => t.DocumentSection_DocumentSectionId)
                .Index(t => t.DocumentSection_DocumentSectionId);
            
            CreateTable(
                "dbo.DocumentAuthor",
                c => new
                    {
                        DocumentId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocumentId, t.AuthorId })
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.DocumentId)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "Synopsys_TextBlockId", "dbo.TextBlocks");
            DropForeignKey("dbo.DocumentSections", "Document_DocumentId", "dbo.Documents");
            DropForeignKey("dbo.TextBlocks", "DocumentSection_DocumentSectionId", "dbo.DocumentSections");
            DropForeignKey("dbo.DocumentSections", "DocumentSection_DocumentSectionId", "dbo.DocumentSections");
            DropForeignKey("dbo.DocumentAuthor", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.DocumentAuthor", "DocumentId", "dbo.Documents");
            DropIndex("dbo.DocumentAuthor", new[] { "AuthorId" });
            DropIndex("dbo.DocumentAuthor", new[] { "DocumentId" });
            DropIndex("dbo.TextBlocks", new[] { "DocumentSection_DocumentSectionId" });
            DropIndex("dbo.DocumentSections", new[] { "Document_DocumentId" });
            DropIndex("dbo.DocumentSections", new[] { "DocumentSection_DocumentSectionId" });
            DropIndex("dbo.Documents", new[] { "Synopsys_TextBlockId" });
            DropTable("dbo.DocumentAuthor");
            DropTable("dbo.TextBlocks");
            DropTable("dbo.DocumentSections");
            DropTable("dbo.Authors");
            DropTable("dbo.Documents");
        }
    }
}
