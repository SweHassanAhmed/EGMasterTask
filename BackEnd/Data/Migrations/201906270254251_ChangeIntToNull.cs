namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIntToNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Calls", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Calls", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.Clients", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Clients", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.Employees", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Employees", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ModifiedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "ModifiedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Calls", "ModifiedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Calls", "CreatedBy", c => c.Int(nullable: false));
        }
    }
}
