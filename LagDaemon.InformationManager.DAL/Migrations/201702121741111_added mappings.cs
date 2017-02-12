namespace LagDaemon.InformationManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmappings : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MetaValues", name: "Value", newName: "BooleanValue");
            RenameColumn(table: "dbo.MetaValues", name: "Value1", newName: "DateTimeValue");
            RenameColumn(table: "dbo.MetaValues", name: "Value2", newName: "DoubleValue");
            RenameColumn(table: "dbo.MetaValues", name: "Value3", newName: "FloatValue");
            RenameColumn(table: "dbo.MetaValues", name: "Value4", newName: "IntegerValue");
            RenameColumn(table: "dbo.MetaValues", name: "Value5", newName: "StringValue");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.MetaValues", name: "StringValue", newName: "Value5");
            RenameColumn(table: "dbo.MetaValues", name: "IntegerValue", newName: "Value4");
            RenameColumn(table: "dbo.MetaValues", name: "FloatValue", newName: "Value3");
            RenameColumn(table: "dbo.MetaValues", name: "DoubleValue", newName: "Value2");
            RenameColumn(table: "dbo.MetaValues", name: "DateTimeValue", newName: "Value1");
            RenameColumn(table: "dbo.MetaValues", name: "BooleanValue", newName: "Value");
        }
    }
}
