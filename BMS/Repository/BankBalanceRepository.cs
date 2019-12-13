using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BMS.Inteface;
using BMS.Models;

namespace BMS.Repository
{
    public class BankBalanceRepository: Repository<BankBalance>,IBankBalanceRepository
    {
        public BankBalanceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext;}
        }

    }
}