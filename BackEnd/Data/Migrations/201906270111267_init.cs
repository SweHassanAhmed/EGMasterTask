namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calls",
                c => new
                    {
                        CallID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Date = c.DateTime(),
                        Project = c.String(),
                        IsDone = c.Boolean(nullable: false),
                        IsIncome = c.Boolean(nullable: false),
                        Type = c.String(),
                        ClientID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModificationDate = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CallID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: false)
                .Index(t => t.ClientID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Source = c.String(),
                        Classification = c.String(),
                        Mobile = c.String(),
                        Telephone1 = c.String(),
                        Telephone2 = c.String(),
                        WhatsNumber = c.String(),
                        Email = c.String(),
                        Nationality = c.String(),
                        EmployeeID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModificationDate = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: false)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModificationDate = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Calls", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Calls", "ClientID", "dbo.Clients");
            DropIndex("dbo.Clients", new[] { "EmployeeID" });
            DropIndex("dbo.Calls", new[] { "EmployeeID" });
            DropIndex("dbo.Calls", new[] { "ClientID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
            DropTable("dbo.Calls");
        }
    }
}
