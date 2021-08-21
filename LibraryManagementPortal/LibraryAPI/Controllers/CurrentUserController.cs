using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Filters;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetCurrentUser()
        {
            var user = _service.GetCurrentUser(Request.Headers["AuthToken"]);

            return Ok(_resultService.GetUserResult(user, true, false));
        }

        [HttpPost("request-books")]
        public async Task<IActionResult> CreateNewRequestAsync(List<Guid> bookIds)
        {
            if (bookIds.Count == 0)
            {
                return BadRequest("Select at least 1 book to request");
            }

            var operationResult = await _service
                .CreateNewRequestAsync(Request.Headers["AuthToken"], bookIds)
                .ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Created => Created(Request.Path, bookIds),
                OperatingStatus.ExceedMonthlyRequestLimit => BadRequest("You have already reached this month's request limit"),
                OperatingStatus.ExceedMonthlyBookLimit => BadRequest("You have already reached this month's book limit"),
                OperatingStatus.ExceedRemainingMonthlyRequestLimit => BadRequest("Total books requested exeeds this month's book limit"),
                _ => BadRequest("Request was not properly processed"),
            };
        }

        [HttpGet("requests")]
        public IActionResult GetAllRequests()
        {
            var requests = _service
                .GetAllRequests(Request.Headers["AuthToken"])
                .Select(r => _resultService.GetRequestResult(r, true));

            return Ok(requests);
        }
    }
}