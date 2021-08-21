using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Filters;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [AuthorizeAtrribute(UserRole.Admin)]
    public class RequestManagementController : Controller
    {
        private readonly RequestService _service;
        private readonly ResultService _resultService;
        public RequestManagementController(RequestService service, ResultService resultService)
        {
            _service = service;
            _resultService = resultService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetRequestPaginationListAsync(int page = 1, int limit = 10)
        {
            var requests = _service
                .GetPaginatedList(page, limit)
                .Select(r => _resultService.GetRequestResult(r, true));

            var totalRequests = await _service
                .GetCountAsync()
                .ConfigureAwait(false);

            return Ok(new
            {
                requests,
                totalRequests,
                page,
                limit
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeRequestStatusAsync(Guid id, RequestStatus status)
        {
            var operationResult = await _service
                .ChangeRequestStatus(id, status)
                .ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Modified => Ok($"Edited request with id: {id}"),
                OperatingStatus.KeyNotFound => BadRequest("Request id does not exists"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)

            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestAsync(Guid id)
        {
            var operationResult = await _service.DeleteRequestAsync(id).ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Deleted => Ok($"Request with the followinng id was deleted: {id}"),
                OperatingStatus.KeyNotFound => BadRequest("Request id does not exists"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }
    }
}