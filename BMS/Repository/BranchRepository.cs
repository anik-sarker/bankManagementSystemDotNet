using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BMS.Inteface;
using BMS.Models;

namespace BMS.Repository
{
    public class BranchRepository : Repository<Branch>,IBranchRepository
    {
        public BranchRepository(ApplicationDbContext context) :base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
        //top 5 branch
        public IEnumerable<Branch> GetMaxBalanceBranch(int count=5)
        {
            return ApplicationDbContext.Branches.OrderByDescending(c => c.BranchBalance).Take(count).ToList();
        }
    }
}