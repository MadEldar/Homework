using System.Net.Http;
using System.Linq;
using System.Collections.Generic;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Net;
using System.Text.Json;

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
        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _service.GetByIdAsync(id).ConfigureAwait(false);
        }

        [HttpGet("")]
        public async Task<List<Book>> GetBookPaginationList(int page = 1, int limit = 10)
        {
            return await _service.GetPaginatedListAsync(page, limit).ConfigureAwait(false);
        }

        [HttpPost("")]
        public async Task<HttpResponseMessage> CreateBook(Book book)
        {
            if (await _service.CreateAsync(book).ConfigureAwait(false))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    ReasonPhrase = $"Added new book with id: {book.Id}",
                    Content = new StringContent(JsonSerializer.Serialize(book))
                };
            }
            else
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "New book cannot be created"
                };
            }
        }

        [HttpPut("{id}")]
        public async Task<HttpResponseMessage> EditBook(Guid id, Book book)
        {
            if (await _service.EditAsync(id, book).ConfigureAwait(false))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Accepted,
                    ReasonPhrase = $"Edited book with id: {id}"
                };
            }
            else
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "New book cannot be created"
                };
            }
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteBook(Guid id)
        {
            if (await _service.DeleteAsync(id).ConfigureAwait(false))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Accepted,
                    ReasonPhrase = $"Deleted book with id: {id}"
                };
            }
            else
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Book was not deleted"
                };
            }
        }
    }
}