using Microsoft.AspNetCore.Mvc;
using ParkingLotModelLayer;
using ParkingLotRepositoryLayer;
using System.Net;

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
            try
            {
                if (userResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of User", userResult));
                }
                return NotFound();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddUserTypeData(UserType userType)
        {
            var userResult = userRepository.AddUserTypeData(userType);
            try
            {
                if (userResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of User", userResult));
                }
                return NotFound();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult DeleteUserTypeData(int userId)
        {
            var userResult = userRepository.DeleteUserTypeData(userId);
            try
            {
                if (userResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of User", userResult));
                }
                return NotFound();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
    }
}
