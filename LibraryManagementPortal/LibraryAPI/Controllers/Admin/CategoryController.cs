using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Net.Http;
using System.Net;
using System.Linq;
using LibraryAPI.Filters;
using LibraryAPI.Enums;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [AuthorizeAtrribute(UserRole.Admin)]
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;
        private readonly ResultService _resultService;

        public CategoryController(CategoryService service, ResultService resultService)
        {
            _service = service;
            _resultService = resultService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = _resultService.GetCategoryResult(await _service.GetByIdAsync(id).ConfigureAwait(false), true);

            return Ok(category);
        }

        [HttpGet("")]
        public IActionResult GetCategoryPaginationList(int page = 1, int limit = 10)
        {
            var categories = _service
                .GetPaginatedList(page, limit)
                .Select(c => _resultService.GetCategoryResult(c, true));

            return Ok(categories);
        }

        [HttpPost("")]
        public async Task<HttpResponseMessage> CreateCategory(Category category)
        {
            if (await _service.CreateAsync(category).ConfigureAwait(false))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    ReasonPhrase = $"Added new category with id: {category.Id}"
                };
            }
            else
            {
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
            if (await _service.EditAsync(id, category).ConfigureAwait(false))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Accepted,
                    ReasonPhrase = $"Edited category with id: {id}"
                };
            }
            else
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "New category cannot be created"
                };
            }
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteCategory(Guid id)
        {
            if (await _service.DeleteAsync(id).ConfigureAwait(false))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Accepted,
                    ReasonPhrase = $"Deleted category with id: {id}"
                };
            }
            else
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Category was not deleted"
                };
            }
        }
    }
}