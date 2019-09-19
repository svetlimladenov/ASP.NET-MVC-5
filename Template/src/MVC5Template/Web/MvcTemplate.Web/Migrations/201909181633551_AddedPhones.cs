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
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Phones", new[] { "UserId" });
            DropTable("dbo.Phones");
        }
    }
}
