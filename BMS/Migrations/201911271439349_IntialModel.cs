namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankBalances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CurrentEmployees = c.Int(nullable: false),
                        BranchBalance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CusAccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccType = c.String(nullable: false),
                        MaxTransection = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Customers",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        DateOfBirth = c.DateTime(),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                        Gender = c.String(),
                        NID = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Balance = c.Double(nullable: false),
                        AccountTypeId = c.Int(nullable: false),
                        JoinDate = c.String(),
                        Password = c.String(nullable: false, maxLength: 18),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CusAccountTypes", t => t.AccountTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.AccountTypeId);
            Sql("DBCC CHECKIDENT ('Customers', RESEED, 30000)");

            CreateTable(
                "dbo.CusTransections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        BranchId = c.Int(nullable: false),
                        TransDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        DateOfBirth = c.DateTime(),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Address = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        NID = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Salary = c.Double(nullable: false),
                        JoinDate = c.String(),
                        Password = c.String(nullable: false, maxLength: 18),
                        EmpPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            Sql("DBCC CHECKIDENT ('Employees', RESEED, 20000)");

            CreateTable(
                "dbo.EmpSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        SalaryAmn = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        DateOfBirth = c.DateTime(),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Gender = c.String(nullable: false),
                        NID = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Salary = c.Double(nullable: false),
                        JoinDate = c.String(),
                        Password = c.String(nullable: false, maxLength: 18),
                        ManPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            Sql("DBCC CHECKIDENT ('Managers', RESEED, 10000)");

            CreateTable(
                "dbo.MangrTransections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        TransDate = c.String(),
                        Authorized = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ManNoticeBoards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        MesBody = c.String(nullable: false),
                        Seen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ManSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(nullable: false),
                        SalaryAmn = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserPasssword = c.String(),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Managers", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Customers", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Customers", "AccountTypeId", "dbo.CusAccountTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Managers", new[] { "BranchId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.Customers", new[] { "AccountTypeId" });
            DropIndex("dbo.Customers", new[] { "BranchId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ManSalaries");
            DropTable("dbo.ManNoticeBoards");
            DropTable("dbo.MangrTransections");
            DropTable("dbo.Managers");
            DropTable("dbo.EmpSalaries");
            DropTable("dbo.Employees");
            DropTable("dbo.CusTransections");
            DropTable("dbo.Customers");
            DropTable("dbo.CusAccountTypes");
            DropTable("dbo.Branches");
            DropTable("dbo.BankBalances");
        }
    }
}
