using DataAccess.InterfaceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [Route("GetUserDetails")]
        public IActionResult GetUserDetails(int userId)
        {
            if(userId == 0)
            {
                return BadRequest("User Id or Date Time value not passed or invalid request parameter value");
            }
            var user = _userRepository.GetUserDetails(userId);
            if(user == null)
            {
                return NotFound(string.Format("User Id {0} details not found", userId));
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
