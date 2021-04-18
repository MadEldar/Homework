using System.Collections.Generic;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Linq;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _service;
        private readonly ResultService _resultService;

        public UserController(UserService service, ResultService resultService)
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
                .Select(u => _resultService.GetUserResult(u, false));

            return Ok(users);
        }

        [HttpPost("")]
        public async Task<HttpResponseMessage> CreateUser(User user)
        {
            if (await _service.CreateAsync(user).ConfigureAwait(false))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    ReasonPhrase = $"Added new user with id: {user.Id}",
                    Content = new StringContent(JsonSerializer.Serialize(user))
                };
            }
            else
            {
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
            if (await _service.EditAsync(id, user).ConfigureAwait(false))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Accepted,
                    ReasonPhrase = $"Edited user with id: {id}"
                };
            }
            else
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "New user cannot be created"
                };
            }
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteUser(Guid id)
        {
            if (await _service.DeleteAsync(id).ConfigureAwait(false))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Accepted,
                    ReasonPhrase = $"Deleted user with id: {id}"
                };
            }
            else
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "User was not deleted"
                };
            }
        }
    }
}