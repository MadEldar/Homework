using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LibraryAPI.Enums;
using LibraryAPI.Models;
using LibraryAPI.Models.Requests;
using LibraryAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LibraryAPI.Controllers.Test
{
    public class CurrentUserControllerTest
    {
        private CurrentUserService testService;
        private ResultService resultService;
        private CurrentUserController controller;
        private static Guid bookId1 = Guid.NewGuid();
        private static Guid bookId2 = Guid.NewGuid();
        private static Guid bookId3 = Guid.NewGuid();
        private static Guid bookId4 = Guid.NewGuid();
        private static Guid bookId5 = Guid.NewGuid();
        private static Guid bookId6 = Guid.NewGuid();
        private static IEnumerable<TestCaseData> GetCorrectCreateBookRequests()
        {
            yield return new TestCaseData(new CreateBookRequest { Username = "love2read", BookIds = new List<Guid> { bookId1, bookId2 } }, HttpStatusCode.Created);
            yield return new TestCaseData(new CreateBookRequest { Username = "novelreader", BookIds = new List<Guid> { bookId2, bookId3 } }, HttpStatusCode.Created);
            yield return new TestCaseData(new CreateBookRequest { Username = "readingoverrated", BookIds = new List<Guid> { bookId1, bookId2, bookId3, bookId4, bookId5 } }, HttpStatusCode.Created);
            yield return new TestCaseData(new CreateBookRequest { Username = "love2read", BookIds = new List<Guid> { bookId2, bookId3, bookId4 } }, HttpStatusCode.Created);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            ServiceCollection services = new();

            services.AddDbContext<LibraryContext>(
                // using package Microsoft.EntityFrameworkCore.InMemory
                opt => opt.UseInMemoryDatabase(databaseName: "LibraryAPI"),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped
            );

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            testService = serviceProvider.GetService<CurrentUserService>();
            resultService = serviceProvider.GetService<ResultService>();
            var context = serviceProvider.GetService<LibraryContext>();

            // Create in-memory data
            var user1 = new User { Id = Guid.NewGuid(), Username = "love2read", Password = "user123", Role = UserRole.User };
            var user2 = new User { Id = Guid.NewGuid(), Username = "novelreader", Password = "user456", Role = UserRole.User };
            var user3 = new User { Id = Guid.NewGuid(), Username = "readingoverrated", Password = "user234", Role = UserRole.User };
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);

            var cate1 = new Category { Id = Guid.NewGuid(), Name = "Fantasy" };
            var cate2 = new Category { Id = Guid.NewGuid(), Name = "Action" };
            var cate3 = new Category { Id = Guid.NewGuid(), Name = "Sci-fi" };
            context.Categories.Add(cate1);
            context.Categories.Add(cate2);
            context.Categories.Add(cate3);

            var book1 = new Book { Id = bookId1, Title = "Frost", Author = "Erin LaTimer", CategoryId = cate1.Id };
            var book2 = new Book { Id = bookId2, Title = "Flame", Author = "Erin LaTimer", CategoryId = cate1.Id };
            var book3 = new Book { Id = bookId3, Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", CategoryId = cate1.Id };
            var book4 = new Book { Id = bookId4, Title = "Ready Player One", Author = "Ernest Cline", CategoryId = cate2.Id };
            var book5 = new Book { Id = bookId5, Title = "Ready Player Two", Author = "Ernest Cline", CategoryId = cate2.Id };
            var book6 = new Book { Id = bookId6, Title = "Ender's Game", Author = "Orson Scott Card", CategoryId = cate3.Id };
            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            context.Books.Add(book4);
            context.Books.Add(book5);
            context.Books.Add(book6);

            controller = new CurrentUserController(testService, resultService);
        }

        // [Order(1)]
        // [TestCaseSource(nameof(GetCorrectCreateBookRequests))]
        // public async Task CreateNewRequest_UniqueBookIdAndWithinLimit_ShouldPassAsync(CreateBookRequest req, HttpStatusCode statusCode)
        // {
        //     HttpResponseMessage result = await controller.CreateNewRequestAsync(req).ConfigureAwait(false);

        //     Assert.AreEqual(statusCode, result.StatusCode, "Book request was not created");
        // }
    }
}