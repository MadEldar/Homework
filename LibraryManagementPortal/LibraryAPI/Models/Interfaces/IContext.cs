using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Interfaces
{
    public interface IContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<RequestModel> Requests { get; set; }
    }
}