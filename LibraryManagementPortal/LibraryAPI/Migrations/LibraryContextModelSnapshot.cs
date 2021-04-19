﻿// <auto-generated />
using System;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryAPI.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("84c13949-dfed-47ec-b9af-a4e96f1c4d25"),
                            Author = "Erin LaTimer",
                            CategoryId = new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"),
                            Title = "Frost"
                        },
                        new
                        {
                            Id = new Guid("687699a7-6ff7-421e-9417-6307300ac142"),
                            Author = "Erin LaTimer",
                            CategoryId = new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"),
                            Title = "Flame"
                        },
                        new
                        {
                            Id = new Guid("5ffd8911-431a-4799-9ad9-c07292d29e5b"),
                            Author = "J.K. Rowling",
                            CategoryId = new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"),
                            Title = "Harry Potter and the Philosopher's Stone"
                        },
                        new
                        {
                            Id = new Guid("1606c42c-c75d-480a-9b3e-c0dfe1038924"),
                            Author = "Ernest Cline",
                            CategoryId = new Guid("ad61fd92-f66f-45ef-909a-92878cd8fe3f"),
                            Title = "Ready Player One"
                        },
                        new
                        {
                            Id = new Guid("392a956a-dca7-4999-a659-1dbb6c83942e"),
                            Author = "Ernest Cline",
                            CategoryId = new Guid("ad61fd92-f66f-45ef-909a-92878cd8fe3f"),
                            Title = "Ready Player Two"
                        },
                        new
                        {
                            Id = new Guid("e5ee58d9-376e-4a6e-8afa-a3b61a13f713"),
                            Author = "Orson Scott Card",
                            CategoryId = new Guid("5001db94-553e-4304-b3b7-cede845c0e53"),
                            Title = "Ender's Game"
                        },
                        new
                        {
                            Id = new Guid("3546ee96-9ba2-4970-8025-7ef8a565cbc5"),
                            Author = "Jane Austen",
                            CategoryId = new Guid("c1767b01-4814-4abf-9dcf-63dc43ce4c77"),
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = new Guid("ebc5a247-2ebb-426e-8528-cbfdfd074052"),
                            Author = "Harper Lee",
                            CategoryId = new Guid("7831d8f7-5db2-4159-98be-d4c4a07b9615"),
                            Title = "To Kill A Mockingbird"
                        },
                        new
                        {
                            Id = new Guid("38141e8c-e0ae-4c0b-993b-946109ac1f8b"),
                            Author = "William Golding",
                            CategoryId = new Guid("7831d8f7-5db2-4159-98be-d4c4a07b9615"),
                            Title = "Lord of the Flies"
                        },
                        new
                        {
                            Id = new Guid("5f94670d-27c6-4025-b22f-b4d6de94316a"),
                            Author = "Neil Gaiman",
                            CategoryId = new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"),
                            Title = "Stardust"
                        },
                        new
                        {
                            Id = new Guid("06f5cdb8-2433-4819-b57b-d41f0127e923"),
                            Author = "Marc Cameron",
                            CategoryId = new Guid("7831d8f7-5db2-4159-98be-d4c4a07b9615"),
                            Title = "Tom Clancy's Oath of Office"
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.BookRequest", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "RequestId");

                    b.HasIndex("RequestId");

                    b.ToTable("BookRequests");

                    b.HasData(
                        new
                        {
                            BookId = new Guid("84c13949-dfed-47ec-b9af-a4e96f1c4d25"),
                            RequestId = new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9")
                        },
                        new
                        {
                            BookId = new Guid("687699a7-6ff7-421e-9417-6307300ac142"),
                            RequestId = new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9")
                        },
                        new
                        {
                            BookId = new Guid("5ffd8911-431a-4799-9ad9-c07292d29e5b"),
                            RequestId = new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9")
                        },
                        new
                        {
                            BookId = new Guid("1606c42c-c75d-480a-9b3e-c0dfe1038924"),
                            RequestId = new Guid("49f69fda-c2b9-4654-b0d8-fa7ca269872c")
                        },
                        new
                        {
                            BookId = new Guid("392a956a-dca7-4999-a659-1dbb6c83942e"),
                            RequestId = new Guid("49f69fda-c2b9-4654-b0d8-fa7ca269872c")
                        },
                        new
                        {
                            BookId = new Guid("e5ee58d9-376e-4a6e-8afa-a3b61a13f713"),
                            RequestId = new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4")
                        },
                        new
                        {
                            BookId = new Guid("3546ee96-9ba2-4970-8025-7ef8a565cbc5"),
                            RequestId = new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4")
                        },
                        new
                        {
                            BookId = new Guid("5ffd8911-431a-4799-9ad9-c07292d29e5b"),
                            RequestId = new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4")
                        },
                        new
                        {
                            BookId = new Guid("ebc5a247-2ebb-426e-8528-cbfdfd074052"),
                            RequestId = new Guid("581888e2-eab8-40e7-9a25-bc7d36b5198f")
                        },
                        new
                        {
                            BookId = new Guid("38141e8c-e0ae-4c0b-993b-946109ac1f8b"),
                            RequestId = new Guid("581888e2-eab8-40e7-9a25-bc7d36b5198f")
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8fcb17e4-f0ac-4594-9c7f-a349a722a660"),
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = new Guid("ad61fd92-f66f-45ef-909a-92878cd8fe3f"),
                            Name = "Action"
                        },
                        new
                        {
                            Id = new Guid("5001db94-553e-4304-b3b7-cede845c0e53"),
                            Name = "Sci-fi"
                        },
                        new
                        {
                            Id = new Guid("c1767b01-4814-4abf-9dcf-63dc43ce4c77"),
                            Name = "Romance"
                        },
                        new
                        {
                            Id = new Guid("fa2db344-ecaa-4763-94e4-05023ccad649"),
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = new Guid("7831d8f7-5db2-4159-98be-d4c4a07b9615"),
                            Name = "Thriller"
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.RequestModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RequestedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9dd28664-1291-43cc-823c-a796ef8a20a9"),
                            RequestedDate = new DateTime(2021, 4, 19, 12, 39, 54, 655, DateTimeKind.Local).AddTicks(8980),
                            Status = 1,
                            UserId = new Guid("bf4699a4-129e-4610-8567-d834f3a0981b")
                        },
                        new
                        {
                            Id = new Guid("49f69fda-c2b9-4654-b0d8-fa7ca269872c"),
                            RequestedDate = new DateTime(2021, 4, 19, 12, 39, 54, 659, DateTimeKind.Local).AddTicks(1564),
                            Status = 0,
                            UserId = new Guid("bf4699a4-129e-4610-8567-d834f3a0981b")
                        },
                        new
                        {
                            Id = new Guid("4c86d8ae-0a76-45d4-a7ac-853b76debcc4"),
                            RequestedDate = new DateTime(2021, 4, 19, 12, 39, 54, 659, DateTimeKind.Local).AddTicks(1599),
                            Status = 2,
                            UserId = new Guid("4384cb37-6891-46ef-b7a7-1d04f3f968bc")
                        },
                        new
                        {
                            Id = new Guid("581888e2-eab8-40e7-9a25-bc7d36b5198f"),
                            RequestedDate = new DateTime(2021, 4, 19, 12, 39, 54, 659, DateTimeKind.Local).AddTicks(1603),
                            Status = 0,
                            UserId = new Guid("4384cb37-6891-46ef-b7a7-1d04f3f968bc")
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a7188a6-268b-4c04-860f-e975de266fe0"),
                            Password = "admin123",
                            Role = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("bf4699a4-129e-4610-8567-d834f3a0981b"),
                            Password = "user123",
                            Role = 0,
                            Username = "love2read"
                        },
                        new
                        {
                            Id = new Guid("4384cb37-6891-46ef-b7a7-1d04f3f968bc"),
                            Password = "user456",
                            Role = 0,
                            Username = "novelreader"
                        },
                        new
                        {
                            Id = new Guid("e1635a65-b4e6-44b7-8629-4a1bdc8c2308"),
                            Password = "user234",
                            Role = 0,
                            Username = "readingoverrated"
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("LibraryAPI.Models.Book", b =>
                {
                    b.HasOne("LibraryAPI.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LibraryAPI.Models.BookRequest", b =>
                {
                    b.HasOne("LibraryAPI.Models.Book", "Book")
                        .WithMany("BookRequests")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryAPI.Models.RequestModel", "Request")
                        .WithMany("BookRequests")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("LibraryAPI.Models.RequestModel", b =>
                {
                    b.HasOne("LibraryAPI.Models.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.UserToken", b =>
                {
                    b.HasOne("LibraryAPI.Models.User", "User")
                        .WithOne("Token")
                        .HasForeignKey("LibraryAPI.Models.UserToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.Book", b =>
                {
                    b.Navigation("BookRequests");
                });

            modelBuilder.Entity("LibraryAPI.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryAPI.Models.RequestModel", b =>
                {
                    b.Navigation("BookRequests");
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Navigation("Requests");

                    b.Navigation("Token");
                });
#pragma warning restore 612, 618
        }
    }
}
