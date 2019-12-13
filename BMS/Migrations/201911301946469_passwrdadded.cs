namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwrdadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "Password", c => c.String(nullable: false, maxLength: 18));
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "Password", c => c.String(nullable: false));
        }
    }
}
