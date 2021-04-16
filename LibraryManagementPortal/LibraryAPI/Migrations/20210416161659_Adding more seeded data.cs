using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAPI.Migrations
{
    public partial class Addingmoreseededdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("29136b79-9a94-476f-885f-fe88cc7d99fa"), new Guid("1cd38e70-92ec-480d-ad6d-3edf3892f580") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("29136b79-9a94-476f-885f-fe88cc7d99fa"), new Guid("e9634a46-c958-4ed9-9ddc-c757e3f33532") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("51738280-4e32-4e8d-8f04-d1bf56f7fcd1"), new Guid("e9634a46-c958-4ed9-9ddc-c757e3f33532") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("584c120e-3f83-4f98-b9e5-0d06d73af08c"), new Guid("8dcdb002-d76a-4a10-bf71-cba54166a96e") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("773a4792-4665-4b36-b3cf-373111ba5073"), new Guid("1cd38e70-92ec-480d-ad6d-3edf3892f580") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("857a6539-7a00-42b7-a617-7cde663f03ed"), new Guid("e9634a46-c958-4ed9-9ddc-c757e3f33532") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("c144a47a-5d59-4469-9e43-cd2e50b21fe5"), new Guid("8dcdb002-d76a-4a10-bf71-cba54166a96e") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("c3a3cb73-a787-417d-b0b3-560762f7cc32"), new Guid("1cd38e70-92ec-480d-ad6d-3edf3892f580") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f49e5494-a209-4cd2-a613-b7d13f2286f0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5e45cdf5-e755-4c93-a0af-f7073e46c190"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("29136b79-9a94-476f-885f-fe88cc7d99fa"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("51738280-4e32-4e8d-8f04-d1bf56f7fcd1"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("584c120e-3f83-4f98-b9e5-0d06d73af08c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("773a4792-4665-4b36-b3cf-373111ba5073"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("857a6539-7a00-42b7-a617-7cde663f03ed"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c144a47a-5d59-4469-9e43-cd2e50b21fe5"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c3a3cb73-a787-417d-b0b3-560762f7cc32"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("1cd38e70-92ec-480d-ad6d-3edf3892f580"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("8dcdb002-d76a-4a10-bf71-cba54166a96e"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("e9634a46-c958-4ed9-9ddc-c757e3f33532"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("575a70c6-4939-4f80-8561-2f6859e95468"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a2941d65-66f0-441b-a8db-305c44a177d1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dee4e232-6150-4cce-b0ee-87994fb7e9c7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e469aa7b-43ec-43e9-a039-aec188d0927b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26fb0253-f681-471d-8915-7cdb8ed431f7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4b8cc646-59cf-4ac9-a206-14cd63f57eee"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Requests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a3c2a4d4-7726-4cd8-a316-a152a2c4864c"), "Fantasy" },
                    { new Guid("b3b2b17d-8dd3-44b2-9463-4e7decf49b23"), "Action" },
                    { new Guid("d79eae75-eaf5-4aa9-851d-e4b075de882f"), "Sci-fi" },
                    { new Guid("579d0bc0-54a5-4532-8d10-9d051982d28d"), "Romance" },
                    { new Guid("8039a8a7-726b-43e6-aa9d-20f1a0963100"), "Comedy" },
                    { new Guid("07be43c2-0a7a-4e4a-90ad-afc023e8e81e"), "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("5e237dfc-18b6-4963-87fe-08a5b6ee166c"), "admin123", "admin", "admin" },
                    { new Guid("a8010d2d-2aac-4178-94a6-eb428e5d0e27"), "user123", "user", "love2read" },
                    { new Guid("97eb40c0-01ec-4e66-9ef2-f83dda656412"), "user456", "user", "novelreader" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Title" },
                values: new object[,]
                {
                    { new Guid("8c282102-8dd2-4240-9499-9e27c0ee726e"), "Erin LaTimer", new Guid("a3c2a4d4-7726-4cd8-a316-a152a2c4864c"), "Frost" },
                    { new Guid("5e6b02de-a70f-4e9d-bb2f-645782b28f4a"), "Erin LaTimer", new Guid("a3c2a4d4-7726-4cd8-a316-a152a2c4864c"), "Flame" },
                    { new Guid("efbc78fc-35da-45ad-afc4-e14ad0933447"), "J.K. Rowling", new Guid("a3c2a4d4-7726-4cd8-a316-a152a2c4864c"), "Harry Potter and the Philosopher's Stone" },
                    { new Guid("3f89d951-93df-4c92-b6e2-42c7f477aea8"), "Neil Gaiman", new Guid("a3c2a4d4-7726-4cd8-a316-a152a2c4864c"), "Stardust " },
                    { new Guid("4c480d2b-d5d7-4247-b4ca-3a8ac84e5b15"), "Ernest Cline", new Guid("b3b2b17d-8dd3-44b2-9463-4e7decf49b23"), "Ready Player One" },
                    { new Guid("96db22b6-5ef2-498d-8afa-2541ebf58243"), "Ernest Cline", new Guid("b3b2b17d-8dd3-44b2-9463-4e7decf49b23"), "Ready Player Two" },
                    { new Guid("2edc5938-b014-42b8-a627-d5463acc58e7"), "Orson Scott Card", new Guid("d79eae75-eaf5-4aa9-851d-e4b075de882f"), "Ender's Game" },
                    { new Guid("6fc59759-ef52-48c1-9701-5a2d3b9526eb"), "Jane Austen", new Guid("579d0bc0-54a5-4532-8d10-9d051982d28d"), "Pride and Prejudice" },
                    { new Guid("1e7ca65b-ea66-4fbd-8d07-fc4633ad2392"), "Harper Lee", new Guid("07be43c2-0a7a-4e4a-90ad-afc023e8e81e"), "To Kill A Mockingbird" },
                    { new Guid("345608c8-fd49-40c3-8b21-2e83b6d5a670"), "William Golding", new Guid("07be43c2-0a7a-4e4a-90ad-afc023e8e81e"), "Lord of the Flies" },
                    { new Guid("129caf7b-d67f-44cf-97d0-f8b167ccfdf4"), "Marc Cameron", new Guid("07be43c2-0a7a-4e4a-90ad-afc023e8e81e"), "Tom Clancy's Oath of Office " }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "RequestedDate", "Status", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("d7a2a0aa-cf5f-4f7c-9b67-1446fd26868b"), new DateTime(2021, 4, 16, 23, 16, 58, 757, DateTimeKind.Local).AddTicks(1800), "Approved", null, new Guid("a8010d2d-2aac-4178-94a6-eb428e5d0e27") },
                    { new Guid("64a15788-0644-4c9b-a229-1e2c47258deb"), new DateTime(2021, 4, 16, 23, 16, 58, 758, DateTimeKind.Local).AddTicks(6574), "Pending", null, new Guid("a8010d2d-2aac-4178-94a6-eb428e5d0e27") },
                    { new Guid("8e350b02-b94d-496a-951e-e4dcdf4281f1"), new DateTime(2021, 4, 16, 23, 16, 58, 758, DateTimeKind.Local).AddTicks(6610), "Rejected", null, new Guid("97eb40c0-01ec-4e66-9ef2-f83dda656412") },
                    { new Guid("e94962e7-fae9-4ac3-b6d9-81fa18528bb3"), new DateTime(2021, 4, 16, 23, 16, 58, 758, DateTimeKind.Local).AddTicks(6614), "Pending", null, new Guid("97eb40c0-01ec-4e66-9ef2-f83dda656412") }
                });

            migrationBuilder.InsertData(
                table: "BookRequests",
                columns: new[] { "BookId", "RequestId" },
                values: new object[,]
                {
                    { new Guid("8c282102-8dd2-4240-9499-9e27c0ee726e"), new Guid("d7a2a0aa-cf5f-4f7c-9b67-1446fd26868b") },
                    { new Guid("5e6b02de-a70f-4e9d-bb2f-645782b28f4a"), new Guid("d7a2a0aa-cf5f-4f7c-9b67-1446fd26868b") },
                    { new Guid("efbc78fc-35da-45ad-afc4-e14ad0933447"), new Guid("d7a2a0aa-cf5f-4f7c-9b67-1446fd26868b") },
                    { new Guid("4c480d2b-d5d7-4247-b4ca-3a8ac84e5b15"), new Guid("64a15788-0644-4c9b-a229-1e2c47258deb") },
                    { new Guid("96db22b6-5ef2-498d-8afa-2541ebf58243"), new Guid("64a15788-0644-4c9b-a229-1e2c47258deb") },
                    { new Guid("2edc5938-b014-42b8-a627-d5463acc58e7"), new Guid("8e350b02-b94d-496a-951e-e4dcdf4281f1") },
                    { new Guid("6fc59759-ef52-48c1-9701-5a2d3b9526eb"), new Guid("8e350b02-b94d-496a-951e-e4dcdf4281f1") },
                    { new Guid("efbc78fc-35da-45ad-afc4-e14ad0933447"), new Guid("8e350b02-b94d-496a-951e-e4dcdf4281f1") },
                    { new Guid("1e7ca65b-ea66-4fbd-8d07-fc4633ad2392"), new Guid("e94962e7-fae9-4ac3-b6d9-81fa18528bb3") },
                    { new Guid("345608c8-fd49-40c3-8b21-2e83b6d5a670"), new Guid("e94962e7-fae9-4ac3-b6d9-81fa18528bb3") },
                    { new Guid("129caf7b-d67f-44cf-97d0-f8b167ccfdf4"), new Guid("e94962e7-fae9-4ac3-b6d9-81fa18528bb3") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("129caf7b-d67f-44cf-97d0-f8b167ccfdf4"), new Guid("e94962e7-fae9-4ac3-b6d9-81fa18528bb3") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("1e7ca65b-ea66-4fbd-8d07-fc4633ad2392"), new Guid("e94962e7-fae9-4ac3-b6d9-81fa18528bb3") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("2edc5938-b014-42b8-a627-d5463acc58e7"), new Guid("8e350b02-b94d-496a-951e-e4dcdf4281f1") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("345608c8-fd49-40c3-8b21-2e83b6d5a670"), new Guid("e94962e7-fae9-4ac3-b6d9-81fa18528bb3") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("4c480d2b-d5d7-4247-b4ca-3a8ac84e5b15"), new Guid("64a15788-0644-4c9b-a229-1e2c47258deb") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("5e6b02de-a70f-4e9d-bb2f-645782b28f4a"), new Guid("d7a2a0aa-cf5f-4f7c-9b67-1446fd26868b") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("6fc59759-ef52-48c1-9701-5a2d3b9526eb"), new Guid("8e350b02-b94d-496a-951e-e4dcdf4281f1") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("8c282102-8dd2-4240-9499-9e27c0ee726e"), new Guid("d7a2a0aa-cf5f-4f7c-9b67-1446fd26868b") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("96db22b6-5ef2-498d-8afa-2541ebf58243"), new Guid("64a15788-0644-4c9b-a229-1e2c47258deb") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("efbc78fc-35da-45ad-afc4-e14ad0933447"), new Guid("8e350b02-b94d-496a-951e-e4dcdf4281f1") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("efbc78fc-35da-45ad-afc4-e14ad0933447"), new Guid("d7a2a0aa-cf5f-4f7c-9b67-1446fd26868b") });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3f89d951-93df-4c92-b6e2-42c7f477aea8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8039a8a7-726b-43e6-aa9d-20f1a0963100"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5e237dfc-18b6-4963-87fe-08a5b6ee166c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("129caf7b-d67f-44cf-97d0-f8b167ccfdf4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1e7ca65b-ea66-4fbd-8d07-fc4633ad2392"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2edc5938-b014-42b8-a627-d5463acc58e7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("345608c8-fd49-40c3-8b21-2e83b6d5a670"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4c480d2b-d5d7-4247-b4ca-3a8ac84e5b15"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5e6b02de-a70f-4e9d-bb2f-645782b28f4a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6fc59759-ef52-48c1-9701-5a2d3b9526eb"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8c282102-8dd2-4240-9499-9e27c0ee726e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("96db22b6-5ef2-498d-8afa-2541ebf58243"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("efbc78fc-35da-45ad-afc4-e14ad0933447"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("64a15788-0644-4c9b-a229-1e2c47258deb"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("8e350b02-b94d-496a-951e-e4dcdf4281f1"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("d7a2a0aa-cf5f-4f7c-9b67-1446fd26868b"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("e94962e7-fae9-4ac3-b6d9-81fa18528bb3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("07be43c2-0a7a-4e4a-90ad-afc023e8e81e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("579d0bc0-54a5-4532-8d10-9d051982d28d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a3c2a4d4-7726-4cd8-a316-a152a2c4864c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b3b2b17d-8dd3-44b2-9463-4e7decf49b23"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d79eae75-eaf5-4aa9-851d-e4b075de882f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97eb40c0-01ec-4e66-9ef2-f83dda656412"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a8010d2d-2aac-4178-94a6-eb428e5d0e27"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
        }
    }
}
