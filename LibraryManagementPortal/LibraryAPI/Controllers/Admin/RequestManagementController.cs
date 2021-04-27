using System.Net.Http;
using System;
using System.Linq;
using LibraryAPI.Models.Results;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using LibraryAPI.Enums;
using System.Threading.Tasks;
using LibraryAPI.Filters;

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

        [HttpGet("")]
        public IQueryable<RequestResult> GetRequestPaginationList(int page = 1, int limit = 10)
        {
            return _service
                .GetPaginatedList(page, limit)
                .Select(r => _resultService.GetRequestResult(r, true));
        }

        [HttpPost("{id}")]
        public async Task<HttpResponseMessage> ChangeRequestStatusAsync(Guid id, RequestStatus status)
        {
            var operationResult = await _service
                .ChangeRequestStatus(id, status)
                .ConfigureAwait(false);

            return operationResult switch {
                OperatingStatus.Modified => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"Request with the followinng id was changed: {id}"
                },
                OperatingStatus.KeyNotFound => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Request id does not exists"
                },
                OperatingStatus.InternalError => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "Something went wrong while changing request status"
                },
                _ => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Category cannot be deleted"
                },
            };
        }
    }
}