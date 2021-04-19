using System;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage Login([FromBody] LoginRequest info)
        {
            var user = _service.Login(info.Username, info.Password);

            if (user == null) {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Incorrect username or password"
                };
            }

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                ReasonPhrase = "Login successfully"
            };

            response.Headers.Add("AuthToken", user.Token.Token);

            return response;
        }
    }
}