namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useidAded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "UserId");
        }
    }
}
