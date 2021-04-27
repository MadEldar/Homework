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
using System.Net;

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
            if (bookIds.Count == 0)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Select at least 1 book to request"
                };
            }

            var operationResult = await _service
                .CreateNewRequestAsync(Request.Headers["AuthToken"], bookIds)
                .ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Created => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    ReasonPhrase = $"Successfully requested {bookIds.Count} books"
                },
                OperatingStatus.ExceedMonthlyRequestLimit => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "You have already reached this month's request limit"
                },
                OperatingStatus.ExceedMonthlyBookLimit => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    ReasonPhrase = "You have already reached this month's book limit"
                },
                OperatingStatus.ExceedRemainingMonthlyRequestLimit => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    ReasonPhrase = "Total books requested exeeds this month's book limit"
                },
                _ => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Request was not properly processed"
                },
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