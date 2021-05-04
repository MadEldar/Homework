using System.Linq;
using System;
using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class RequestRepository : BaseRepository<RequestModel>
    {
        private readonly LibraryContext _context;
        public RequestRepository(LibraryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OperatingStatus> ChangeRequestStatusAsync(RequestModel request, RequestStatus status)
        {
            request.Status = status;

            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0
                ? OperatingStatus.Modified
                : OperatingStatus.InternalError;
        }

        public Task<OperatingStatus> DeleteRequest(RequestModel request)
        {
            if (request.BookRequests.Count > 0) {
                _context.RemoveRange(request.BookRequests.ToList());
            }

            return DeleteAsync(request);
        }
    }
}