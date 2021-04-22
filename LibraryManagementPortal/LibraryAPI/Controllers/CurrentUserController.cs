using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Filters;
using LibraryAPI.Enums;
using System.Collections.Generic;
using System;
using LibraryAPI.Models.Results;

namespace LibraryAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [AuthorizeAtrribute(UserRole.User)]
    public class CurrentUserController : Controller
    {
        private readonly CurrentUserService _service;
        private readonly ResultService _resultService;
        public CurrentUserController(CurrentUserService service, ResultService resultService)
        {
            _service = service;
            _resultService = resultService;
        }

        [HttpGet("")]
        public UserResult GetCurrentUser()
        {
            var user = _service.GetCurrentUser(Request.Headers["AuthToken"]);

            return _resultService.GetUserResult(user, true, false);
        }

        [HttpPost("request-books")]
        public async Task<HttpResponseMessage> CreateNewRequestAsync(List<Guid> bookIds)
        {
            return await _service.CreateNewRequestAsync(Request.Headers["AuthToken"], bookIds).ConfigureAwait(false);
        }

        [HttpGet("requests")]
        public IActionResult GetAllRequests()
        {
            var requests = _service
                .GetAllRequests(Request.Headers["AuthToken"]);

            return Ok(requests.Select(r => _resultService.GetRequestResult(r, true)));
        }
    }
}