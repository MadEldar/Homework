using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAPI.Migrations
{
    public partial class Changedstatusandroletoenums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("30962989-6cc8-493f-af07-d98e99eeb772"), "Fantasy" },
                    { new Guid("fe58ee57-2ad7-4208-b969-765c52034e4d"), "Action" },
                    { new Guid("4ae8cd04-36d5-43f1-bb2e-44ccc98b04b0"), "Sci-fi" },
                    { new Guid("9f875e22-4fe7-4d11-a43c-8cd987664bc7"), "Romance" },
                    { new Guid("5ed4d2c8-9f76-4880-b08e-2f6651f0b1e8"), "Comedy" },
                    { new Guid("ff7af3e6-912c-46d0-963a-d3160b3981dc"), "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("0e47eedb-dbfd-4850-8153-8fde088d3c64"), "admin123", 1, "admin" },
                    { new Guid("ab2a7ee6-d65c-4ae4-964a-25b2f9da4638"), "user123", 0, "love2read" },
                    { new Guid("057ff517-113e-47db-bf82-daca85d3c327"), "user456", 0, "novelreader" },
                    { new Guid("bef2efc6-7f39-4790-ae0e-e8a1b51530ea"), "user234", 0, "readingoverrated" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Title" },
                values: new object[,]
                {
                    { new Guid("a7dded3b-d6b9-4c06-8330-1b1933ca1829"), "Erin LaTimer", new Guid("30962989-6cc8-493f-af07-d98e99eeb772"), "Frost" },
                    { new Guid("4aa0eef9-0193-44c7-9fe1-c1b94fc9404a"), "Erin LaTimer", new Guid("30962989-6cc8-493f-af07-d98e99eeb772"), "Flame" },
                    { new Guid("8fbd4703-069e-4270-b629-b52bc3b0c507"), "J.K. Rowling", new Guid("30962989-6cc8-493f-af07-d98e99eeb772"), "Harry Potter and the Philosopher's Stone" },
                    { new Guid("ce5b09ea-5bcc-4169-bb77-51ab8b1eec16"), "Neil Gaiman", new Guid("30962989-6cc8-493f-af07-d98e99eeb772"), "Stardust " },
                    { new Guid("a41edf6f-59f9-4abe-8faf-22589ea87d5b"), "Ernest Cline", new Guid("fe58ee57-2ad7-4208-b969-765c52034e4d"), "Ready Player One" },
                    { new Guid("30432c29-1b74-4086-aed9-e160ecc5ee98"), "Ernest Cline", new Guid("fe58ee57-2ad7-4208-b969-765c52034e4d"), "Ready Player Two" },
                    { new Guid("7f52f5b8-bc1c-4753-8216-101d80f52198"), "Orson Scott Card", new Guid("4ae8cd04-36d5-43f1-bb2e-44ccc98b04b0"), "Ender's Game" },
                    { new Guid("d481bf58-eb10-42d8-808f-53903c442d43"), "Jane Austen", new Guid("9f875e22-4fe7-4d11-a43c-8cd987664bc7"), "Pride and Prejudice" },
                    { new Guid("3c6ed3f9-a22d-472b-9c04-fb3ccdfe7a56"), "Harper Lee", new Guid("ff7af3e6-912c-46d0-963a-d3160b3981dc"), "To Kill A Mockingbird" },
                    { new Guid("9246989e-0878-4744-b954-f7f351d7726f"), "William Golding", new Guid("ff7af3e6-912c-46d0-963a-d3160b3981dc"), "Lord of the Flies" },
                    { new Guid("0e011b4b-f900-4f13-b0c8-a1f6616873b0"), "Marc Cameron", new Guid("ff7af3e6-912c-46d0-963a-d3160b3981dc"), "Tom Clancy's Oath of Office " }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "RequestedDate", "Status", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("c7946198-ad33-439f-88f9-fc9d76a01ac9"), new DateTime(2021, 4, 18, 10, 31, 14, 550, DateTimeKind.Local).AddTicks(3017), 1, null, new Guid("ab2a7ee6-d65c-4ae4-964a-25b2f9da4638") },
                    { new Guid("fcb247ce-ba7d-4f92-a210-19255e156664"), new DateTime(2021, 4, 18, 10, 31, 14, 551, DateTimeKind.Local).AddTicks(9299), 0, null, new Guid("ab2a7ee6-d65c-4ae4-964a-25b2f9da4638") },
                    { new Guid("0f5baf8f-9726-488c-8a32-a60b98f4ac23"), new DateTime(2021, 4, 18, 10, 31, 14, 551, DateTimeKind.Local).AddTicks(9340), 2, null, new Guid("057ff517-113e-47db-bf82-daca85d3c327") },
                    { new Guid("f3531fe5-8e2b-4468-a460-13000da0fef6"), new DateTime(2021, 4, 18, 10, 31, 14, 551, DateTimeKind.Local).AddTicks(9345), 0, null, new Guid("057ff517-113e-47db-bf82-daca85d3c327") }
                });

            migrationBuilder.InsertData(
                table: "BookRequests",
                columns: new[] { "BookId", "RequestId" },
                values: new object[,]
                {
                    { new Guid("a7dded3b-d6b9-4c06-8330-1b1933ca1829"), new Guid("c7946198-ad33-439f-88f9-fc9d76a01ac9") },
                    { new Guid("4aa0eef9-0193-44c7-9fe1-c1b94fc9404a"), new Guid("c7946198-ad33-439f-88f9-fc9d76a01ac9") },
                    { new Guid("8fbd4703-069e-4270-b629-b52bc3b0c507"), new Guid("c7946198-ad33-439f-88f9-fc9d76a01ac9") },
                    { new Guid("a41edf6f-59f9-4abe-8faf-22589ea87d5b"), new Guid("fcb247ce-ba7d-4f92-a210-19255e156664") },
                    { new Guid("30432c29-1b74-4086-aed9-e160ecc5ee98"), new Guid("fcb247ce-ba7d-4f92-a210-19255e156664") },
                    { new Guid("7f52f5b8-bc1c-4753-8216-101d80f52198"), new Guid("0f5baf8f-9726-488c-8a32-a60b98f4ac23") },
                    { new Guid("d481bf58-eb10-42d8-808f-53903c442d43"), new Guid("0f5baf8f-9726-488c-8a32-a60b98f4ac23") },
                    { new Guid("8fbd4703-069e-4270-b629-b52bc3b0c507"), new Guid("0f5baf8f-9726-488c-8a32-a60b98f4ac23") },
                    { new Guid("3c6ed3f9-a22d-472b-9c04-fb3ccdfe7a56"), new Guid("f3531fe5-8e2b-4468-a460-13000da0fef6") },
                    { new Guid("9246989e-0878-4744-b954-f7f351d7726f"), new Guid("f3531fe5-8e2b-4468-a460-13000da0fef6") },
                    { new Guid("0e011b4b-f900-4f13-b0c8-a1f6616873b0"), new Guid("f3531fe5-8e2b-4468-a460-13000da0fef6") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("0e011b4b-f900-4f13-b0c8-a1f6616873b0"), new Guid("f3531fe5-8e2b-4468-a460-13000da0fef6") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("30432c29-1b74-4086-aed9-e160ecc5ee98"), new Guid("fcb247ce-ba7d-4f92-a210-19255e156664") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("3c6ed3f9-a22d-472b-9c04-fb3ccdfe7a56"), new Guid("f3531fe5-8e2b-4468-a460-13000da0fef6") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("4aa0eef9-0193-44c7-9fe1-c1b94fc9404a"), new Guid("c7946198-ad33-439f-88f9-fc9d76a01ac9") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("7f52f5b8-bc1c-4753-8216-101d80f52198"), new Guid("0f5baf8f-9726-488c-8a32-a60b98f4ac23") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("8fbd4703-069e-4270-b629-b52bc3b0c507"), new Guid("0f5baf8f-9726-488c-8a32-a60b98f4ac23") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("8fbd4703-069e-4270-b629-b52bc3b0c507"), new Guid("c7946198-ad33-439f-88f9-fc9d76a01ac9") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("9246989e-0878-4744-b954-f7f351d7726f"), new Guid("f3531fe5-8e2b-4468-a460-13000da0fef6") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("a41edf6f-59f9-4abe-8faf-22589ea87d5b"), new Guid("fcb247ce-ba7d-4f92-a210-19255e156664") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("a7dded3b-d6b9-4c06-8330-1b1933ca1829"), new Guid("c7946198-ad33-439f-88f9-fc9d76a01ac9") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("d481bf58-eb10-42d8-808f-53903c442d43"), new Guid("0f5baf8f-9726-488c-8a32-a60b98f4ac23") });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ce5b09ea-5bcc-4169-bb77-51ab8b1eec16"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5ed4d2c8-9f76-4880-b08e-2f6651f0b1e8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0e47eedb-dbfd-4850-8153-8fde088d3c64"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bef2efc6-7f39-4790-ae0e-e8a1b51530ea"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0e011b4b-f900-4f13-b0c8-a1f6616873b0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("30432c29-1b74-4086-aed9-e160ecc5ee98"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3c6ed3f9-a22d-472b-9c04-fb3ccdfe7a56"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4aa0eef9-0193-44c7-9fe1-c1b94fc9404a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7f52f5b8-bc1c-4753-8216-101d80f52198"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8fbd4703-069e-4270-b629-b52bc3b0c507"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9246989e-0878-4744-b954-f7f351d7726f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a41edf6f-59f9-4abe-8faf-22589ea87d5b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a7dded3b-d6b9-4c06-8330-1b1933ca1829"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d481bf58-eb10-42d8-808f-53903c442d43"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("0f5baf8f-9726-488c-8a32-a60b98f4ac23"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("c7946198-ad33-439f-88f9-fc9d76a01ac9"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("f3531fe5-8e2b-4468-a460-13000da0fef6"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("fcb247ce-ba7d-4f92-a210-19255e156664"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("30962989-6cc8-493f-af07-d98e99eeb772"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4ae8cd04-36d5-43f1-bb2e-44ccc98b04b0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9f875e22-4fe7-4d11-a43c-8cd987664bc7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe58ee57-2ad7-4208-b969-765c52034e4d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ff7af3e6-912c-46d0-963a-d3160b3981dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("057ff517-113e-47db-bf82-daca85d3c327"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ab2a7ee6-d65c-4ae4-964a-25b2f9da4638"));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
