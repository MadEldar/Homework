using System;
using LibraryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models
{
    public class LibraryContext : DbContext, IContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<RequestModel> Requests { get; set; }

        public DbSet<BookRequest> BookRequests { get; set; }

        public LibraryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<RequestModel>().Property<DateTime>("CreatedDate");
            // builder.Entity<RequestModel>().Property<DateTime>("UpdatedDate");

            builder.Entity<BookRequest>().HasKey(x => new {x.BookId, x.RequestId});

            var user1 = new User { Id = Guid.NewGuid(), Username = "admin", Password = "admin123", Role = "admin" };
            var user2 = new User { Id = Guid.NewGuid(), Username = "love2read", Password = "user123", Role = "admin" };
            var user3 = new User { Id = Guid.NewGuid(), Username = "novelreader", Password = "user456", Role = "admin" };

            builder.Entity<User>().HasData(
                user1,
                user2,
                user3
            );

            var cate1 = new Category { Id = Guid.NewGuid(), Name = "Fantasy" };
            var cate2 = new Category { Id = Guid.NewGuid(), Name = "Action" };
            var cate3 = new Category { Id = Guid.NewGuid(), Name = "Sci-fi" };
            var cate4 = new Category { Id = Guid.NewGuid(), Name = "Romance" };
            var cate5 = new Category { Id = Guid.NewGuid(), Name = "Comedy" };

            builder.Entity<Category>().HasData(
                cate1,
                cate2,
                cate3,
                cate4,
                cate5
            );

            var book1 = new Book { Id = Guid.NewGuid(), Title = "Frost", Author = "Erin LaTimer", CategoryId = cate1.Id };
            var book2 = new Book { Id = Guid.NewGuid(), Title = "Flame", Author = "Erin LaTimer", CategoryId = cate1.Id };
            var book3 = new Book { Id = Guid.NewGuid(), Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", CategoryId = cate1.Id };
            var book4 = new Book { Id = Guid.NewGuid(), Title = "Ready Player One", Author = "Ernest Cline", CategoryId = cate2.Id };
            var book5 = new Book { Id = Guid.NewGuid(), Title = "Ready Player Two", Author = "Ernest Cline", CategoryId = cate2.Id };
            var book6 = new Book { Id = Guid.NewGuid(), Title = "Ender's Game", Author = "Orson Scott Card", CategoryId = cate3.Id };
            var book7 = new Book { Id = Guid.NewGuid(), Title = "Pride and Prejudice", Author = "Jane Austen", CategoryId = cate4.Id };

            builder.Entity<Book>().HasData(
                book1,
                book2,
                book3,
                book4,
                book5,
                book6,
                book7
            );

            var request1 = new RequestModel { Id = Guid.NewGuid(), Status = "Approved", UserId = user2.Id };
            var request2 = new RequestModel { Id = Guid.NewGuid(), Status = "Pending", UserId = user2.Id };
            var request3 = new RequestModel { Id = Guid.NewGuid(), Status = "Rejected", UserId = user3.Id };

            builder.Entity<RequestModel>().HasData(
                request1,
                request2,
                request3
            );

            builder.Entity<BookRequest>().HasData(
                new BookRequest { RequestId = request1.Id, BookId = book1.Id },
                new BookRequest { RequestId = request1.Id, BookId = book2.Id },
                new BookRequest { RequestId = request1.Id, BookId = book3.Id },
                new BookRequest { RequestId = request2.Id, BookId = book4.Id },
                new BookRequest { RequestId = request2.Id, BookId = book5.Id },
                new BookRequest { RequestId = request3.Id, BookId = book6.Id },
                new BookRequest { RequestId = request3.Id, BookId = book7.Id },
                new BookRequest { RequestId = request3.Id, BookId = book3.Id }
            );
        }
    }
}