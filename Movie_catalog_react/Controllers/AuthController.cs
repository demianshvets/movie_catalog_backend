using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_catalog_react.Abstract;
using Movie_catalog_react.Concrete;
using Movie_catalog_react.Entities;
using Movie_catalog_react.Helpers;
using Movie_catalog_react.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Movie_catalog_react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        

        public AuthController(IUserRepository repository,JwtService jwtService)
        {
            _userRepository = repository;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterModel model)
        {
            var user = new User()
            { 
                Email=model.Email,
                Password=BCrypt.Net.BCrypt.HashPassword(model.Password)
            };
            return Created("success", _userRepository.Create(user));
        }


        [HttpPost("Login")]
        public IActionResult Login(LoginModel model)
        {
            var user = _userRepository.GetByEmail(model.Email);
            if (user == null) return BadRequest(new { message = "Invalid" });
            if(!BCrypt.Net.BCrypt.Verify(model.Password,user.Password))
            { 
                return BadRequest(new { message = "Invalid" });
            }
            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(new {message="success" });
        }

        [HttpGet("user")]
        public async Task<IActionResult> User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _userRepository.GetById(userId);
                await Authenticate(user.Email);
                return Ok(user);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
        }

        [HttpGet("user1")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _userRepository.GetById(userId);
                await Authenticate(user.Email);
                return Ok(user);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout1()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { 
            message ="success"});
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        [HttpGet("logout2")]
        public async Task<IActionResult> Logout2()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new {
            message="logout2"});
        }

    }
}
