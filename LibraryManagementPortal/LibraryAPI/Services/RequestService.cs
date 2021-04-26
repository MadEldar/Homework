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
            return _repo
                .GetAll()
                .OrderBy(r => r.Status)
                .ThenBy(r => r.RequestedDate)
                .Skip((page - 1) * limit)
                .Take(limit);
        }

        public async Task<OperatingStatus> ChangeRequestStatus(Guid id, RequestStatus status)
        {
            if (id == default) return OperatingStatus.KeyNotFound;

            var request = _repo
                .GetAll()
                .SingleOrDefault(r => r.Id == id);

            if (request == null) return OperatingStatus.KeyNotFound;

            return await _repo
                .ChangeRequestStatusAsync(request, status)
                .ConfigureAwait(false);
        }
    }
}