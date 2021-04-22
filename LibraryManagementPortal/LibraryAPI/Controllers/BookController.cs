using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Linq;
using LibraryAPI.Enums;
using LibraryAPI.Filters;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [AuthorizeAtrribute(UserRole.User)]
    public class BookController : Controller
    {
        private readonly BookService _service;
        private readonly ResultService _resultService;
        public BookController(BookService service, ResultService resultService)
        {
            _service = service;
            _resultService = resultService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByIdAsync(Guid id)
        {
            var book = _resultService.GetBookResult(await _service.GetByIdAsync(id).ConfigureAwait(false), true);

            return Ok(book);
        }

        [HttpGet("")]
        public IActionResult GetBookPaginationList(int page = 1, int limit = 10)
        {
            var books = _service
                .GetPaginatedList(page, limit)
                .Select(b => _resultService.GetBookResult(b, false));

            return Ok(books);
        }
    }
}