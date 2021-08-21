using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Filters;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
            var user = _resultService.GetUserResult(await _service.GetByIdAsync(id).ConfigureAwait(false), true, true);

            return Ok(user);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetUserPaginationListAsync(int page = 1, int limit = 10)
        {
            var users = _service
                .GetPaginatedList(page, limit)
                .Select(u => _resultService.GetUserResult(u, false, false));

            var totalUsers = await _service
                .GetCountAsync()
                .ConfigureAwait(false);

            return Ok(new
            {
                users,
                totalUsers
            });
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateUser(User user)
        {
            var operationResult = await _service.CreateAsync(user).ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Created => Created(Request.Path, user),
                OperatingStatus.InvalidArgument => BadRequest("User id does not exists"),
                OperatingStatus.EmptyArgument => BadRequest("All fields must be filled"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError),
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(Guid id, User user)
        {
            var operationResult = await _service.EditAsync(id, user).ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Modified => Ok($"Edited user with id: {user.Id}"),
                OperatingStatus.KeyNotFound => BadRequest("User id does not exists"),
                OperatingStatus.EmptyArgument => BadRequest("All fields must be filled"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var operationResult = await _service.DeleteAsync(id).ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Deleted => Ok($"User with the followinng id was deleted: {id}"),
                OperatingStatus.KeyNotFound => BadRequest("User id does not exists"),
                OperatingStatus.RelationshipExists => BadRequest("User has books requests. Delete them before proceding"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }
    }
}