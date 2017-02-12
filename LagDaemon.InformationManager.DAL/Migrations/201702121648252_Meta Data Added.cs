namespace LagDaemon.InformationManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MetaDataAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MetaDatas",
                c => new
                    {
                        MetaDataId = c.Int(nullable: false, identity: true),
                        Identifier = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Value_MetaValueId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MetaDataId)
                .ForeignKey("dbo.MetaValues", t => t.Value_MetaValueId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Value_MetaValueId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.MetaValues",
                c => new
                    {
                        MetaValueId = c.Int(nullable: false, identity: true),
                        Value = c.Boolean(),
                        Value1 = c.DateTime(),
                        Value2 = c.Double(),
                        Value3 = c.Single(),
                        Value4 = c.Int(),
                        Value5 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MetaValueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetaDatas", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.MetaDatas", "Value_MetaValueId", "dbo.MetaValues");
            DropIndex("dbo.MetaDatas", new[] { "User_UserId" });
            DropIndex("dbo.MetaDatas", new[] { "Value_MetaValueId" });
            DropTable("dbo.MetaValues");
            DropTable("dbo.MetaDatas");
        }
    }
}
