namespace EntityFrameworkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        IdAddress = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.IdAddress);
            
            AddColumn("dbo.Students", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "AddressId");
            AddForeignKey("dbo.Students", "AddressId", "dbo.Addresses", "IdAddress", cascadeDelete: true);
            DropColumn("dbo.Students", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Address", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Students", new[] { "AddressId" });
            DropColumn("dbo.Students", "AddressId");
            DropTable("dbo.Addresses");
        }
    }
}
