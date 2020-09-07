using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ParkingLotModelLayer;
using ParkingLotRepositoryLayer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository userRepository;
        public readonly IConfiguration config;
        public UserController(IUserRepository userRepository, IConfiguration config)
        {
            this.userRepository = userRepository;
            this.config = config;
        }

        private string GenerateToken(IEnumerable<UserLogin> login)
        {

            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(config["Jwt:Issuer"],
                    config["Jwt:Issuer"],
                    expires: DateTime.Now.AddHours(120),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles ="OWNER")]
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
            catch (Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of User cannot be displayed", null));
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route(nameof(UserLogin))]
        public IActionResult UserLogin()
        {
            var userResult = userRepository.UserLogin();
            try
            {
                if (userResult != null)
                {
                    var tokenString = GenerateToken(userResult);
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
            catch (Exception)
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
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
