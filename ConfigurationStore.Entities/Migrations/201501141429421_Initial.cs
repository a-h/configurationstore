namespace ConfigurationStore.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EnvironmentTable_EnvironmentId = c.Int(),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.Environment", t => t.EnvironmentTable_EnvironmentId)
                .Index(t => t.EnvironmentTable_EnvironmentId);
            
            CreateTable(
                "dbo.ApplicationRequirement",
                c => new
                    {
                        ApplicationRequirementId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ApplicationRequirementTypeId = c.Int(nullable: false),
                        ApplicationTable_ApplicationId = c.Int(),
                    })
                .PrimaryKey(t => t.ApplicationRequirementId)
                .ForeignKey("dbo.ApplicationRequirementType", t => t.ApplicationRequirementTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Application", t => t.ApplicationTable_ApplicationId)
                .Index(t => t.ApplicationRequirementTypeId)
                .Index(t => t.ApplicationTable_ApplicationId);
            
            CreateTable(
                "dbo.ApplicationRequirementInstance",
                c => new
                    {
                        ApplicationRequirementInstanceId = c.Int(nullable: false, identity: true),
                        ApplicationRequirementId = c.Int(nullable: false),
                        EnvironmentId = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationRequirementInstanceId)
                .ForeignKey("dbo.ApplicationRequirement", t => t.ApplicationRequirementId, cascadeDelete: true)
                .ForeignKey("dbo.Environment", t => t.EnvironmentId, cascadeDelete: true)
                .Index(t => t.ApplicationRequirementId)
                .Index(t => t.EnvironmentId);
            
            CreateTable(
                "dbo.Environment",
                c => new
                    {
                        EnvironmentId = c.Int(nullable: false, identity: true),
                        SystemId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EnvironmentId)
                .ForeignKey("dbo.System", t => t.SystemId, cascadeDelete: true)
                .Index(t => t.SystemId);
            
            CreateTable(
                "dbo.System",
                c => new
                    {
                        SystemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SystemId);
            
            CreateTable(
                "dbo.ApplicationRequirementType",
                c => new
                    {
                        ApplicationRequirementTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ApplicationRequirementTypeId);
            
            CreateTable(
                "dbo.ConfigurationItem",
                c => new
                    {
                        ConfigurationItemId = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ConfigurationItemId)
                .ForeignKey("dbo.Application", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.ConfigurationItemInstance",
                c => new
                    {
                        ConfigurationItemInstanceId = c.Int(nullable: false, identity: true),
                        ConfigurationItemId = c.Int(nullable: false),
                        EnvironmentId = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ConfigurationItemInstanceId)
                .ForeignKey("dbo.ConfigurationItem", t => t.ConfigurationItemId, cascadeDelete: true)
                .ForeignKey("dbo.Environment", t => t.EnvironmentId, cascadeDelete: true)
                .Index(t => t.ConfigurationItemId)
                .Index(t => t.EnvironmentId);
            
            CreateTable(
                "dbo.SystemTableApplicationTables",
                c => new
                    {
                        SystemTable_SystemId = c.Int(nullable: false),
                        ApplicationTable_ApplicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SystemTable_SystemId, t.ApplicationTable_ApplicationId })
                .ForeignKey("dbo.System", t => t.SystemTable_SystemId, cascadeDelete: true)
                .ForeignKey("dbo.Application", t => t.ApplicationTable_ApplicationId, cascadeDelete: true)
                .Index(t => t.SystemTable_SystemId)
                .Index(t => t.ApplicationTable_ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConfigurationItemInstance", "EnvironmentId", "dbo.Environment");
            DropForeignKey("dbo.ConfigurationItemInstance", "ConfigurationItemId", "dbo.ConfigurationItem");
            DropForeignKey("dbo.ConfigurationItem", "ApplicationId", "dbo.Application");
            DropForeignKey("dbo.ApplicationRequirement", "ApplicationTable_ApplicationId", "dbo.Application");
            DropForeignKey("dbo.ApplicationRequirement", "ApplicationRequirementTypeId", "dbo.ApplicationRequirementType");
            DropForeignKey("dbo.ApplicationRequirementInstance", "EnvironmentId", "dbo.Environment");
            DropForeignKey("dbo.Environment", "SystemId", "dbo.System");
            DropForeignKey("dbo.SystemTableApplicationTables", "ApplicationTable_ApplicationId", "dbo.Application");
            DropForeignKey("dbo.SystemTableApplicationTables", "SystemTable_SystemId", "dbo.System");
            DropForeignKey("dbo.Application", "EnvironmentTable_EnvironmentId", "dbo.Environment");
            DropForeignKey("dbo.ApplicationRequirementInstance", "ApplicationRequirementId", "dbo.ApplicationRequirement");
            DropIndex("dbo.SystemTableApplicationTables", new[] { "ApplicationTable_ApplicationId" });
            DropIndex("dbo.SystemTableApplicationTables", new[] { "SystemTable_SystemId" });
            DropIndex("dbo.ConfigurationItemInstance", new[] { "EnvironmentId" });
            DropIndex("dbo.ConfigurationItemInstance", new[] { "ConfigurationItemId" });
            DropIndex("dbo.ConfigurationItem", new[] { "ApplicationId" });
            DropIndex("dbo.Environment", new[] { "SystemId" });
            DropIndex("dbo.ApplicationRequirementInstance", new[] { "EnvironmentId" });
            DropIndex("dbo.ApplicationRequirementInstance", new[] { "ApplicationRequirementId" });
            DropIndex("dbo.ApplicationRequirement", new[] { "ApplicationTable_ApplicationId" });
            DropIndex("dbo.ApplicationRequirement", new[] { "ApplicationRequirementTypeId" });
            DropIndex("dbo.Application", new[] { "EnvironmentTable_EnvironmentId" });
            DropTable("dbo.SystemTableApplicationTables");
            DropTable("dbo.ConfigurationItemInstance");
            DropTable("dbo.ConfigurationItem");
            DropTable("dbo.ApplicationRequirementType");
            DropTable("dbo.System");
            DropTable("dbo.Environment");
            DropTable("dbo.ApplicationRequirementInstance");
            DropTable("dbo.ApplicationRequirement");
            DropTable("dbo.Application");
        }
    }
}
