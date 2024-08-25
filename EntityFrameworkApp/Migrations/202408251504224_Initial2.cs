namespace EntityFrameworkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Patronymic", c => c.String(maxLength: 50));
            DropColumn("dbo.Students", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Name", c => c.String(maxLength: 50));
            DropColumn("dbo.Students", "Patronymic");
        }
    }
}
