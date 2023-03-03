using DataAccess.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database
{
    public static class UserContext
    {
        public static List<UserDbEntity> Users = new List<UserDbEntity>()
        {
            new UserDbEntity{UserId = 1234, UserName= "Prashant", Address="India", PhoneNumber="1234567890"},
            new UserDbEntity{UserId = 2343, UserName= "Arun", Address="US", PhoneNumber="57648374634"},
            new UserDbEntity{UserId = 3235, UserName= "Swapnil", Address="UK", PhoneNumber="7645378645"},
            new UserDbEntity{UserId = 5674, UserName= "Prashant", Address="EU", PhoneNumber="54874637393"}
        };
        public static List<UserSecurityDbEntity> UserSecurities = new List<UserSecurityDbEntity>()
        {
            new UserSecurityDbEntity{UserId = 1234,OneTimePassword = null,PasswordExpiredTime=null,PasswordGenratedTime=null},
            new UserSecurityDbEntity{UserId = 2343,OneTimePassword = null,PasswordExpiredTime=null,PasswordGenratedTime=null},
            new UserSecurityDbEntity{UserId = 3235,OneTimePassword = null,PasswordExpiredTime=null,PasswordGenratedTime=null},
            new UserSecurityDbEntity{UserId = 5674,OneTimePassword = null,PasswordExpiredTime=null,PasswordGenratedTime=null},
        };
    }
}
