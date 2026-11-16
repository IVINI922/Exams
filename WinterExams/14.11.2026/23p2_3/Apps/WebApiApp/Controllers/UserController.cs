using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Services;

namespace WebApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("login")]
        public IActionResult Login(string login, string password)
        {
            string? response = UserService.Login(login, password);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Неверный логин или пароль");
            }
        }
    }
}