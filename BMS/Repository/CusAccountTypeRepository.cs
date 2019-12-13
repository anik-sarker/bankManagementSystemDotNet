using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using BMS.Inteface;
using BMS.Models;

namespace BMS.Repository
{
    public class CusAccountTypeRepository :Repository<CusAccountType>,ICusAccountTypeRepository
    {
        public CusAccountTypeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as  ApplicationDbContext;}
        }
    }
}