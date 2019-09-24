namespace Torshia.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEnities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Status = c.Int(nullable: false),
                        ReportedOn = c.DateTime(nullable: false),
                        TaskId = c.String(maxLength: 128),
                        ReporterId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReporterId)
                .ForeignKey("dbo.Tasks", t => t.TaskId)
                .Index(t => t.TaskId)
                .Index(t => t.ReporterId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        IsReported = c.Boolean(nullable: false),
                        Description = c.String(),
                        AffectedSectors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskApplicationUsers",
                c => new
                    {
                        Task_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Task_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Task_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "DisplayName", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.TaskApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TaskApplicationUsers", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.Reports", "ReporterId", "dbo.AspNetUsers");
            DropIndex("dbo.TaskApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TaskApplicationUsers", new[] { "Task_Id" });
            DropIndex("dbo.Reports", new[] { "ReporterId" });
            DropIndex("dbo.Reports", new[] { "TaskId" });
            DropColumn("dbo.AspNetUsers", "IsActive");
            DropColumn("dbo.AspNetUsers", "DisplayName");
            DropTable("dbo.TaskApplicationUsers");
            DropTable("dbo.Tasks");
            DropTable("dbo.Reports");
        }
    }
}
