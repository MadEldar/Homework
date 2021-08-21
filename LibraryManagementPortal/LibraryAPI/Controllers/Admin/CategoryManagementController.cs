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
    public class CategoryManagementController : Controller
    {
        private readonly CategoryService _service;

        public CategoryManagementController(CategoryService service)
        {
            _service = service;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            var operationResult = await _service.CreateAsync(category).ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Created => Created(Request.PathBase, category),
                OperatingStatus.InvalidArgument => BadRequest("Category id does not exists"),
                OperatingStatus.EmptyArgument => BadRequest("All fields must be filled"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategory(Guid id, Category category)
        {
            var operationResult = await _service.EditAsync(id, category).ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Modified => Ok($"Edited category with id: {category.Id}"),
                OperatingStatus.KeyNotFound => BadRequest("Category id does not exists"),
                OperatingStatus.EmptyArgument => BadRequest("All fields must be filled"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var operationResult = await _service.DeleteAsync(id).ConfigureAwait(false);

            return operationResult switch
            {
                OperatingStatus.Deleted => Ok($"Category with the followinng id was deleted: {id}"),
                OperatingStatus.KeyNotFound => BadRequest("Category id does not exists"),
                OperatingStatus.RelationshipExists => BadRequest("Category contains books. Delete them before proceding"),
                _ => StatusCode((int)HttpStatusCode.InternalServerError)
            };
        }
    }
}