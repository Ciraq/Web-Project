namespace Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Surname", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Users", "UserName");
        }
    }
}
