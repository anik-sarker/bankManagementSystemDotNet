using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Inteface
{
   public interface IUnitOfWork : IDisposable
    {
        IBranchRepository Branches { get; }
        IBankBalanceRepository BankBalance { get; }
        ICusAccountTypeRepository CusAccountType { get; }
        ICusTransectionRepository CusTransection { get; }
        IEmployeeRepository Employee { get; }
        IEmpSalaryRepository EmpSalary { get; }
        ILoginRepository Login { get; }
        IManagerRepository Manager { get; }
        IMangrTransectionRepository MangrTransection { get; }
        IManNoticeBoardRepository ManNoticeBoard { get; }
        IManSalaryRepository ManSalary { get; }
        IMdRepository Md { get; }
        IUserInfoRepository UserInfo { get; }
        IUserTypeRepository UserType { get; }

        int Complete();
    }
}
