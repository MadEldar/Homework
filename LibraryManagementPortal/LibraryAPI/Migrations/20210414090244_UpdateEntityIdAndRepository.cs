using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAPI.Migrations
{
    public partial class UpdateEntityIdAndRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRequests",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRequests", x => new { x.BookId, x.RequestId });
                    table.ForeignKey(
                        name: "FK_BookRequests_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRequests_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("575a70c6-4939-4f80-8561-2f6859e95468"), "Fantasy" },
                    { new Guid("a2941d65-66f0-441b-a8db-305c44a177d1"), "Action" },
                    { new Guid("e469aa7b-43ec-43e9-a039-aec188d0927b"), "Sci-fi" },
                    { new Guid("dee4e232-6150-4cce-b0ee-87994fb7e9c7"), "Romance" },
                    { new Guid("f49e5494-a209-4cd2-a613-b7d13f2286f0"), "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("5e45cdf5-e755-4c93-a0af-f7073e46c190"), "admin123", "admin", "admin" },
                    { new Guid("4b8cc646-59cf-4ac9-a206-14cd63f57eee"), "user123", "admin", "love2read" },
                    { new Guid("26fb0253-f681-471d-8915-7cdb8ed431f7"), "user456", "admin", "novelreader" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Title" },
                values: new object[,]
                {
                    { new Guid("c3a3cb73-a787-417d-b0b3-560762f7cc32"), "Erin LaTimer", new Guid("575a70c6-4939-4f80-8561-2f6859e95468"), "Frost" },
                    { new Guid("773a4792-4665-4b36-b3cf-373111ba5073"), "Erin LaTimer", new Guid("575a70c6-4939-4f80-8561-2f6859e95468"), "Flame" },
                    { new Guid("29136b79-9a94-476f-885f-fe88cc7d99fa"), "J.K. Rowling", new Guid("575a70c6-4939-4f80-8561-2f6859e95468"), "Harry Potter and the Philosopher's Stone" },
                    { new Guid("c144a47a-5d59-4469-9e43-cd2e50b21fe5"), "Ernest Cline", new Guid("a2941d65-66f0-441b-a8db-305c44a177d1"), "Ready Player One" },
                    { new Guid("584c120e-3f83-4f98-b9e5-0d06d73af08c"), "Ernest Cline", new Guid("a2941d65-66f0-441b-a8db-305c44a177d1"), "Ready Player Two" },
                    { new Guid("857a6539-7a00-42b7-a617-7cde663f03ed"), "Orson Scott Card", new Guid("e469aa7b-43ec-43e9-a039-aec188d0927b"), "Ender's Game" },
                    { new Guid("51738280-4e32-4e8d-8f04-d1bf56f7fcd1"), "Jane Austen", new Guid("dee4e232-6150-4cce-b0ee-87994fb7e9c7"), "Pride and Prejudice" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "RequestedDate", "Status", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("1cd38e70-92ec-480d-ad6d-3edf3892f580"), new DateTime(2021, 4, 14, 16, 2, 42, 820, DateTimeKind.Local).AddTicks(9142), "Approved", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b8cc646-59cf-4ac9-a206-14cd63f57eee") },
                    { new Guid("8dcdb002-d76a-4a10-bf71-cba54166a96e"), new DateTime(2021, 4, 14, 16, 2, 42, 822, DateTimeKind.Local).AddTicks(8530), "Pending", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b8cc646-59cf-4ac9-a206-14cd63f57eee") },
                    { new Guid("e9634a46-c958-4ed9-9ddc-c757e3f33532"), new DateTime(2021, 4, 14, 16, 2, 42, 822, DateTimeKind.Local).AddTicks(8718), "Rejected", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("26fb0253-f681-471d-8915-7cdb8ed431f7") }
                });

            migrationBuilder.InsertData(
                table: "BookRequests",
                columns: new[] { "BookId", "RequestId" },
                values: new object[,]
                {
                    { new Guid("c3a3cb73-a787-417d-b0b3-560762f7cc32"), new Guid("1cd38e70-92ec-480d-ad6d-3edf3892f580") },
                    { new Guid("773a4792-4665-4b36-b3cf-373111ba5073"), new Guid("1cd38e70-92ec-480d-ad6d-3edf3892f580") },
                    { new Guid("29136b79-9a94-476f-885f-fe88cc7d99fa"), new Guid("1cd38e70-92ec-480d-ad6d-3edf3892f580") },
                    { new Guid("c144a47a-5d59-4469-9e43-cd2e50b21fe5"), new Guid("8dcdb002-d76a-4a10-bf71-cba54166a96e") },
                    { new Guid("584c120e-3f83-4f98-b9e5-0d06d73af08c"), new Guid("8dcdb002-d76a-4a10-bf71-cba54166a96e") },
                    { new Guid("857a6539-7a00-42b7-a617-7cde663f03ed"), new Guid("e9634a46-c958-4ed9-9ddc-c757e3f33532") },
                    { new Guid("51738280-4e32-4e8d-8f04-d1bf56f7fcd1"), new Guid("e9634a46-c958-4ed9-9ddc-c757e3f33532") },
                    { new Guid("29136b79-9a94-476f-885f-fe88cc7d99fa"), new Guid("e9634a46-c958-4ed9-9ddc-c757e3f33532") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_RequestId",
                table: "BookRequests",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequests");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
