using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotModelLayer;
using ParkingLotRepositoryLayer;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var userResult = userRepository.GetUsers();
            if(userResult != null)
            {
                return Ok(userResult);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddUserTypeData(UserType userType)
        {
            var userResult = userRepository.AddUserTypeData(userType);
            if (userResult != null)
            {
                return Ok(userResult);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteUserTypeData(int userId)
        {
            var userResult = userRepository.DeleteUserTypeData(userId);
            if (userResult != null)
            {
                return Ok(userResult);
            }
            return BadRequest();
        }
    }
}
