using DataAccess.Database;
using DataAccess.InterfaceRepository;
using DataAccess.Translator;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserSecurityRepository : IUserSecurityRepository
    {
        public int? GetUserOtp(int userId)
        {
            if(UserContext.UserSecurities !=null)
            {
                var userSecurityDbEntity = UserContext.UserSecurities.FirstOrDefault(x => x.UserId == userId);
                if (userSecurityDbEntity == null)
                    return null;
                return userSecurityDbEntity.OneTimePassword;
            }
            return null;
        }

        public int UpdateUserSecurityDetails(UserSecurity userSecurity)
        {
            var userDbSecurity = UserContext.UserSecurities.FirstOrDefault(x => x.UserId == userSecurity.UserId);
            if(userDbSecurity ==null)
            {
                return 0;
            }
            userDbSecurity.OneTimePassword = userSecurity.OneTimePassword;
            userDbSecurity.PasswordExpiredTime = userSecurity.PasswordExpiredTime;
            userDbSecurity.PasswordGenratedTime = userSecurity.PasswordGenratedTime;
            return userDbSecurity.UserId;
        }

        public UserSecurity GetUserSecurity(int userId)
        {
            var userDbSecurity = UserContext.UserSecurities.FirstOrDefault(x => x.UserId == userId);
            if (userDbSecurity == null)
            {
                return null;
            }
            UserSecurityTranslator userSecurityTranslator = new UserSecurityTranslator();
            return userSecurityTranslator.TranslateUserSecurityDbToBusiness(userDbSecurity);

        }
    }
}
