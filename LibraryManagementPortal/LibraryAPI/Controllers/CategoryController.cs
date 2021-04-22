using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Linq;
using LibraryAPI.Filters;
using LibraryAPI.Enums;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [AuthorizeAtrribute(UserRole.User)]
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
                .Select(c => _resultService.GetCategoryResult(c, true, false));

            return Ok(categories);
        }
    }
}