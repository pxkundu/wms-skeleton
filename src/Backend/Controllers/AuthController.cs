using Microsoft.AspNetCore.Mvc;
using WMSDemo.Models;
using WMSDemo.Utilities;

namespace WMSDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user.Username == "admin" && user.Password == "password")
            {
                var token = JWTGenerator.GenerateToken(user.Username, user.Role);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
