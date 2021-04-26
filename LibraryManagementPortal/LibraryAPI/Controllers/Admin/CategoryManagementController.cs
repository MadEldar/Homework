using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Net.Http;
using System.Net;
using LibraryAPI.Filters;
using LibraryAPI.Enums;
using System.Linq;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [AuthorizeAtrribute(UserRole.Admin)]
    public class CategoryManagementController : Controller
    {
        private readonly CategoryService _service;
        private readonly ResultService _resultService;

        public CategoryManagementController(CategoryService service, ResultService resultService)
        {
            _service = service;
            _resultService = resultService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            var categories = _service
                .GetPaginatedList(1, await _service.GetCountAsync().ConfigureAwait(false))
                .Select(c =>
                    _resultService.GetCategoryResult(
                        c,
                        false,
                        false
                    )
                );

            return Ok(categories);
        }

        [HttpPost("")]
        public async Task<HttpResponseMessage> CreateCategory(Category category)
        {
            var operationResult = await _service.CreateAsync(category).ConfigureAwait(false);

            switch (operationResult)
            {
                case OperatingStatus.Created:
                    Request.Headers.Add("CategoryId", $"{category.Id}");

                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Created,
                        ReasonPhrase = $"Added new category with id: {category.Id}"
                    };
                case OperatingStatus.InvalidArgument:
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = "Category id does not exists"
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
                        ReasonPhrase = "Something went wrong while saving new category"
                    };
                default:
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = "New category cannot be created"
                    };
            }
        }

        [HttpPut("{id}")]
        public async Task<HttpResponseMessage> EditCategory(Guid id, Category category)
        {
            var operationResult = await _service.EditAsync(id, category).ConfigureAwait(false);

            return operationResult switch {
                OperatingStatus.Modified => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"Edited category with id: {category.Id}"
                },
                OperatingStatus.KeyNotFound => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Category id does not exists"
                },
                OperatingStatus.EmptyArgument => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "All fields must be filled"
                },
                _ => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "New category cannot be created"
                },
            };
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteCategory(Guid id)
        {
            var operationResult = await _service.DeleteAsync(id).ConfigureAwait(false);

            return operationResult switch {
                OperatingStatus.Deleted => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"Category with the followinng id was deleted: {id}"
                },
                OperatingStatus.KeyNotFound => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Category id does not exists"
                },
                OperatingStatus.RelationshipExists => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Category contains books. Delete them before proceding"
                },
                OperatingStatus.InternalError => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "Something went wrong while deleting category"
                },
                _ => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Category cannot be deleted"
                },
            };
        }
    }
}