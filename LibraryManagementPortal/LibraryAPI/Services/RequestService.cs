using System.Collections.Generic;
using System;
using System.Linq;
using LibraryAPI.Enums;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using System.Threading.Tasks;
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

        public async Task<int> GetCountAsync()
        {
            return await _repo
                .GetAll()
                .CountAsync()
                .ConfigureAwait(false);
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

        public async Task<RequestModel> GetByIdAsync(Guid id)
        {
            return await _repo
                .GetAll()
                .SingleOrDefaultAsync(r => r.Id == id)
                .ConfigureAwait(false);
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

        public async Task<OperatingStatus> DeleteRequestAsync(Guid id)
        {
            var request = await GetByIdAsync(id).ConfigureAwait(false);

            if (request == null) return OperatingStatus.KeyNotFound;

            return await _repo.DeleteRequest(request).ConfigureAwait(false);
        }
    }
}