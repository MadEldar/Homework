using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Linq;
using LibraryAPI.Enums;
using LibraryAPI.Filters;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [AuthorizeAtrribute(UserRole.Admin)]
    public class UserManagementController : Controller
    {
        private readonly UserService _service;
        private readonly ResultService _resultService;

        public UserManagementController(UserService service, ResultService resultService)
        {
            _service = service;
            _resultService = resultService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = _resultService.GetUserResult(await _service.GetByIdAsync(id).ConfigureAwait(false), true);

            return Ok(user);
        }

        [HttpGet("")]
        public IActionResult GetUserPaginationList(int page = 1, int limit = 10)
        {
            var users = _service
                .GetPaginatedList(page, limit)
                .Select(u => _resultService.GetUserResult(u, false, false));

            return Ok(users);
        }

        [HttpPost("")]
        public async Task<HttpResponseMessage> CreateUser(User user)
        {
            var operationResult = await _service.CreateAsync(user).ConfigureAwait(false);

            switch (operationResult)
            {
                case OperatingStatus.Created:
                    Request.Headers.Add("UserId", $"{user.Id}");

                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Created,
                        ReasonPhrase = $"Added new user with id: {user.Id}"
                    };
                case OperatingStatus.InvalidArgument:
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = "User id does not exists"
                    };
                case OperatingStatus.EmptyArgument:
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = "All fields must be filled"
                    };
                case OperatingStatus.InternalError:
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        ReasonPhrase = "Something went wrong while saving new user"
                    };
                default:
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = "New user cannot be created"
                    };
            }
        }

        [HttpPut("{id}")]
        public async Task<HttpResponseMessage> EditUser(Guid id, User user)
        {
            var operationResult = await _service.EditAsync(id, user).ConfigureAwait(false);

            return operationResult switch {
                OperatingStatus.Modified => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"Edited user with id: {user.Id}"
                },
                OperatingStatus.KeyNotFound => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "User id does not exists"
                },
                OperatingStatus.EmptyArgument => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "All fields must be filled"
                },
                _ => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "New user cannot be created"
                },
            };
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteUser(Guid id)
        {
            var operationResult = await _service.DeleteAsync(id).ConfigureAwait(false);

            return operationResult switch {
                OperatingStatus.Deleted => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"User with the followinng id was deleted: {id}"
                },
                OperatingStatus.KeyNotFound => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "User id does not exists"
                },
                OperatingStatus.RelationshipExists => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "User contains requests. Delete them before proceding"
                },
                OperatingStatus.InternalError => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "Something went wrong while deleting user"
                },
                _ => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "User cannot be deleted"
                },
            };
        }
    }
}