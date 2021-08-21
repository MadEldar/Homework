using LibraryAPI.Enums;
using LibraryAPI.Models.Requests;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly HomeService _service;
        public HomeController(HomeService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] LoginRequest info)
        {
            var user = _service.Login(info.Username, info.Password);

            if (user == null)
            {
                return BadRequest("Incorrect username or password");
            }

            Response.Headers.Add("AuthToken", user.Token.Token);

            if (user.Role == UserRole.Admin)
            {
                Response.Headers.Add("Admin", "");
            }

            return Ok("Login successfully");
        }
    }
}