namespace MvcTemplate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Model = c.String(),
                        Manufacter = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Phones", new[] { "ApplicationUserId" });
            DropTable("dbo.Phones");
        }
    }
}
