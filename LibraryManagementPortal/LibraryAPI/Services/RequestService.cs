using System;
using System.Collections.Generic;
using System.Linq;
using LibraryAPI.Models.Results;
using LibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class RequestService
    {
        private readonly RequestRepository _repo;
        public RequestService(RequestRepository repo)
        {
            _repo = repo;
        }

        // public List<RequestResult> GetPaginatedListAsync(int page, int limit)
        // {
        //     // return _repo.GetAll();
        // }
    }
}