using System.Net.Http;
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
        public HttpResponseMessage Login([FromBody] LoginInfo info)
        {
            return _service.Login(info.Username, info.Password);
        }
    }

    public class LoginInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}