using System;
using System.Net;
using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Filters;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            var operationResult = await _service.CreateAsync(book).ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Created => Created(Request.Path, book),
                OperatingStatus.InvalidArgument => BadRequest("Book id does not exists"),
                OperatingStatus.EmptyArgument => BadRequest("All fields must be filled"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook(Guid id, Book book)
        {
            var operationResult = await _service.EditAsync(id, book).ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Modified => Ok($"Edited book with id: {book.Id}"),
                OperatingStatus.KeyNotFound => BadRequest("Book id does not exists"),
                OperatingStatus.EmptyArgument => BadRequest("All fields must be filled"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var operationResult = await _service.DeleteAsync(id).ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Deleted => Ok($"Book with the followinng id was deleted: {id}"),
                OperatingStatus.KeyNotFound => BadRequest("Book id does not exists"),
                OperatingStatus.RelationshipExists => BadRequest("Book requests exists. Delete them before proceding"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }
    }
}