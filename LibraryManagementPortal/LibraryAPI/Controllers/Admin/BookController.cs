using System.Linq;
using System.Collections.Generic;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly BookService _service;
        public BookController(BookService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookById(Guid id)
        {
            return await _service.GetBookById(id).ConfigureAwait(false);
        }

        [HttpGet("list")]
        public async Task<IEnumerable<Book>> GetBookPaginationList()
        {
            return await _service.GetBookPaginatedList().ConfigureAwait(false);
        }

        [HttpPost("create")]
        public async Task<bool> CreateBook(Book book)
        {
            return await _service.CreateBook(book).ConfigureAwait(false);
        }

        [HttpPut("{id}")]
        public async Task<bool> EditBook(Guid id, Book book)
        {
            return await _service.EditBook(id, book).ConfigureAwait(false);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteBook(Guid id)
        {
            return await _service.DeleteBook(id).ConfigureAwait(false);
        }
    }
}