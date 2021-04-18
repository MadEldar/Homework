using System.Collections.Generic;
using System;
using System.Linq;
using LibraryAPI.Enums;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class RequestService
    {
        private readonly RequestRepository _repo;
        public RequestService(RequestRepository repo)
        {
            _repo = repo;
        }

        public IQueryable<RequestModel> GetPaginatedList(int page, int limit)
        {
            return _repo.GetAll()
                .OrderBy(r => r.Status)
                .ThenBy(r => r.RequestedDate)
                .Skip((page - 1) * limit)
                .Take(limit);
        }

        public Task<int> ChangeRequestStatus(Guid id, RequestStatus status)
        {
            if (id == default) throw new KeyNotFoundException(nameof(id));

            var request = _repo
                .GetAll()
                .SingleOrDefault(r => r.Id == id);

            if (request == null) throw new KeyNotFoundException(nameof(id));

            return _repo.ChangeRequestStatusAsync(request, status);
        }
    }
}