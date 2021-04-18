using System.Net.Http;
using System.Linq;
using LibraryAPI.Models;
using System.Net;
using System.Text.Json;

namespace LibraryAPI.Services
{
    public class HomeService
    {
        private readonly LibraryContext _context;
        public HomeService(LibraryContext context)
        {
            _context = context;
        }

        public HttpResponseMessage Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = $"{nameof(username)} or {nameof(password)} cannot be empty"
                };
            }

            var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = $"Incorrect {nameof(username)} or {nameof(password)}"
                };
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                ReasonPhrase = JsonSerializer.Serialize(new {
                    username = user.Username,
                    role = user.Role
                })
            };
        }
    }
}