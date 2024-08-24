namespace EntityFrameworkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        IdStudent = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Address = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdStudent);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
