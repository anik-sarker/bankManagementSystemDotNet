using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BMS.Inteface;
using BMS.Models;

namespace BMS.Repository
{
    public class UserInfoRepository : Repository<UserInfo>,IUserInfoRepository
    {
        public UserInfoRepository(ApplicationDbContext context) :base(context)
        {
            
        }

        public String getUserRole(int uid, string pass)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            UserInfo ui = db.UserInfos.Where(c => c.UserId == uid && c.UserPasssword == pass).FirstOrDefault();
            if (ui==null)
            {
                return "Sorry,your UserID and Password does not Match";
            }
            else
            {
                return ui.UserRole;
            }
          
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}