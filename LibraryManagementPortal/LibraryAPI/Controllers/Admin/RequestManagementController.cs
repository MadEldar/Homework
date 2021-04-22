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
            int result = await _service
                .ChangeRequestStatus(id, status)
                .ConfigureAwait(false);

            if (result == 1)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"Changed request status to {Enum.GetName(typeof(RequestStatus), status)}"
                };
            }
            else
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = $"1 row was expected to changed, but instead {result}"
                };
            }
        }
    }
}