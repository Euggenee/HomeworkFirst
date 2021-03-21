using BusinessLogicLayer.AuthService;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
      
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Login user)
        {
            bool userIdentification = _authService.UserIdentification(user);

            if (userIdentification == false)
            {
                return BadRequest("Invalid data");
            }
            if (userIdentification)
            {
                return Ok(new { Token = _authService.GetToken() });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("post-user")]
        public void AddNewUser(CheckIn checkIn)
        {
            _authService.AddUser(checkIn);

        }
    }
}
