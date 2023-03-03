
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
    public class UserRepository : IUserRepository
    {
        public User GetUserDetails(int userId)
        {
            if(UserContext.Users !=null)
            {
                var userDbEntity = UserContext.Users.FirstOrDefault(x => x.UserId == userId);
                if(userDbEntity == null)
                {
                    return null;
                }
                UserTranslator userTranslator = new UserTranslator();
                return userTranslator.TranslateUserDbToBusiness(userDbEntity);
            }
            return null;
        }
    }
}
