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
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                ReasonPhrase = $"Added new category with id: {category.Id}"
            };
        }

        [HttpPut("{id}")]
        public async Task<HttpResponseMessage> EditCategory(Guid id, Category category)
        {
            var operationResult = await _service.EditAsync(id, category).ConfigureAwait(false);
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Accepted,
                ReasonPhrase = $"Edited category with id: {id}"
            };
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteCategory(Guid id)
        {
            var operationResult = await _service.DeleteAsync(id).ConfigureAwait(false);
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Accepted,
                ReasonPhrase = $"Deleted category with id: {id}"
            };
        }
    }
}