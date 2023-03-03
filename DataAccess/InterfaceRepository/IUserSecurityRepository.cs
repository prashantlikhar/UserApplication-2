using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.InterfaceRepository
{
    public interface IUserSecurityRepository
    {
        public int UpdateUserSecurityDetails(UserSecurity userSecurity);
        public int? GetUserOtp(int userId);
        public UserSecurity GetUserSecurity(int userId);
    }
}
