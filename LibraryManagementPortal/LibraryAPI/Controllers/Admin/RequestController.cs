using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models.Results;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        private readonly RequestService _service;
        public RequestController(RequestService service)
        {
            _service = service;
        }

        // public List<RequestResult> GetRequestPaginationListAsync(int page = 1, int limit = 10)
        // {
        //     return _service.GetPaginatedListAsync(page, limit);
        // }
    }
}