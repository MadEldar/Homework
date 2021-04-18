using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Models.Requests;
using LibraryAPI.Models.Results;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class CurrentUserController
    {
        private readonly CurrentUserService _service;
        public CurrentUserController(CurrentUserService service)
        {
            _service = service;
        }

        [HttpPost("request-books")]
        public async Task<HttpResponseMessage> CreateNewRequestAsync(CreateBookRequest req)
        {
            return await _service.CreateNewRequestAsync(req.Username, req.BookIds).ConfigureAwait(false);
        }

        [HttpGet("requests")]
        public async Task<HttpResponseMessage> GetAllRequestsAsync(string username)
        {
            return await _service.GetAllRequestsAsync(username).ConfigureAwait(false);
        }
    }
}