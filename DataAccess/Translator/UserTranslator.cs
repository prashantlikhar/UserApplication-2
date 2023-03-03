using DataAccess.DbEntities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Translator
{
    public class UserTranslator
    {
        public User TranslateUserDbToBusiness(UserDbEntity userDbEntity)
        {
            if(userDbEntity ==null)
            {
                return null;
            }
            User user = new User
            {
                Address = userDbEntity.Address,
                UserId = userDbEntity.UserId,
                PhoneNumber = userDbEntity.PhoneNumber,
                UserName = userDbEntity.UserName
            };
            return user;
        }
        public UserDbEntity TranslateUserBusinessToDb(User user)
        {
            if(user ==null)
            {
                return null;
            }
            UserDbEntity userDb = new UserDbEntity
            {
                Address = user.Address,
                UserId = user.UserId,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };
            return userDb;
        }
    }
}
