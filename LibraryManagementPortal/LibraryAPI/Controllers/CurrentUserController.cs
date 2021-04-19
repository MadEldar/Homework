using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LibraryAPI.Models.Requests;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Filters;
using LibraryAPI.Enums;
using System.Collections.Generic;
using System;

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

            if(requests == null) return null;
            return Ok(requests.Select(r => _resultService.GetRequestResult(r, true)));
        }
    }
}