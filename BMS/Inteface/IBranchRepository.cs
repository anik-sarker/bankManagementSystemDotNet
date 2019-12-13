using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.Models;

namespace BMS.Inteface
{
  public interface IBranchRepository : IRepository<Branch>
  {
      IEnumerable<Branch> GetMaxBalanceBranch(int count);
  }
}
