namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mdaded : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT ('Mds', RESEED, 50000)");
        }
        
        public override void Down()
        {
        }
    }
}
