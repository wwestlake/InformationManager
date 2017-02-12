namespace LagDaemon.InformationManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGroups", "GroupId", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "UserId", "dbo.Groups");
            DropIndex("dbo.UserGroups", new[] { "GroupId" });
            DropIndex("dbo.UserGroups", new[] { "UserId" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.Groups");
        }
    }
}
