using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAPI.Migrations
{
    public partial class Adding_User_Token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"), "Fantasy" },
                    { new Guid("ad61fd92-f66f-45ef-909a-92878cd8fe3f"), "Action" },
                    { new Guid("5001db94-553e-4304-b3b7-cede845c0e53"), "Sci-fi" },
                    { new Guid("c1767b01-4814-4abf-9dcf-63dc43ce4c77"), "Romance" },
                    { new Guid("fa2db344-ecaa-4763-94e4-05023ccad649"), "Comedy" },
                    { new Guid("7831d8f7-5db2-4159-98be-d4c4a07b9615"), "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("3a7188a6-268b-4c04-860f-e975de266fe0"), "admin123", 1, "admin" },
                    { new Guid("bf4699a4-129e-4610-8567-d834f3a0981b"), "user123", 0, "love2read" },
                    { new Guid("4384cb37-6891-46ef-b7a7-1d04f3f968bc"), "user456", 0, "novelreader" },
                    { new Guid("e1635a65-b4e6-44b7-8629-4a1bdc8c2308"), "user234", 0, "readingoverrated" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Title" },
                values: new object[,]
                {
                    { new Guid("84c13949-dfed-47ec-b9af-a4e96f1c4d25"), "Erin LaTimer", new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"), "Frost" },
                    { new Guid("687699a7-6ff7-421e-9417-6307300ac142"), "Erin LaTimer", new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"), "Flame" },
                    { new Guid("5ffd8911-431a-4799-9ad9-c07292d29e5b"), "J.K. Rowling", new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"), "Harry Potter and the Philosopher's Stone" },
                    { new Guid("5f94670d-27c6-4025-b22f-b4d6de94316a"), "Neil Gaiman", new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"), "Stardust" },
                    { new Guid("1606c42c-c75d-480a-9b3e-c0dfe1038924"), "Ernest Cline", new Guid("ad61fd92-f66f-45ef-909a-92878cd8fe3f"), "Ready Player One" },
                    { new Guid("392a956a-dca7-4999-a659-1dbb6c83942e"), "Ernest Cline", new Guid("ad61fd92-f66f-45ef-909a-92878cd8fe3f"), "Ready Player Two" },
                    { new Guid("e5ee58d9-376e-4a6e-8afa-a3b61a13f713"), "Orson Scott Card", new Guid("5001db94-553e-4304-b3b7-cede845c0e53"), "Ender's Game" },
                    { new Guid("3546ee96-9ba2-4970-8025-7ef8a565cbc5"), "Jane Austen", new Guid("c1767b01-4814-4abf-9dcf-63dc43ce4c77"), "Pride and Prejudice" },
                    { new Guid("ebc5a247-2ebb-426e-8528-cbfdfd074052"), "Harper Lee", new Guid("7831d8f7-5db2-4159-98be-d4c4a07b9615"), "To Kill A Mockingbird" },
                    { new Guid("38141e8c-e0ae-4c0b-993b-946109ac1f8b"), "William Golding", new Guid("7831d8f7-5db2-4159-98be-d4c4a07b9615"), "Lord of the Flies" },
                    { new Guid("06f5cdb8-2433-4819-b57b-d41f0127e923"), "Marc Cameron", new Guid("7831d8f7-5db2-4159-98be-d4c4a07b9615"), "Tom Clancy's Oath of Office" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "RequestedDate", "Status", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9"), new DateTime(2021, 4, 19, 12, 39, 54, 655, DateTimeKind.Local).AddTicks(8980), 1, null, new Guid("bf4699a4-129e-4610-8567-d834f3a0981b") },
                    { new Guid("49f69fda-c2b9-4654-b0d8-fa7ca269872c"), new DateTime(2021, 4, 19, 12, 39, 54, 659, DateTimeKind.Local).AddTicks(1564), 0, null, new Guid("bf4699a4-129e-4610-8567-d834f3a0981b") },
                    { new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4"), new DateTime(2021, 4, 19, 12, 39, 54, 659, DateTimeKind.Local).AddTicks(1599), 2, null, new Guid("4384cb37-6891-46ef-b7a7-1d04f3f968bc") },
                    { new Guid("581888e2-eab8-40e7-9a25-bc7d36b5198f"), new DateTime(2021, 4, 19, 12, 39, 54, 659, DateTimeKind.Local).AddTicks(1603), 0, null, new Guid("4384cb37-6891-46ef-b7a7-1d04f3f968bc") }
                });

            migrationBuilder.InsertData(
                table: "BookRequests",
                columns: new[] { "BookId", "RequestId" },
                values: new object[,]
                {
                    { new Guid("84c13949-dfed-47ec-b9af-a4e96f1c4d25"), new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9") },
                    { new Guid("687699a7-6ff7-421e-9417-6307300ac142"), new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9") },
                    { new Guid("5ffd8911-431a-4799-9ad9-c07292d29e5b"), new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9") },
                    { new Guid("1606c42c-c75d-480a-9b3e-c0dfe1038924"), new Guid("49f69fda-c2b9-4654-b0d8-fa7ca269872c") },
                    { new Guid("392a956a-dca7-4999-a659-1dbb6c83942e"), new Guid("49f69fda-c2b9-4654-b0d8-fa7ca269872c") },
                    { new Guid("e5ee58d9-376e-4a6e-8afa-a3b61a13f713"), new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4") },
                    { new Guid("3546ee96-9ba2-4970-8025-7ef8a565cbc5"), new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4") },
                    { new Guid("5ffd8911-431a-4799-9ad9-c07292d29e5b"), new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4") },
                    { new Guid("ebc5a247-2ebb-426e-8528-cbfdfd074052"), new Guid("581888e2-eab8-40e7-9a25-bc7d36b5198f") },
                    { new Guid("38141e8c-e0ae-4c0b-993b-946109ac1f8b"), new Guid("581888e2-eab8-40e7-9a25-bc7d36b5198f") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("1606c42c-c75d-480a-9b3e-c0dfe1038924"), new Guid("49f69fda-c2b9-4654-b0d8-fa7ca269872c") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("3546ee96-9ba2-4970-8025-7ef8a565cbc5"), new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("38141e8c-e0ae-4c0b-993b-946109ac1f8b"), new Guid("581888e2-eab8-40e7-9a25-bc7d36b5198f") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("392a956a-dca7-4999-a659-1dbb6c83942e"), new Guid("49f69fda-c2b9-4654-b0d8-fa7ca269872c") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("5ffd8911-431a-4799-9ad9-c07292d29e5b"), new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("5ffd8911-431a-4799-9ad9-c07292d29e5b"), new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("687699a7-6ff7-421e-9417-6307300ac142"), new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("84c13949-dfed-47ec-b9af-a4e96f1c4d25"), new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("e5ee58d9-376e-4a6e-8afa-a3b61a13f713"), new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4") });

            migrationBuilder.DeleteData(
                table: "BookRequests",
                keyColumns: new[] { "BookId", "RequestId" },
                keyValues: new object[] { new Guid("ebc5a247-2ebb-426e-8528-cbfdfd074052"), new Guid("581888e2-eab8-40e7-9a25-bc7d36b5198f") });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("06f5cdb8-2433-4819-b57b-d41f0127e923"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5f94670d-27c6-4025-b22f-b4d6de94316a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fa2db344-ecaa-4763-94e4-05023ccad649"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a7188a6-268b-4c04-860f-e975de266fe0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e1635a65-b4e6-44b7-8629-4a1bdc8c2308"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1606c42c-c75d-480a-9b3e-c0dfe1038924"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3546ee96-9ba2-4970-8025-7ef8a565cbc5"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("38141e8c-e0ae-4c0b-993b-946109ac1f8b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("392a956a-dca7-4999-a659-1dbb6c83942e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5ffd8911-431a-4799-9ad9-c07292d29e5b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("687699a7-6ff7-421e-9417-6307300ac142"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("84c13949-dfed-47ec-b9af-a4e96f1c4d25"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e5ee58d9-376e-4a6e-8afa-a3b61a13f713"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ebc5a247-2ebb-426e-8528-cbfdfd074052"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("49f69fda-c2b9-4654-b0d8-fa7ca269872c"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("581888e2-eab8-40e7-9a25-bc7d36b5198f"));

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5001db94-553e-4304-b3b7-cede845c0e53"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7831d8f7-5db2-4159-98be-d4c4a07b9615"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ad61fd92-f66f-45ef-909a-92878cd8fe3f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1767b01-4814-4abf-9dcf-63dc43ce4c77"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4384cb37-6891-46ef-b7a7-1d04f3f968bc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf4699a4-129e-4610-8567-d834f3a0981b"));

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
    }
}
