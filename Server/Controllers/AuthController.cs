using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user.Username == "testuser" && user.Password == "password123")
            {
                return Ok(new { message = "Login successful!" });
            }
            return Unauthorized();
        }
    }
}