using System.Net.Http;
using System.Collections.Generic;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Net;
using System.Text.Json;
using System.Linq;
using LibraryAPI.Models.Results;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/book")]
    [ApiController]
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
        public async Task<HttpResponseMessage> GetBookByIdAsync(Guid id)
        {
            var book = _resultService.GetBookResult(await _service.GetByIdAsync(id).ConfigureAwait(false), true);

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                ReasonPhrase = JsonSerializer.Serialize(book)
            };
        }

        [HttpGet("")]
        public HttpResponseMessage GetBookPaginationList(int page = 1, int limit = 10)
        {
            var books = _service
                .GetPaginatedList(page, limit)
                .Select(b => _resultService.GetBookResult(b, false));

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                ReasonPhrase = JsonSerializer.Serialize(books)
            };
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