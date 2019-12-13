using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BMS.Inteface;
using BMS.Models;

namespace BMS.Repository
{
    public class MdRepository:Repository<Md>,IMdRepository
    {
        public MdRepository(ApplicationDbContext context) :base(context)
        {
            
        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}