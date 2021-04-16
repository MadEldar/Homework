using System.Linq;
using System.Collections.Generic;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibraryAPI.Services;
using System.Net.Http;
using System.Net;
using System.Text.Json;

namespace LibraryAPI.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public Category GetCategoryById(Guid id)
        {
            return _service.GetById(id);
        }

        [HttpGet("list")]
        public IEnumerable<Category> GetCategoryPaginationList()
        {
            return _service.GetPaginatedList();
        }

        [HttpPost("")]
        public async Task<HttpResponseMessage> CreateCategory(Category category)
        {
            if (await _service.CreateAsync(category).ConfigureAwait(false))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    ReasonPhrase = $"Added new category with id: {category.Id}",
                    Content = new StringContent(JsonSerializer.Serialize(category))
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