namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbRelationFixed : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CusTransections", "BranchId");
            CreateIndex("dbo.EmpSalaries", "EmployeeId");
            CreateIndex("dbo.MangrTransections", "BranchId");
            CreateIndex("dbo.ManSalaries", "ManagerId");
            AddForeignKey("dbo.CusTransections", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmpSalaries", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MangrTransections", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ManSalaries", "ManagerId", "dbo.Managers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManSalaries", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.MangrTransections", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.EmpSalaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CusTransections", "BranchId", "dbo.Branches");
            DropIndex("dbo.ManSalaries", new[] { "ManagerId" });
            DropIndex("dbo.MangrTransections", new[] { "BranchId" });
            DropIndex("dbo.EmpSalaries", new[] { "EmployeeId" });
            DropIndex("dbo.CusTransections", new[] { "BranchId" });
        }
    }
}
