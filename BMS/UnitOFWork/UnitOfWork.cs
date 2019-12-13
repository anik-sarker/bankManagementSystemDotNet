using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BMS.Controllers;
using BMS.Inteface;
using BMS.Models;
using BMS.Repository;

namespace BMS.UnitOFWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Branches = new BranchRepository(_context);
            BankBalance = new BankBalanceRepository(_context);
            CusAccountType = new CusAccountTypeRepository(_context);
            Customer = new CustomerRepository(_context);
            CusTransection =new CusTransectionRepository(_context);
            Employee = new EmployeeRepository(_context);
            EmpSalary = new EmpSalaryRepository(_context);
            Login = new LoginRepository(_context);
            Manager = new ManagerRepository(_context);
            MangrTransection = new MangrTransectionRepository(_context);
            ManNoticeBoard = new ManNoticeBoardRepository(_context);
            ManSalary = new ManSalaryRepository(_context);
            Md = new MdRepository(_context);
            UserInfo = new UserInfoRepository(_context);
            UserType = new UserTypeRepository(_context);

            
        }

        public IBankBalanceRepository BankBalance { get; private set; }
        public IBranchRepository Branches { get; private set; }
        public ICusAccountTypeRepository CusAccountType { get; private set; }
        public ICustomerReposotory Customer { get; private set; }
        public ICusTransectionRepository CusTransection { get; private set; }
        public IEmployeeRepository Employee { get; private set; }
        public IEmpSalaryRepository EmpSalary { get; private set; }
        public ILoginRepository Login { get; private set; }
        public IManagerRepository Manager { get; private set; }
        public IMangrTransectionRepository MangrTransection { get; private set; }
        public IManNoticeBoardRepository ManNoticeBoard { get; private set; }
        public IManSalaryRepository ManSalary { get; private set; }
        public IMdRepository Md { get; private set; }
        public IUserInfoRepository UserInfo { get; private set; }
        public IUserTypeRepository UserType { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}