using System.Net.Http;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Net;
using LibraryAPI.Enums;
using LibraryAPI.Filters;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [AuthorizeAtrribute(UserRole.Admin)]
    public class BookManagementController : Controller
    {
        private readonly BookService _service;
        public BookManagementController(BookService service)
        {
            _service = service;
        }

        [HttpPost("")]
        public async Task<HttpResponseMessage> CreateBook([FromForm] Book book)
        {
            var operationResult = await _service.CreateAsync(book).ConfigureAwait(false);

            switch (operationResult)
            {
                case OperatingStatus.Created:
                    Request.Headers.Add("BookId", $"{book.Id}");

                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Created,
                        ReasonPhrase = $"Added new book with id: {book.Id}"
                    };
                case OperatingStatus.InvalidArgument:
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = "Book id does not exists"
                    };
                case OperatingStatus.EmptyArgument:
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = "All fields must be filled"
                    };
                case OperatingStatus.InternalError:
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        ReasonPhrase = "Something went wrong while saving new book"
                    };
                default:
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
            var operationResult = await _service.EditAsync(id, book).ConfigureAwait(false);
            return operationResult switch {
                OperatingStatus.Modified => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"Edited book with id: {book.Id}"
                },
                OperatingStatus.KeyNotFound => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Book id does not exists"
                },
                OperatingStatus.EmptyArgument => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "All fields must be filled"
                },
                _ => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "New book cannot be created"
                },
            };
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteBook(Guid id)
        {
            var operationResult = await _service.DeleteAsync(id).ConfigureAwait(false);

            return operationResult switch {
                OperatingStatus.Deleted => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"Book with the followinng id was deleted: {id}"
                },
                OperatingStatus.KeyNotFound => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Book id does not exists"
                },
                OperatingStatus.RelationshipExists => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Book requests exists. Delete them before proceding"
                },
                OperatingStatus.InternalError => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "Something went wrong while deleting book"
                },
                _ => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Book cannot be deleted"
                },
            };
        }
    }
}