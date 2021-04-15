using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public class RequestRepository : BaseRepository<RequestModel>
    {
        public RequestRepository(LibraryContext context) : base(context) { }
    }
}