using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingLotModelLayer;
using ParkingLotBussinessLayer;
using System;
using System.Net;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserBussiness buissenessLayer;
        private readonly MSMQ mSMQ = new MSMQ();
        public UserController(IUserBussiness buissenessLayer )
        {
            this.buissenessLayer = buissenessLayer;
        }

        [HttpGet]
        [Route("GetAllUserDetails")]
        public IActionResult GetUsers()
        {
            var userResult = buissenessLayer.GetUsers();
            try
            {
                if (userResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of User", userResult));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List of User is Not Found", userResult));
            }
            catch (Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of User cannot be displayed", null));
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(UserLogin))]
        public IActionResult UserLogin(UserLogin login)
        {
            var userResult = buissenessLayer.UserLogin(login);
            try
            {
                if (userResult != 0)
                {
                    var tokenString = buissenessLayer.GenerateToken(login);
                    return Ok(new Response(HttpStatusCode.OK, "List of Users Login", tokenString));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List of User Login is Not Found", userResult));
            }
            catch (Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of User Login cannot be displayed", null));
            }
        }

        [HttpPost]
        [Route("UserRegistration")]
        public IActionResult AddUserTypeData([FromBody] UserType userType)
        {
            var userResult = buissenessLayer.AddUserTypeData(userType);
            try
            {
                if (userResult != null)
                {
                    mSMQ.Sender("User with email "+userType.Email+" is registred.");
                    return Ok(new Response(HttpStatusCode.OK, "List of User", userResult));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List of User is Not Found", userResult));
            }
            catch (Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of User cannot be dsplayed", null));
            }
        }

        [HttpDelete]
        [Route("DeleteUserData/{userId:int}")]
        public IActionResult DeleteUserTypeData(int userId)
        {
            var userResult = buissenessLayer.DeleteUserTypeData(userId);
            try
            {
                if (userResult != null)
                {
                    mSMQ.Sender("Information of user is Deleted with userId: "+userId);
                    return Ok(new Response(HttpStatusCode.OK, "List of User", userResult));
                }
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
