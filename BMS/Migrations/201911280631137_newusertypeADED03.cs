namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newusertypeADED03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewUserRegs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewUserRegs", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.NewUserRegs", new[] { "UserTypeId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.NewUserRegs");
            DropTable("dbo.Logins");
        }
    }
}
