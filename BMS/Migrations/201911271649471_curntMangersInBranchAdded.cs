namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class curntMangersInBranchAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "CurrentManagers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Branches", "CurrentManagers");
        }
    }
}
