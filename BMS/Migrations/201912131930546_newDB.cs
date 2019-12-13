namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BranchManagers");
            DropTable("dbo.CheckBooks");
            DropTable("dbo.LoanOfficers");
            DropTable("dbo.Officers");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_acc_no = c.Int(nullable: false, identity: true),
                        User_Name = c.String(),
                        User_password = c.String(),
                        User_address = c.String(),
                        User_mobile = c.String(),
                        User_balance = c.Double(nullable: false),
                        User_acc_type = c.String(),
                        Deadline = c.String(),
                    })
                .PrimaryKey(t => t.User_acc_no);
            
            CreateTable(
                "dbo.Officers",
                c => new
                    {
                        Officer_Id = c.Int(nullable: false, identity: true),
                        Officer_Name = c.String(),
                        Officer_password = c.String(),
                        Officer_address = c.String(),
                        Officer_mobile = c.String(),
                        Officer_Salary = c.Double(nullable: false),
                        Officer_LastPaymentDate = c.String(),
                        Officer_TotalPayment = c.Double(nullable: false),
                        Officer_Balance = c.Double(nullable: false),
                        Officer_branch = c.String(),
                    })
                .PrimaryKey(t => t.Officer_Id);
            
            CreateTable(
                "dbo.LoanOfficers",
                c => new
                    {
                        LOfficer_Id = c.Int(nullable: false, identity: true),
                        LOfficer_name = c.String(),
                        LOfficer_Password = c.String(),
                        LOfficer_address = c.String(),
                        LOfficer_mobile = c.String(),
                        LOfficer_Salary = c.Double(nullable: false),
                        LOfficer_LastPaymentDate = c.String(),
                        LOfficer_TotalPayment = c.Double(nullable: false),
                        LOfficer_Balance = c.Double(nullable: false),
                        LOfficer_branch = c.String(),
                    })
                .PrimaryKey(t => t.LOfficer_Id);
            
            CreateTable(
                "dbo.CheckBooks",
                c => new
                    {
                        Check_id = c.Int(nullable: false, identity: true),
                        Check_User_name = c.String(),
                        Check_apply_Date = c.String(),
                        Check_status = c.String(),
                        Check_fixed_Date = c.String(),
                    })
                .PrimaryKey(t => t.Check_id);
            
            CreateTable(
                "dbo.BranchManagers",
                c => new
                    {
                        Manager_Id = c.Int(nullable: false, identity: true),
                        Manager_Name = c.String(),
                        Manager_password = c.String(),
                        Manager_address = c.String(),
                        Manager_mobile = c.String(),
                        Manager_Salary = c.Double(nullable: false),
                        Manager_Balance = c.Double(nullable: false),
                        Manager_LastPaymentDate = c.String(),
                        Manager_TotalPayment = c.Double(nullable: false),
                        Manager_branch = c.String(),
                    })
                .PrimaryKey(t => t.Manager_Id);
            
        }
    }
}
