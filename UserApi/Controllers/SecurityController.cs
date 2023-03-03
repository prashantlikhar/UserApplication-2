using DataAccess.InterfaceRepository;
using Entities;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSecurityRepository _userSecurityRepository;
        public SecurityController(IUserRepository userRepository,IUserSecurityRepository userSecurityRepository)
        {
            _userRepository = userRepository;
            _userSecurityRepository = userSecurityRepository;
        }
        [HttpGet]
        [Route("GetOneTimePassword")]
        public IActionResult GetOneTimePassword(int userId,string dateTime)
        {
            if(userId == 0 || string.IsNullOrEmpty(dateTime))
            {
                return BadRequest("User Id or Date Time value not passed");                
            }
            var user = _userRepository.GetUserDetails(userId);
            if(user == null)
            {
                return NotFound(string.Format("User Id {0} details not found",userId));
            }
            DateTime utcDateIn = DateTime.ParseExact(dateTime, "s", CultureInfo.InvariantCulture);
            var otp = SecurityHelper.GenrateOneTimePassword(userId, utcDateIn);
            UserSecurity userSecurity = new UserSecurity();
            userSecurity.UserId = userId;
            userSecurity.OneTimePassword = otp;
            userSecurity.PasswordGenratedTime = utcDateIn;
            userSecurity.PasswordExpiredTime = utcDateIn.AddSeconds(Constant.ExpirationTimeInSecond);
            _userSecurityRepository.UpdateUserSecurityDetails(userSecurity);
            return Ok(otp);
        }
        [HttpPost]
        public IActionResult UpdateUserSecurityDetails(UserSecurity userSecurity)
        {
            int id = _userSecurityRepository.UpdateUserSecurityDetails(userSecurity);
            if (id == 0)
            {
                return NotFound(string.Format("User Id {0} details not found", userSecurity.UserId));
            }
            return Ok(id);

        }
        [HttpGet]
        [Route("IsOtpAlreadyGenrated")]
        public IActionResult IsOtpAlreadyGenrated(int userId)
        {
            if (userId == 0 )
            {
                return BadRequest("User Id or Date Time value not passed");
            }
            var user = _userSecurityRepository.GetUserSecurity(userId);
            
            if (user == null)
            {
                return NotFound(string.Format("User Id {0} details not found", userId));
            }
            var otp = user.OneTimePassword ?? 0;
            if (otp == 0)
                return Ok(false);
            else if (DateTime.Compare(user.PasswordExpiredTime ?? DateTime.UtcNow, DateTime.UtcNow) <= 0)
            {
                return Ok(false);
            }
            return  Ok(true);

        }
    }
}
