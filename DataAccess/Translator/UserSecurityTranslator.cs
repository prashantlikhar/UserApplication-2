using DataAccess.DbEntities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Translator
{
    public class UserSecurityTranslator
    {
        public UserSecurity TranslateUserSecurityDbToBusiness(UserSecurityDbEntity userSecurityDbEntity)
        {
            if (userSecurityDbEntity == null)
            {
                return null;
            }
            UserSecurity userSecurity = new UserSecurity
            {
                UserId = userSecurityDbEntity.UserId,
                OneTimePassword = userSecurityDbEntity.OneTimePassword,
                PasswordGenratedTime = userSecurityDbEntity.PasswordGenratedTime,
                PasswordExpiredTime = userSecurityDbEntity.PasswordExpiredTime
            };
            return userSecurity;
        }
        public UserSecurityDbEntity TranslateUserBusinessToDb(UserSecurity userSecurity)
        {
            if (userSecurity == null)
            {
                return null;
            }
            UserSecurityDbEntity userSecurityDbEntity = new UserSecurityDbEntity
            {
                UserId = userSecurity.UserId,
                OneTimePassword = userSecurity.OneTimePassword,
                PasswordGenratedTime = userSecurity.PasswordGenratedTime,
                PasswordExpiredTime = userSecurity.PasswordExpiredTime
            };
            return userSecurityDbEntity;
        }
    }
}
