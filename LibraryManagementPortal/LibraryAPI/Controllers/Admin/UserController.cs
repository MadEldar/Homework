using System.Linq;
using System.Collections.Generic;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Net.Http;
using System.Net;
using System.Text.Json;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<User> GetUserById(Guid id)
        {
            return await _service.GetByIdAsync(id).ConfigureAwait(false);
        }

        [HttpGet("")]
        public async Task<IEnumerable<User>> GetUserPaginationListAsync(int page = 1, int limit = 10)
        {
            return await _service.GetPaginatedListAsync(page, limit).ConfigureAwait(false);
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