using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.Models;

namespace BMS.Inteface
{
    public interface IUserInfoRepository :IRepository<UserInfo>
    {
        string getUserRole(int uid,string pass);
    }
}
