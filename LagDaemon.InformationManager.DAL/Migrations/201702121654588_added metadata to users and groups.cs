namespace LagDaemon.InformationManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmetadatatousersandgroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MetaDatas", "Group_GroupId", c => c.Int());
            CreateIndex("dbo.MetaDatas", "Group_GroupId");
            AddForeignKey("dbo.MetaDatas", "Group_GroupId", "dbo.Groups", "GroupId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetaDatas", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.MetaDatas", new[] { "Group_GroupId" });
            DropColumn("dbo.MetaDatas", "Group_GroupId");
        }
    }
}
