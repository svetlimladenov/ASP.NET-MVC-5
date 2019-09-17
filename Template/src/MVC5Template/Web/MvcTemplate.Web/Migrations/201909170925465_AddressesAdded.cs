namespace MvcTemplate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        UserAddressId = c.String(nullable: false, maxLength: 128),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Zipcode = c.Int(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.UserAddressId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAddressId)
                .Index(t => t.UserAddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAddresses", "UserAddressId", "dbo.AspNetUsers");
            DropIndex("dbo.UserAddresses", new[] { "UserAddressId" });
            DropTable("dbo.UserAddresses");
        }
    }
}
