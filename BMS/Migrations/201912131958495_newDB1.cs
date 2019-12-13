namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmpNoticeBoards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        MesBody = c.String(nullable: false),
                        Seen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmpNoticeBoards");
        }
    }
}
