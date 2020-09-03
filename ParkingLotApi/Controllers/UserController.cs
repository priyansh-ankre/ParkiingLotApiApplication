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
                return NotFound(new Response(HttpStatusCode.NotFound, "List of User is Not Found", userResult));
            }
            catch (System.Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of User cannot be displayed", null));
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
                return NotFound(new Response(HttpStatusCode.NotFound, "List of User is Not Found", userResult));
            }
            catch (System.Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of User cannot be dsplayed", null));
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
