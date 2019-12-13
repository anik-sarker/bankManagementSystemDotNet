namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.UserTypes", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserTypes", "Type", c => c.String());
            AlterColumn("dbo.Logins", "Password", c => c.String());
        }
    }
}
