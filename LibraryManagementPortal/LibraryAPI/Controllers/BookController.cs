using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Linq;
using LibraryAPI.Enums;
using LibraryAPI.Filters;
using System.Collections.Generic;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("many")]
        public async Task<IActionResult> GetBooksByIdsAsync()
        {
            var ids = Request.Query["ids"]
                .ToString()
                .Split(",", 5, StringSplitOptions.TrimEntries)
                .Select(id => Guid.Parse(id))
                .ToList();

            var books = (await _service
                .GetManyByIdAsync(ids).ConfigureAwait(false))
                .Select(b => _resultService.GetBookResult(b, false));

            return Ok(books);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetBookPaginationListAsync(int page = 1, int limit = 10)
        {
            var books = _service
                .GetPaginatedList(page <= 0 ? 10 : page, limit <= 0 ? 10 : limit)
                .Select(b => _resultService.GetBookResult(b, false));

            var totalBooks = await _service.GetCount().ConfigureAwait(false);

            return Ok(new {
                books,
                totalBooks,
                page,
                limit
            });
        }
    }
}