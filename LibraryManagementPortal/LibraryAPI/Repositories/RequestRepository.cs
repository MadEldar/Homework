using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class RequestRepository : BaseRepository<RequestModel>
    {
        private readonly LibraryContext _context;
        public RequestRepository(LibraryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> ChangeRequestStatusAsync(RequestModel request, RequestStatus status)
        {
            request.Status = status;

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}